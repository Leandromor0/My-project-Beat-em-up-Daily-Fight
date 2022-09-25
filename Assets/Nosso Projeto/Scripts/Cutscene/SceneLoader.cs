using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField]
    private string sceneName;
    [SerializeField]
    private float changeTime;
    
    // Update is called once per frame
    void Update()
    {
        changeTime -= Time.deltaTime;
        if(changeTime < 0)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
