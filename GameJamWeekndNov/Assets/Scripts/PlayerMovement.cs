using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   [SerializeField] float Speed = 2f; 
   Vector3 movement;
   Vector3 lookRotVector;
   bool jumped = false;
   float jumpTimer;

     void Start()
    {
        jumpTimer = Time.time;
    }

    public void Move()
    {
        InputTake();
        Jump();
        LookRotation();
        Movement();
    }


    public void InputTake()
    {
        float x =  Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        movement = new Vector3(x, movement.y, z);  
    }    

    void Movement()
    {
        //removing the .normalized would make the speed double time faster. It also adds a little delay when stopping.  
        if(jumped){
            movement.x = Mathf.Clamp(movement.x, -0.25f, 0.25f);
            movement.z = Mathf.Clamp(movement.z, -0.25f, 0.25f);
            transform.Translate(Vector3.ClampMagnitude(movement, 1.25f) * Speed * Time.deltaTime, Space.World);
        }
        else{
            transform.Translate(Vector3.ClampMagnitude(movement, 1f) * Speed * Time.deltaTime, Space.World);
        }
    }

    void LookRotation()
    {
        lookRotVector = movement;
        lookRotVector.y = 0;

        if(lookRotVector != Vector3.zero)
        {
            Quaternion rotate = Quaternion.LookRotation(lookRotVector, Vector3.up);
            transform.rotation = rotate;
        }
    }

    void Jump(){
        if(Input.GetKey(KeyCode.Space) && jumpTimer + 1f<= Time.time){
            jumped = true;
            jumpTimer = Time.time;
            movement.y = 1f;
        }else if(jumpTimer + 1f <= Time.time){
            movement.y = 0;
            jumped = false;
        }
    }

}



