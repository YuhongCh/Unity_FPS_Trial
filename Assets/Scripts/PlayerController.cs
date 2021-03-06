using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject Camera;
    public float speed;
    public float jumpHeight;

    private Rigidbody rb;
    private bool canJump = true;
    private HealthBarBehavior HP;
    void Start()
    {
        rb = GetComponent<Rigidbody>();  
        HP = GetComponent<HealthBarBehavior>();
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Ground") canJump = true;
    }

    void FixedUpdate()
    {
        float moveX = Input.GetAxis("Horizontal") * speed;
        float moveZ = Input.GetAxis("Vertical") * speed;
        Vector3 move = new Vector3(moveX, rb.velocity.y, moveZ);

        if (Input.GetKeyDown("space") && canJump)
        {
            move.y = jumpHeight;
            canJump = false;
        }
        Vector3 relativeMove = Camera.transform.TransformDirection(move);
        relativeMove.y = move.y;
        rb.velocity = relativeMove;
    }

    void Update()
    {
        if (HP.getHealth() < 1 || transform.position.y < -10f) 
        {
            SceneManager.LoadScene("GameEnd");
            Cursor.lockState = CursorLockMode.Confined;
        }
    }

}