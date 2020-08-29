﻿
using UnityEngine;
using DG.Tweening;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.UI;

public class UIMainView : UiFullView
{
    public static int PrevSelected = 0;

    public static void Show(bool showAni)
    {
        var view = UiManager.ImmediatelyShow<UIMainView>();
        view.DoOpen(showAni);
    }

    private UIMainViewCompoent _compent;

    protected override void OnLoadFinish()
    {
        base.OnLoadFinish();

        _compent = GetComponent<UIMainViewCompoent>();
       
        _compent.Btn_ExtraStart.IsEnable = false;
        _compent.Btn_GameStart.onClick.AddListener(Btn_GameStart);
        _compent.Btn_ExtraStart.onClick.AddListener(Btn_ExtraStart);
        _compent.Btn_ParcticeStart.onClick.AddListener(Btn_ParcticeStart);
        _compent.Btn_SpellParctice.onClick.AddListener(Btn_SpellParctice);
        _compent.Btn_Replay.onClick.AddListener(Btn_Replay);
        _compent.Btn_PlayerData.onClick.AddListener(Btn_PlayerData);
        _compent.Btn_MusicRoom.onClick.AddListener(Btn_MusicRoom);
        _compent.Btn_Option.onClick.AddListener(Btn_Option);
        _compent.Btn_Manual.onClick.AddListener(Btn_Manual);
        _compent.Btn_Quit.onClick.AddListener(Btn_Quit);
    }

    private void DoOpen(bool playAni)
    {
        _compent.Menu.Enable = false;
        if(playAni)
        {
            _compent.Animator.Play("FirstOpen");
            StartCoroutine(PlayAnimation(playAni));
        }
        else
        {
            _compent.Animator.Play("ReOpen");
            //Sound.PlayMusic(1);
        }
    }

    private IEnumerator PlayAnimation(bool playAni)
    {
        yield return Sound.CacheSound(1);
        Sound.PlayMusic(1);
    }

    protected override void Update()
    {
        base.Update();

        if(!_compent.Menu.Enable)
        {
            if (_compent.Animator.GetCurrentAnimatorStateInfo(0).IsName("Loop"))
            {
              
                _compent.Menu.Enable = true;
            }
        }
    }


    protected override void OnShow()
    {
        base.OnShow();
    }

    private void Btn_GameStart()
    {
        GameSystem.EnterLevel(1);
    }

    private void Btn_ExtraStart()
    {
        

    }
    private void Btn_ParcticeStart()
    {
        UiManager.Show<UIChooseDiffult>();
    }

    private void Btn_SpellParctice()
    {
        UiTips.Show(Application.streamingAssetsPath);
    }
    private void Btn_Replay()
    {
        UiTips.Show(Application.dataPath);
    }
    private void Btn_PlayerData()
    {
        UiTips.Show("Btn_PlayerData");
    }
    private void Btn_MusicRoom()
    {
        UiTips.Show("Btn_MusicRoom");
    }
    private void Btn_Option()
    {
        UiTips.Show("Btn_Option");
    }
    private void Btn_Manual()
    {
        UiTips.Show("Btn_Manual");
    }
    private void Btn_Quit()
    {
        UILogo.Show(() =>
        {
            Application.Quit();
        });
    }
}
