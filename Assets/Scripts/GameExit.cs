using UnityEngine;

public class GameExit : MonoBehaviour
{
    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // 유니티 에디터에서 실행 종료
#else
        Application.Quit(); // 빌드된 게임에서 실행 종료
#endif
    }
}
