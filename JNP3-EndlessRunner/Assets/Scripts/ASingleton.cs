using UnityEngine;

public abstract class ASingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance = null;

    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<T>();
                GameObject.DontDestroyOnLoad(instance);
            }

            return instance;
        }
    }

    private void Awake() {
        if ((instance != null) && (instance != this))
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this as T;
        }
    }
}