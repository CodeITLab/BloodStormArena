using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController barbarinController;
    private BarbarinWarriorAnimations barbarinAnimations;

    public float moveSpeed;
    public float gravity;
    public float rotationSpeed;
    public float rotateDegreesPerSecond;

    private void Awake(){
        barbarinController = GetComponent<CharacterController>();
        barbarinAnimations = GetComponent<BarbarinWarriorAnimations>();
    }

    private void Update(){
        PlayerMove();
        AnimateWalk_SprintForward();
    }

    private void PlayerMove(){
        if(Input.GetAxisRaw(Axis.VERTICAL_AXIS) > 0){
            Vector3 moveDirection = transform.forward;
            moveDirection.y -= gravity * Time.deltaTime;

            barbarinController.Move(moveDirection * moveSpeed * Time.deltaTime);

        }else if(Input.GetAxisRaw(Axis.VERTICAL_AXIS) < 0){
            Vector3 moveDirection = -transform.forward;
            moveDirection.y -= gravity * Time.deltaTime;

            barbarinController.Move(moveDirection * moveSpeed * Time.deltaTime);
        }
        else{
            barbarinController.Move(Vector3.zero);
        }
        Rotate();
    }

    private void Rotate(){
        Vector3 rotationDirection = Vector3.zero;
        if(Input.GetAxisRaw(Axis.HORIZONTAL_AXIS) < 0){
            rotationDirection = transform.TransformDirection(Vector3.left);
        }
        if(Input.GetAxisRaw(Axis.HORIZONTAL_AXIS) > 0){
            rotationDirection = transform.TransformDirection(Vector3.right);
        }

        if(rotationDirection != Vector3.zero){
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(rotationDirection), 
                rotateDegreesPerSecond * Time.deltaTime);
        }
    }

    private void AnimateWalk_SprintForward(){
        if (barbarinController.velocity.sqrMagnitude != 0 && Input.GetKey(KeyCode.W)){
            moveSpeed = 3f;
            barbarinAnimations.Walk(true);
            barbarinAnimations.WalkBackwards(false);
            barbarinAnimations.Sprint(false);
        }
        else{
            barbarinAnimations.Walk(false);
            barbarinAnimations.WalkBackwards(false);
            barbarinAnimations.Sprint(false);
        }

        if(barbarinController.velocity.sqrMagnitude != 0 && Input.GetKey(KeyCode.S))
        {
            moveSpeed = 3f;
            barbarinAnimations.WalkBackwards(true);
            barbarinAnimations.Walk(false);
            barbarinAnimations.Sprint(false);
        }
        
        if(barbarinController.velocity.sqrMagnitude != 0 && Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = 5.5f;
            barbarinAnimations.Sprint(true);
            barbarinAnimations.WalkBackwards(false);
            barbarinAnimations.Walk(false);
        }
    }
}
