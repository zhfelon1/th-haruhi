﻿
using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class UIDebugBulletLib : UiInstance
{

    private UIDebugBulletLibComponent _component;
    protected override void OnLoadFinish()
    {
        base.OnLoadFinish();
        _component = GetComponent<UIDebugBulletLibComponent>();
        _component.CloseBtn.onClick.AddListener(() => { this.Close(); });
        _component.BtnShowPoint.onClick.AddListener(OnClickShowPoint);
        StartCoroutine(LoadBullets());
    }

    private bool _showPoint = true;
    private List<GameObject> _pointList = new List<GameObject>();
    private void OnClickShowPoint()
    {
        _showPoint = !_showPoint;
        for(int i = 0; i < _pointList.Count; i++)
        {
            _pointList[i].SetActiveSafe(_showPoint);
        }
    }

    public override void OnClose(Action<UiInstance> notify)
    {
        base.OnClose(notify);
        StopAllCoroutines();
    }

    private IEnumerator LoadBullets()
    {
        var soringLayerId = UiManager.GetCanvasByLayer(UiLayer.Tips).sortingLayerID;

        var tab = TableUtility.GetTable<BulletDeploy>();
        foreach(var deploy in tab)
        {
            if (deploy.id < 1000) continue;

            //ui prefab
            var bulletObj = ResourceMgr.Instantiate(_component.BulletPrefab);
            var txtId = bulletObj.GetComponentInChildren<UiText>();
            txtId.text = deploy.id.ToString();
            bulletObj.transform.SetParent(_component.Grid, false);

            //createBullet
            BulletFactory.CreateBullet(deploy.id, bulletObj.transform, Layers.Ui, bullet =>
            {
                var localScale = bullet.Renderer.transform.localScale;
                var ratio = localScale.x * 100;
                if (ratio > 100) ratio = 96f / localScale.x;

                bullet.Renderer.sortingLayerID = soringLayerId;
                bullet.transform.localScale = Vector3.one * ratio;
                bullet.Renderer.transform.SetLayer(Layers.Ui);
                bullet.transform.SetParent(bulletObj.transform, false);

                //显示collider
                var collider = bullet.GetComponentInChildren<CircleCollider2D>();
                var col = new GameObject("collider");
                col.transform.SetParent(bullet.transform, false);
                col.AddComponent<MeshFilter>().sharedMesh = GameSystem.DefaultRes.QuadMesh;
                col.layer = Layers.Ui;
                col.transform.localScale = Vector3.one * collider.radius * 2;

                var material = new Material(GameSystem.DefaultRes.CommonShader);
                material.mainTexture = GameSystem.DefaultRes.CircleTexture;
                material.SetColor("_TintColor", Color.red);
                material.SetFloat("_AlphaScale", deploy.alpha);

                var mr = col.AddComponent<MeshRenderer>();
                mr.sharedMaterial = material;
                mr.sortingLayerID = soringLayerId;
                mr.sortingOrder = bullet.Renderer.sortingOrder + 1;
                col.SetActiveSafe(_showPoint);
                _pointList.Add(col);

            });
            yield return Yielders.Frame;
        }
    }
}
