﻿
using DG.Tweening;
using System;
using UnityEngine;
using System.Collections;

/// <summary>
/// boss
/// 分阶段
/// 有圆圈血条
/// 有特殊UI展示
/// 有特殊立绘
/// </summary>
public class Boss : Enemy
{
    private const string BossBottomMark = "ui/prefabs/battle/UIBossBottomMark.prefab";
    private const string BossHpBar = "ui/prefabs/battle/UIBossHpHud.prefab";
    private const string BossHpCircle = "ui/prefabs/battle/UIBossCircle.prefab";

    //上方中心位置
    public static Vector3 BossUpCenter = Vector2Fight.New(0f, 50f);

    //中心位置
    public static Vector3 BossMidCenter = Vector2Fight.New(0f, 0f);

    //boss符卡管理器
    private BossCardMgr CardMgr;
    private UIBossHpComponent _bossHpHud;
    private UIBossCircleComponent _bossCircle;
    private bool _initedHpBar;


    public override void Init(SpriteRenderer renderer, EnemyDeploy deploy)
    {
        base.Init(renderer, deploy);

        CardMgr = new BossCardMgr();
        CardMgr.Init(this, HPMax);

        Invisible = true;

        TryDialog();

        //场景卷轴减慢
        StageSceneBase.ChangeSpeed(5f);
    }

    private void TryDialog()
    {
        if(StageMgr.MainPlayer != null)
        {
            var deploy = DialogMgr.GetBossDialog(StageMgr.MainPlayer.Deploy.id, Deploy.id, true);
            if(deploy != null)
            {
                var list = DialogMgr.GetDrawList(deploy.dialogId);
                UIDrawingChat.Show(list, 
                    ()=> 
                    { 
                        MoveToTarget(BossUpCenter, 10f); 
                    },
                    () =>
                    {
                        StartFight();
                        if (deploy.bgmId > 0)
                        {
                            Sound.PlayMusic(deploy.bgmId);
                            UIBgmTip.Show(deploy.bgmId);
                        }
                    });
                return;
            }
        }

        //如果没有对话，直接移动到指定位置，并开始战斗
        MoveToTarget(BossUpCenter, 10f);
        DOVirtual.DelayedCall(1.15F, StartFight, false);
    }

    private void StartFight()
    {
        //第一符卡，播放收放特效(关卡中途加入的boss不需要)
        if (!CardMgr.IsSingleCard())
        {
            PlayShirnkEffect(true);
        }

        //bossMark显示
        UIBattle.SetBossMarkActive(true);

        //血条
        var bossHpHudObj = ResourceMgr.Instantiate(ResourceMgr.LoadImmediately(BossHpBar));
        bossHpHudObj.transform.SetParent(gameObject.transform, false);
        _bossHpHud = bossHpHudObj.GetComponent<UIBossHpComponent>();
        _bossHpHud.Canvas.sortingOrder = SortingOrder.EnemyBullet + 1;
        _bossHpHud.Canvas.worldCamera = StageCamera2D.Instance.MainCamera;

        //boss背景
        var circle = ResourceMgr.Instantiate(ResourceMgr.LoadImmediately(BossHpCircle));
        circle.transform.SetParent(gameObject.transform, false);
        _bossCircle = circle.GetComponent<UIBossCircleComponent>();

        //bossCard
        DOVirtual.DelayedCall(1F, CardMgr.OnStartFight, false);

        //禁止无敌
        Invisible = false;

        //场景卷轴恢复
        StageSceneBase.RevertSpeed();
    }

    //显示隐藏boss气流扰动效果
    public void ShowCircleRaoDong(bool b)
    {
        if(_bossCircle)
        {
            _bossCircle.RaoDong.material.SetFloat("_DistortStrength", b ? 0.06f : 0f);
        }
    }

    public void SetCircleColor(Color color)
    {
        if (_bossCircle)
        {
            _bossCircle.RaoDong.material.SetColor("_Color", color);
        }
    }

    //显示隐藏血条上的标志点
    public void SetHpHudPointActive(bool b)
    {
        if (_bossHpHud)
        {
            _bossHpHud.Point.SetActiveByCanvasGroup(b);
        }
    }

    //显示隐藏血条
    public void SetHpHudActive(bool b)
    {
        if(_bossHpHud)
        {
            if (b) 
            {
                _bossHpHud.SetActiveSafe(true);
                _bossHpHud.Bar.fillAmount = 0f;
                _bossHpHud.Bar.DOFillAmount(1f, 1f).onComplete = () => { _initedHpBar = true; };
            }
            else
            {
                _bossHpHud.SetActiveSafe(false);
            }
        }
    }

    private void UpdateHpHud()
    {
        if (!_initedHpBar) return;
        if (_bossHpHud == null) return;

        _bossHpHud.Bar.fillAmount = CardMgr.GetHpPercent();
    }

    public void PlayShirnkEffect(bool bPlayAmplify = false)
    {
        //音效
        Sound.PlayUiAudioOneShot(107);

        var effect = ResourceMgr.Instantiate(ResourceMgr.LoadImmediately("effects_tex/prefab/bossStart2.prefab"));
        effect.SetRendererOrderSort(SortingOrder.Top);

        var e = effect.AddComponent<EffectMono>();
        e.transform.SetParent(transform, false);
        e.AutoDestory();

        if (bPlayAmplify) 
        {
            StartCoroutine(PlayAmplifyEffect(1.2f));
        }
    }

    public IEnumerator PlayAmplifyEffect(float sec)
    {
        yield return new WaitForSeconds(sec);
        var pos = transform.position; 
        EffectFactory.CreateEffect("effects_tex/prefab/bossStart.prefab", eff =>
        {
            if(gameObject == null)
            {
                eff.transform.position = pos;
            }
            else
            {
                eff.transform.SetParent(transform, false);
            }
            eff.gameObject.SetRendererOrderSort(SortingOrder.Top);
            Sound.PlayUiAudioOneShot(110);
            eff.AutoDestory();
        });
    }


    protected override void CalculateHp(int atk)
    {
        //改为扣符卡血量
        CardMgr.CalculateHp(atk);
    }

    protected override void OnDead()
    {
        StartCoroutine(DoBossDead());
    }

    private IEnumerator DoBossDead()
    {
        //对话配置
        var dialogDeploy = DialogMgr.GetBossDialog(StageMgr.MainPlayer.Deploy.id, Deploy.id, false);

        //隐藏血条
        SetHpHudActive(false);

        //bossMark隐藏
        UIBattle.SetBossMarkActive(false);

        yield return new WaitForSeconds(0.3f);

        //震屏
        if(StageCamera2D.Instance) StageCamera2D.Instance.Shake(0.7f, 1.2f);
        if(StageCamera3D.Instance) StageCamera3D.Instance.Shake(0.7f, 1.2f);

        Sound.PlayUiAudioOneShot(105);

        //播放shader特效
        StageCamera2D.Instance.PlayDeadEffect(transform.position);

        //隐藏renderer
        MainRenderer.enabled = false;
        if(_bossCircle)
        {
            _bossCircle.SetActiveSafe(false);
        }

        yield return new WaitForSeconds(0.7f);

        //尝试显示对话
        if (dialogDeploy != null)
        {
            var list = DialogMgr.GetDrawList(dialogDeploy.dialogId);
            UIDrawingChat.Show(list, null,
            () =>
            {
                GameEventCenter.Send(GameEvent.OnEnemyDie);
            });
        }
        else
        {
            GameEventCenter.Send(GameEvent.OnEnemyDie);
        }

        yield return new WaitForSeconds(0.3f);
        Destroy(gameObject);
    }

    protected override void Update()
    {
        base.Update();
        UpdateHpHud();
        UIBattle.SetBossMarkPos(transform.position);
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        CardMgr?.OnFixedUpdate();
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
        CardMgr?.OnDestroy();
        CardMgr = null;
    }
}

