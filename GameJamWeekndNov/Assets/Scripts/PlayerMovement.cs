using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   [SerializeField] float Speed = 2f; 
   Transform player;

     void Start()
    {
        player = GetComponent<Transform>();
    }
    public void Move()
    {
        float x =  Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(x, 0, z).normalized * Speed * Time.deltaTime;  
        //removing the .normalized would make the speed double time faster. It also adds a little delay when stopping.

        player.Translate(movement);
    }    
}
