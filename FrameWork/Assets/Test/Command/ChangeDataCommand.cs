using QFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeDataCommand : AbstractCommand
{
    protected override void OnExecute()
    {
        
        Debug.Log("接收到了从UI传来的命令，修改用户信息");
        
        var dataModel = this.GetModel<IDataModel>();

        //修改用户的信息
        dataModel.Name.Value = "李四";
        dataModel.Age.Value = 50;

        Debug.Log("发送事件");

        //这个事件暂时没有用，只用作测试流程
        this.SendEvent<ChangeDataEvent>();
    }

}
