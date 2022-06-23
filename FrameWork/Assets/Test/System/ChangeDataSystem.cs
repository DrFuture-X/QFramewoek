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
            //进行事件里面的一些操作
            e.WriteMsg();
            
        });
        
    }
    
    //在System中进行的操作
    public void DoSth()
    {
        var dataModel = this.GetModel<IDataModel>();
        dataModel.Name.Value = "王五";
        dataModel.Age.Value = 100;
    }
}
