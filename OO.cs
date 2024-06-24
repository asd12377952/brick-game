using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEngine.Rendering;

public class OO : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject down0;
    public GameObject down2;
    public GameObject gameover;
    private Vector2 startPos;
    private Vector2 endPos;
    private float tt=0;
    private bool good=true;
    private GameObject[] obj1;
    void Start()
    {
        gameover.gameObject.SetActive(false);
        Time.timeScale=1;
        obj1 = GameObject.FindGameObjectsWithTag("1");
    }

    // Update is called once per frame
    void Update()
    {
        tt+=Time.deltaTime;
        if(Input.touchCount > 0 && tt>=0.5){
            Touch touch = Input.GetTouch(0);
            if(touch.phase==TouchPhase.Began){
                startPos = touch.position;
            }
            else if(touch.phase == TouchPhase.Ended){
                endPos = touch.position- startPos;
                move();
            }
        }
        if(down0.transform.position.y > down2.transform.position.y){
            good=false;
        }
        else{good=true;}
    }
    void del()
    {
        if(obj1.Length!=0){
            int pos = Random.Range(0,obj1.Length);
            obj1[pos].SetActive(false);
            obj1 = GameObject.FindGameObjectsWithTag("1");
        }
        
    }
    void OnTriggerStay (Collider other){
        if(other.tag=="over"){
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    void OnCollisionStay (Collision other){
    	if(other.collider.tag =="win"&& down0.transform.position.y<down2.transform.position.y){
            Time.timeScale=0;
            gameover.gameObject.SetActive(true);
    	}
    }
    void move()
    {
        if(good){
            if(endPos.x<=-500 && endPos.x<endPos.y){
                this.gameObject.transform.position +=new Vector3(-3,0f,0);
                this.gameObject.transform.localEulerAngles =new Vector3(0,90,0);
                tt=0;
                del();
            }
            else if(endPos.x>=500 && endPos.x>endPos.y){
                this.gameObject.transform.position +=new Vector3(3,0f,0);
                this.gameObject.transform.localEulerAngles =new Vector3(0,90,0);
                tt=0;
                del();
            }
            else if(endPos.y>=500 && endPos.x<endPos.y){
                this.gameObject.transform.position +=new Vector3(0,0f,3);
                this.gameObject.transform.localEulerAngles =new Vector3(0,0,0);
                tt=0;
                del();
            }
            else if(endPos.y<=-500 && endPos.x>endPos.y){
                this.gameObject.transform.position +=new Vector3(0,0f,-3);
                this.gameObject.transform.localEulerAngles =new Vector3(0,0,0);
                tt=0;
                del();
            }
        }
        else{
            if(down0.transform.position.x > down2.transform.position.x && down0.transform.position.z < down2.transform.position.z){
                if(endPos.x<=-500 && endPos.x<endPos.y){
                    this.gameObject.transform.position +=new Vector3(-3,2f,0);
                    this.gameObject.transform.localEulerAngles =new Vector3(90,0,0);
                    tt=0;
                    del();
                }
                else if(endPos.x>=500 && endPos.x>endPos.y){
                    this.gameObject.transform.position +=new Vector3(3,2f,0);
                    this.gameObject.transform.localEulerAngles =new Vector3(90,0,0);
                    tt=0;
                    del();
                }
                else if(endPos.y>=500 && endPos.x<endPos.y){
                    this.gameObject.transform.position +=new Vector3(0,0.5f,2);
                    tt=0;
                    del();
                }
                else if(endPos.y<=-500 && endPos.x>endPos.y){
                    this.gameObject.transform.position +=new Vector3(0,0.5f,-2);
                    tt=0;
                    del();
                }
            }
            else{
                if(endPos.x<=-500 && endPos.x<endPos.y){
                    this.gameObject.transform.position +=new Vector3(-2,0.5f,0);
                    tt=0;
                    del();
                }
                else if(endPos.x>=500 && endPos.x>endPos.y){
                    this.gameObject.transform.position +=new Vector3(2,0.5f,0);
                    tt=0;
                    del();
                }
                else if(endPos.y>=500 && endPos.x<endPos.y){
                    this.gameObject.transform.position +=new Vector3(0,2f,3);
                    this.gameObject.transform.localEulerAngles =new Vector3(90,0,0);
                    tt=0;
                    del();
                }
                else if(endPos.y<=-500 && endPos.x>endPos.y){
                    this.gameObject.transform.position +=new Vector3(0,2f,-3);
                    this.gameObject.transform.localEulerAngles =new Vector3(90,0,0);
                    tt=0;
                    del();
                }
            }
        }
    }
}
