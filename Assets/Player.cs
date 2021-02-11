using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Player : NetworkBehaviour
{
    public CharacterController2D controller2D;
    public float runSpeed = 40f;
    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;
    // Start is called before the first frame update
    void Update()
    {
        if(isLocalPlayer){
            horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
            if(Input.GetButtonDown("Jump")){
                jump = true;
            }

            /* if(Input.GetButtonDown("Crouch")){
                crouch = true;
            }else if(Input.GetButtonUp("Crouch")){
                crouch = false;
            } */
        }
    }

    private void FixedUpdate() {
        if(isLocalPlayer){
            controller2D.Move(horizontalMove * Time.fixedDeltaTime,crouch,jump);
            jump = false;
        }
    }
}
