using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private bool isChangingOutfit = true;

    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isChangingOutfit)
            return;

        /*isPlayerMoving = false;

        //Initialize movement as Zero
        moveInput = new Vector2(0f, 0f);

        moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        moveInput *= moveSpeed;

        if (moveInput.x != 0 || moveInput.y != 0)
        {
            isPlayerMoving = true;
            lastMoveX = moveInput.x;
        }

        anim.SetFloat("MoveX", moveInput.x);
        anim.SetBool("IsMoving", isPlayerMoving);
        anim.SetFloat("LastMoveX", lastMoveX);*/
    }

    private void FixedUpdate()
    {
        //Move the Player through physics
        //myRB.velocity = moveInput;
    }

    public void SetLookSide(float value)
    {
        lastMoveX = value;
        moveInput.x = value;
        anim.SetFloat("LastMoveX", lastMoveX);
        anim.SetFloat("MoveX", moveInput.x);
    }

    public void SetWalkingValue(bool value)
    {
        isPlayerMoving = value;

        anim.SetBool("IsMoving", isPlayerMoving);
    }

    public bool IsWalking()
    {
        return isPlayerMoving;
    }
}
