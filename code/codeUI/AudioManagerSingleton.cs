using UnityEngine;

public class AudioManagerSingleton : MonoBehaviour
{
    private static AudioManagerSingleton inst;

    void Awake()
    {
        if (inst != null && inst != this)
        {
            Destroy(gameObject);
            return;
        }
        inst = this;
        DontDestroyOnLoad(gameObject);
    }
}
