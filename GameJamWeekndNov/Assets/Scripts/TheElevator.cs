using UnityEngine;
using UnityEngine.SceneManagement;

public class TheElevator : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] MeshRenderer AnimHero;
    [SerializeField] MeshRenderer HeroMesh;
    [SerializeField] PlayerMovement hero;
    [SerializeField] CameraFollow target;
    [SerializeField] string SceneName;
    [SerializeField] float changeTime;
    private bool end = false;

    
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            end = true;
            AnimHero.enabled = true;
            HeroMesh.enabled = false;
            target.TargetTransform = AnimHero.transform;
            target.damp = 0f;
            target.offset = new Vector3(0, -2, +7);
            hero.enabled = false;
            animator.SetBool("End", true);
        }
    }

    void Update()
    {
         if(end)
         changeTime -= Time.deltaTime;

        if(changeTime <= 0)
        SceneManager.LoadScene(SceneName);
    }

}
