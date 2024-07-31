using UnityEditor;
using UnityEngine;

public class PlayerProfile : MonoBehaviour
{

#if UNITY_EDITOR
    [SerializeField] private int startLevelIndex = 0;
#endif

    public static int LevelIndex
    {
        get
        {
#if UNITY_EDITOR
            return PlayerPrefs.GetInt("LevelIndex", Instance.startLevelIndex);
#else
            return PlayerPrefs.GetInt("LevelIndex", 0);
#endif
        }

        set
        {
            PlayerPrefs.SetInt("LevelIndex", value);
        }
    }

    // Singleton pattern
    private static PlayerProfile instance;
    public static PlayerProfile Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<PlayerProfile>();
                if (instance == null)
                {
                    instance = new GameObject().AddComponent<PlayerProfile>();
                    instance.gameObject.name = instance.GetType().Name;
                }
            }

            return instance;
        }
    }

#if UNITY_EDITOR
    [MenuItem("Profile/Clear PlayerPrefs")]
    private static void ClearPlayerPref()
    {
        PlayerPrefs.DeleteAll();
    }
#endif
}