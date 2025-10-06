using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputManager : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private Transform[] spawnPoints;

    private bool wasdJoined = false;
    private bool arrowsJoined = false;

    void Update()
    {
        if (Keyboard.current == null) return;

        if (!wasdJoined && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            var player = PlayerInput.Instantiate(playerPrefab,
                controlScheme: "WASD",
                pairWithDevice: Keyboard.current);
                player.GetComponent<Renderer>().material.color=Color.teal;
                player.name = "Player Teal";
                player.tag = "Teal";

            if (spawnPoints.Length > 0 )
            {
                player.transform.position = spawnPoints[0].position;
            }

            wasdJoined = true;
        }

        if (!arrowsJoined && Keyboard.current.rightCtrlKey.wasPressedThisFrame)
        {
            var player = PlayerInput.Instantiate(playerPrefab,
                controlScheme: "Arrows",
                pairWithDevice: Keyboard.current);
                player.GetComponent<Renderer>().material.color=Color.pink;
                player.name = "Player Pink";
                player.tag = "Pink";
  
            if (spawnPoints.Length > 1)
            {
                player.transform.position = spawnPoints[1].position;
            }

            arrowsJoined = true;
        }
    }
}
