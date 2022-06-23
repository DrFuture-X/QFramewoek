using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;

public class GameUI : Architecture<GameUI>
{
    protected override void Init()
    {
        RegisterModel<IDataModel>(new DataModel());
        RegisterSystem<IChangeDataSystem>(new ChangeDataSystem());
    }
}
