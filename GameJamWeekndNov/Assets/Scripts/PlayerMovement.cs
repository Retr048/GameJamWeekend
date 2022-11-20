using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   [SerializeField] float Speed = 2f; 
   [SerializeField] Animator animator;
   [SerializeField] float jumpPower = 100f;
   Vector3 movement;
   Vector3 lookRotVector;
   bool jumped = false;
   bool addedForce = false;
   float jumpTimer;

     void Start()
    {
        jumpTimer = Time.time;
    }

    public void Move()
    {
        Debug.Log(addedForce);
        InputTake();
        Jump();
        LookRotation();
        Movement();
    }


    public void InputTake()
    {
        float x =  Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        movement = new Vector3(x, 0, z);  
    }    

    void Movement()
    {
        //removing the .normalized would make the speed double time faster. It also adds a little delay when stopping.  
         transform.Translate(Vector3.ClampMagnitude(movement, 1f) * Speed * Time.deltaTime, Space.World);
        
    }

    void LookRotation()
    {
        lookRotVector = movement;
        lookRotVector.y = 0;

        if(lookRotVector != Vector3.zero)
        {
            Quaternion rotate = Quaternion.LookRotation(lookRotVector, Vector3.up);
            transform.rotation = rotate;
            animator.SetBool("IsRunning", true);
        }else{
            animator.SetBool("IsRunning", false);
        }
    }

    void Jump(){
        if(Input.GetKey(KeyCode.Space) && jumpTimer + 1f <= Time.time){
            jumped = true;
            jumpTimer = Time.time;
            animator.SetTrigger("Jumped");
        }else if(jumpTimer + 1f <= Time.time && jumped){
            jumped = false;
            
        } 


        if(animator.GetCurrentAnimatorStateInfo(0).IsName("Jumping")){
            if(animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.2f && !addedForce){
                GetComponent<Rigidbody>().AddForce(Vector3.up * jumpPower * Time.deltaTime, ForceMode.Impulse);
                addedForce = true;
            }
        }else{
            addedForce = false;
        }
    }
}



