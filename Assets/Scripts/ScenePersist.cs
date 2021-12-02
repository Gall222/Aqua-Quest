using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenePersist : MonoBehaviour
{
    int startingSceneIndex;
    private void Awake()
    {
        int numScenePersist = FindObjectsOfType<ScenePersist>().Length;
        if (numScenePersist > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        startingSceneIndex = SceneManager.GetActiveScene().buildIndex;

    }
    public void DestroyOldObjects()
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        //var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        //if (startingSceneIndex != currentSceneIndex)
        //{
        //    Debug.Log("Destroy update");
        //    Destroy(gameObject);
        //}
    }
}
