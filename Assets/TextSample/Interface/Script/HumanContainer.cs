using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Text.Interface
{
    public class HumanContainer : MonoBehaviour
    {
        [SerializeField] GameObject _human;
        IHuman _iHuman => _human.GetComponent<IHuman>();
        public void Eat() => _iHuman.Eat();
        public void Sleep() => _iHuman.Sleep();
    }
}
