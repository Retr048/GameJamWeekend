using UnityEngine;

public class CircuitPanel : MonoBehaviour
{
    public Light light;
    
    void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player" && Input.GetKeyDown(KeyCode.E))
        {
            light.enabled = true;
        }
            
    }


}
