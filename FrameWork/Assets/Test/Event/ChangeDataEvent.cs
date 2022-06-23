using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeDataEvent
{
    public void WriteMsg()
    {
        Debug.Log("发送事件");
        Debug.Log("在这里可以写一些事件里面触发的东西");
    }
}