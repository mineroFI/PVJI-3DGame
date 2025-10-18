using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 forceToApply;
    private float timeSinceLastForce;
    private float intervalTime;
    private IMovementStrategy movementStrategy;
    private Player player;
    private float input;

    public void SetMovementStrategy(IMovementStrategy movementStrategy)
    {
        this.movementStrategy = movementStrategy;
    }
    private void Start()
    {
        forceToApply = new Vector3(0, 0, 5);
        timeSinceLastForce = 0f;
        intervalTime = 2f;
        player = new Player(5f, 2f);
        //SetMovementStrategy(new SmoothMovement());
        SetMovementStrategy(new AccelerateMovement());
    }



    public void MovePlayer(float input)
    {
        movementStrategy.Move(transform, player, input);
    }
    private void FixedUpdate()
    {
        timeSinceLastForce += Time.fixedDeltaTime;
        if(timeSinceLastForce >= intervalTime)
        {
            gameObject.GetComponent<Rigidbody>().AddForce(forceToApply, ForceMode.Impulse);
            timeSinceLastForce = 0f;
        }
    }
}

