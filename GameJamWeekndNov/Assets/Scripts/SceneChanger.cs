using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneChanger : MonoBehaviour
{
    public float changeTime;
    public string SceneName;
    [SerializeField] AudioSource clip;

  

    // Update is called once per frame
private void Update()
{
        changeTime -= Time.deltaTime;

        if(changeTime >= 5)
        clip.Play();

        if(changeTime <= 0)
        SceneManager.LoadScene(SceneName);
}


}
