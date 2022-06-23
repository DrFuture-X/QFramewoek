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

        //ע��ί��
        dataModel.Name.Register(OnNameChanged);
        dataModel.Age.Register(OnAgeChanged);

        //��ִ��һ�η�������ʾ����Ļ��
        OnNameChanged(dataModel.Name.Value);
        OnAgeChanged(dataModel.Age.Value);
  
        transform.Find("ShowBt").GetComponent<Button>().onClick.AddListener(()=> 
        {
            this.SendCommand<ChangeDataCommand>();
            
            //ִ��System�еĶ���
            StartCoroutine(Do());
        });
    }
    
    IEnumerator Do()
    {
        //3���ִ��
        yield return new WaitForSeconds(3);
        changeDataSystem.DoSth();
    }

    private void OnNameChanged(string name)
    {
        transform.Find("NameTxt").GetComponent<Text>().text = "���֣�" + name;
    }

    private void OnAgeChanged(int age)
    {
        transform.Find("AgeTxt").GetComponent<Text>().text = "���䣺" + age + "��";
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
