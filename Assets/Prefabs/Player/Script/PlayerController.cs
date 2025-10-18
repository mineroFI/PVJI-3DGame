using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private List<ICommand> commands;

    private void Start()
    {
        playerMovement = gameObject.GetComponent<PlayerMovement>();
        commands = new List<ICommand>();
    }

    private void Update()
    {
        commands.Clear();
        float horizontalInput = Input.GetAxis("Horizontal");
        commands.Add(new MoveCommand(playerMovement, horizontalInput));

        if (Input.GetKey(KeyCode.Space))
        {
            commands.Add(new AccelerateMoveCommand(playerMovement, horizontalInput));
        }

        foreach (var command in commands)
        {
            command.Execute();
        }
    }
}