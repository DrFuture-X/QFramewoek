using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;

public interface IDataModel : IModel
{
    BindableProperty<string> Name { get; }
    BindableProperty<int> Age { get; }
}
public class DataModel : AbstractModel, IDataModel
{
    public BindableProperty<string> Name { get; } = new BindableProperty<string>()
    {
        Value = "zhang"
    };

    public BindableProperty<int> Age { get; } = new BindableProperty<int>()
    { 
        Value = 20
    };
    
    protected override void OnInit()
    {
        Debug.Log("��ʼ������");
        Name.Value = "����";
        Age.Value = 20;
    }
}
