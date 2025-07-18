using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Store_Text : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI text;
    public Player_State playerState;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerState = FindObjectOfType<Player_State>();
        text.text = $"Wonhon : {playerState.Wonhon}";
    }
}
