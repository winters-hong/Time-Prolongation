using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneVisitor : MonoBehaviour
{
    private int selection;
    private float totalTime;
    // Start is called before the first frame update
    void Start()
    {
        selection = 1;
        totalTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        totalTime+=Time.deltaTime;
        if(totalTime>=20.0f)
        {
            VisitScene();
            totalTime = 0.0f;
        }
    }

    public void VisitScene()
    {
        selection = Random.Range(0,5);
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        if(selection == sceneIndex)
        {
            SceneManager.LoadScene(sceneIndex+1);
        }
        else
        {
            switch(selection)
            {
                case 0: SceneManager.LoadScene("Scene1"); break;
                case 1: SceneManager.LoadScene("Scene2"); break;
                case 2: SceneManager.LoadScene("Scene3"); break;
                case 3: SceneManager.LoadScene("Scene4"); break;
                case 4: SceneManager.LoadScene("Scene5"); break;
                default: SceneManager.LoadScene(sceneIndex+1); break;
            }
        }

    }
}
