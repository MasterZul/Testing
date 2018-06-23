using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerTransform : MonoBehaviour {

    private string moveInputAxis = "Vertical";
    private string turnInputAxis = "Horizontal";

    public float rotationRate = 360;

    public float moveSpeed = 10;

    Animator animatorgirl;

    private Rigidbody rb;

	// Use this for initialization
	void Start () {

        rb = GetComponent<Rigidbody>();
        animatorgirl  =  GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {

        float moveAxis = Input.GetAxis(moveInputAxis);
        float turnAxis = Input.GetAxis(turnInputAxis);

        ApplyInput(moveAxis, turnAxis);

        bool walking = Input.GetKey(KeyCode.UpArrow);
        bool walkingBack = Input.GetKey(KeyCode.DownArrow);

        Debug.Log(walking);

        if (walking == true || walkingBack == true)
        {
            animatorgirl.SetBool("walking", walking);
            //anigirl.Play();
        }
        else
        {

            animatorgirl.SetBool("walking", walking);
        }

    }

    private void ApplyInput(float moveInput, float turnInput)
    {
        Move(moveInput);
        Turn(turnInput);
    }

    private void Move(float Input)
    {
        //transform.Translate(Vector3.forward * Input *moveSpeed);
        rb.AddForce(transform.forward * Input * moveSpeed, ForceMode.Force);
    }

    private void Turn(float Input)
    {
        transform.Rotate(0, Input * rotationRate * Time.deltaTime, 0);
    }
}
