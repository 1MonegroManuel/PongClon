using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    private static DontDestroy instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Se mantiene vivo
        }
        else
        {
            Destroy(gameObject); // Si ya hay uno, destruye el duplicado
        }
    }
}
