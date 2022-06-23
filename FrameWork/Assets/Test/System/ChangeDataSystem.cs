using QFramework;
using UnityEngine;
public interface IChangeDataSystem : ISystem
{
    void DoSth(); 
}

public class ChangeDataSystem : AbstractSystem, IChangeDataSystem
{
    protected override void OnInit()
    {

        this.RegisterEvent<ChangeDataEvent>(e=>
        {
            //�����¼������һЩ����
            e.WriteMsg();
            
        });
        
    }
    
    //��System�н��еĲ���
    public void DoSth()
    {
        var dataModel = this.GetModel<IDataModel>();
        dataModel.Name.Value = "����";
        dataModel.Age.Value = 100;
    }
}
