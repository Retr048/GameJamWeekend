using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   [SerializeField] float Speed = 2f; 
   [SerializeField] Transform player;
   Vector3 movement;

     void Start()
    {
        
    }

    public void Move()
    {
        InputTake();
        LookRotation();
        Movement();
    }


    public void InputTake()
    {
        float x =  Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        movement = new Vector3(x, 0, z);  
        //removing the .normalized would make the speed double time faster. It also adds a little delay when stopping.        
    }    

    void Movement()
    {
        this.transform.Translate(movement.normalized * (Speed * Time.deltaTime));
    }

    void LookRotation()
    {
        if(movement != Vector3.zero)
        {
            Quaternion rotate = Quaternion.LookRotation(movement, Vector3.up);
            player.rotation = rotate;
        }
    }

}



