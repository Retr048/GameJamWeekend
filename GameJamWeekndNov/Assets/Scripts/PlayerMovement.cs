using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   [SerializeField] float Speed = 2f; 
   Vector3 movement;
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

        if(!jumped)
            movement = new Vector3(x, movement.y, z);  
        //removing the .normalized would make the speed double time faster. It also adds a little delay when stopping.        
    }    

    void Movement()
    {
        transform.Translate(movement.normalized * Speed * Time.deltaTime, Space.World);
    }

    void LookRotation()
    {
        if(movement != Vector3.zero && !jumped)
        {
            Quaternion rotate = Quaternion.LookRotation(new Vector3(movement.x ,0 ,movement.z), Vector3.up);
            transform.rotation = rotate;
        }
    }

    void Jump(){
        if(Input.GetKey(KeyCode.Space) && jumpTimer + 1f<= Time.time){
            jumped = true;
            jumpTimer = Time.time;
            movement.y = 5;
        }else if(jumpTimer + 1f <= Time.time){
            movement.y = 0;
            jumped = false;
        }
    }

}



