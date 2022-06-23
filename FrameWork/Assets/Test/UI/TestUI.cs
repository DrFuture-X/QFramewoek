using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;

public class TestUI : MonoBehaviour, IController
{
    
    void Start()
    {
        //用来测试事件
        this.RegisterEvent<ChangeDataEvent>(e=>
        {
            OnChangDataEvent();
        }).UnRegisterWhenGameObjectDestroyed(gameObject);
    }

    void OnChangDataEvent()
    {
        //打开关闭色块
        this.transform.Find("Canvas/GreenPanel").gameObject.SetActive(true);
        this.transform.Find("Canvas/YellowPanel").gameObject.SetActive(false);
    }

    public IArchitecture GetArchitecture()
    {
        return GameUI.Interface;
    }
}
