using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

public class TestPanel: MonoBehaviour,IController
{
    private IDataModel dataModel;
    private IChangeDataSystem changeDataSystem;

    void Awake()
    {
        dataModel = this.GetModel<IDataModel>();
        changeDataSystem = this.GetSystem<IChangeDataSystem>();

        //注册委托
        dataModel.Name.Register(OnNameChanged);
        dataModel.Age.Register(OnAgeChanged);

        //先执行一次方法，显示到屏幕上
        OnNameChanged(dataModel.Name.Value);
        OnAgeChanged(dataModel.Age.Value);
  
        transform.Find("ShowBt").GetComponent<Button>().onClick.AddListener(()=> 
        {
            this.SendCommand<ChangeDataCommand>();
            
            //执行System中的东西
            StartCoroutine(Do());
        });
    }
    
    IEnumerator Do()
    {
        //3秒后执行
        yield return new WaitForSeconds(3);
        changeDataSystem.DoSth();
    }

    private void OnNameChanged(string name)
    {
        transform.Find("NameTxt").GetComponent<Text>().text = "名字：" + name;
    }

    private void OnAgeChanged(int age)
    {
        transform.Find("AgeTxt").GetComponent<Text>().text = "年龄：" + age + "岁";
    }

    private void OnDestroy()
    {
        dataModel.Name.UnRegister(OnNameChanged);
        dataModel.Age.UnRegister(OnAgeChanged);
        dataModel = null;
    }

    public IArchitecture GetArchitecture()
    {
        return GameUI.Interface;
    }
}
