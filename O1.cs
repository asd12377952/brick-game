using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class O1 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject gameover;
    public Button again;
    public Button exit;

    void Start()
    {
        again.onClick.AddListener(ag);
        exit.onClick.AddListener(ex);
    }
    void ag(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    void ex(){
        Application.Quit();
    }
}
