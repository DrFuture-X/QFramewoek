using UnityEngine;
namespace QFramework.PointGame
{
    public class GameStartEvent 
    {
        ////////////////////////////////////////
        ///在CountDownSystem中进行的调用
        public void GameStart()
        {
            Debug.Log("GameStart");
        }
    }
}