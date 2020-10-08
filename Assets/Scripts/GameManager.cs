using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public static int IntermissionSceneIdx = 1; // if this changes also update this value

    public static int Score { get; set;  }

    private void Awake()
    {
        Score = 0;
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        // transition to first minigame
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void LoadIntermissionScene()
    {
        SceneManager.LoadScene(IntermissionSceneIdx);
    }
}
