using UnityEngine;

public class Store_Button : MonoBehaviour
{
    public int button = 0;
    public Player_State playerState;

    private void Start()
    {
        playerState = FindObjectOfType<Player_State>();
    }

    // Update is called once per frame
    public void OnButtonClicked()
    {
        if (playerState.Wonhon >= 30)
            switch (button)
            {
                case 0: break;
                case 1: break;
                case 2: break;
                case 3: break;
                case 4: break;
                case 5: break;
                case 6: break;
                case 7: break;
                case 8: break;
                default: break;
            }
    }
}
