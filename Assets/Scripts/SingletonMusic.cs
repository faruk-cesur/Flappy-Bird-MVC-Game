using UnityEngine;

public class SingletonMusic : MonoBehaviour
{
    private static SingletonMusic singletonMusic = null;

    // Hiçbir zaman yok olmayacak arka plan müziği veriyoruz.
    void Awake()
    {
        if (singletonMusic == null)
        {
            singletonMusic = this;
            DontDestroyOnLoad(this);
        }
        else if (this != singletonMusic)
        {
            Destroy(gameObject);
        }
    }
}