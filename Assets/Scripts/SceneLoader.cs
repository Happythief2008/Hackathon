using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // ��ư�� �� �޼��带 �����ϰ� �ν����Ϳ��� �� �̸��� �����ϼ���.
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
