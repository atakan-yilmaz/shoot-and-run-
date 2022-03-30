using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace shootandRun1.Abstracts.Helpers
{
    public class SingletonMonoBehavior<T> : MonoBehaviour where T : Component
    {
        public static T Instance { get; private set; }

        public void SetSingletonThisGameObject(T instance)
        {
            if (Instance == null)
            {
                Instance = instance;
                DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
    }
}

