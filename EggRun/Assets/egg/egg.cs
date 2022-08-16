using System;
using System.Collections.Generic;
using UnityEngine;

public class egg : MonoBehaviour
{
    Rigidbody rBody;
    [SerializeField] private float moveSpeed = 3.0f;
    public Transform cam;
    private float x;
    private float z;
    bool moving = false;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        this.rBody = GetComponent<Rigidbody>();
        this.animator = GetComponent<Animator>();
        x = 0;
        z = 0;
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxisRaw("Horizontal");
        z = Input.GetAxisRaw("Vertical");
        if(x == 0 && z == 0)
        {
            animator.SetTrigger("stopping");
        }
        else
        {
            animator.SetTrigger("moving");
        }
    }

    void FixedUpdate()
    {

        Vector3 cameraForward = Vector3.Scale(cam.forward, new Vector3(1, 1, 1)).normalized;

        Vector3 moveForward = cameraForward * z + cam.right * x;
        moveForward.y = 0;

        rBody.velocity = moveForward * moveSpeed + new Vector3(0, 0, 0);

        Vector3 cameraY = new Vector3(0, Quaternion.LookRotation(moveForward).y, 0);
        if (moveForward != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(moveForward);
            var look = transform.rotation;
            look.x = 0;
            look.z = 0;
            transform.rotation = look;
        }
    }
}
