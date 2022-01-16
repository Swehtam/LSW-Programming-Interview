using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class PlayerController : MonoBehaviour
{
    //Speed Variable
    public float moveSpeed;

    //Place that player will spawn
    public string loadPointName;

    [Tooltip("Player Animator")]
    public Animator anim;

    //Movement Variables
    private Vector3 moveInput;
    private bool isPlayerMoving;
    private float lastMoveX;

    private Rigidbody2D myRB;

    private bool isInteracting;
    private DialogueRunner runner;
    private PlayerEvents playerEvents;

    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        runner = InstancesManager.singleton.GetDialogueRunnerInstance();
        playerEvents = InstancesManager.singleton.GetPlayerEventsInstance();
        playerEvents.OnPlayerSetInteraction += PlayerSetInteraction;
    }

    // Update is called once per frame
    void Update()
    {
        if (runner == null)
            runner = InstancesManager.singleton.GetDialogueRunnerInstance();

        isPlayerMoving = false;

        //Initialize movement as Zero
        moveInput = new Vector2(0f, 0f);

        if (!isInteracting && !runner.IsDialogueRunning)
        {
            moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

            moveInput *= moveSpeed;

            if (moveInput.x != 0 || moveInput.y != 0)
            {
                isPlayerMoving = true;
                lastMoveX = moveInput.x;
            }
        }

        anim.SetFloat("MoveX", moveInput.x);
        anim.SetBool("IsMoving", isPlayerMoving);
        anim.SetFloat("LastMoveX", lastMoveX);
    }

    private void FixedUpdate()
    {
        //Move the Player using physics
        myRB.velocity = moveInput;
    }

    public bool IsWalking()
    {
        return isPlayerMoving;
    }

    private void PlayerSetInteraction(bool value)
    {
        isInteracting = value;
    }
}
