using UnityEngine;

public class GameExit : MonoBehaviour
{
    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // ����Ƽ �����Ϳ��� ���� ����
#else
        Application.Quit(); // ����� ���ӿ��� ���� ����
#endif
    }
}
