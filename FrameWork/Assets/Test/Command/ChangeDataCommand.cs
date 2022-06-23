using QFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeDataCommand : AbstractCommand
{
    protected override void OnExecute()
    {
        
        Debug.Log("���յ��˴�UI����������޸��û���Ϣ");
        
        var dataModel = this.GetModel<IDataModel>();

        //�޸��û�����Ϣ
        dataModel.Name.Value = "����";
        dataModel.Age.Value = 50;

        Debug.Log("�����¼�");

        //����¼���ʱû���ã�ֻ������������
        this.SendEvent<ChangeDataEvent>();
    }

}
