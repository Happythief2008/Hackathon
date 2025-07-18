using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // 버튼에 이 메서드를 연결하고 인스펙터에서 씬 이름을 지정하세요.
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
