using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelNav : MonoBehaviour
{
    [SerializeField]
    public static int index;

    public void SetLevelIndex(int levelIndex)
    {
        Debug.Log(index);
        index = levelIndex;
        Debug.Log(index);
    }

    public void PortalOpen()
    {
        SceneManager.LoadScene(index);
        Debug.Log("true");
    }
}
