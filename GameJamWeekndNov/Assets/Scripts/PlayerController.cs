using UnityEngine;

public class PlayerController : MonoBehaviour
{

    PlayerMovement move;

    // Start is called before the first frame update
    void Start()
    {
        move = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        move.Move();
    }
}
