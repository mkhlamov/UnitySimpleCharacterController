using System.Collections;
using System.Collections.Generic;
using ITB.Player;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class PlayerStateUI : MonoBehaviour
{
    [SerializeField] private Text playerStateText;
    
    private Player player;

    [Inject]
    public void Construct(Player player)
    {
        this.player = player;
    }
    private void OnEnable()
    {
        player.OnPlayerStateChanged += UpdatePlayerStateText;
    }

    private void OnDisable()
    {
        player.OnPlayerStateChanged -= UpdatePlayerStateText;
    }

    private void UpdatePlayerStateText(PlayerState playerState)
    {
        playerStateText.text = playerState.ToString();
    }
}