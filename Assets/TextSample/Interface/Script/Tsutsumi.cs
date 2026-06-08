using UnityEngine;

namespace Text.Interface
{
    public class Tsutsumi : MonoBehaviour,IHuman
    {
        public void Eat()
        {
            Debug.Log("好き嫌いなく食べる！！");
        }
        public void Sleep()
        {
            Debug.Log("抱き枕を使って寝る！！");
        }
    }
}
