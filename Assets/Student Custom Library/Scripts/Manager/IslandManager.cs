using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IslandManager : MonoBehaviour
{
    public static IslandManager Instance;
    public string destination;
    // Start is called before the first frame update
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        else if (Instance != this)
        {
            Destroy(this);
        }
    }

    public void SwitchLevels(string destination)
    {
        SceneManager.LoadScene(destination);
    }
}