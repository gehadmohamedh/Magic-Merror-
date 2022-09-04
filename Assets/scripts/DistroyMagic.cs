using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DistroyMagic : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject lightLamp;
    bool discoverd = false ;
    private void Start()
    {  
        
    }
    private void OnTriggerEnter(Collider other)
    {
     
     
        if (other.gameObject.tag == "Me" && ! discoverd)
        {
           Debug.Log("bordaaaaa");
         
            GameObject levelmanager = GameObject.Find("LevelManager");
            Instantiate(lightLamp, transform.position, transform.rotation);
            levelmanager.GetComponent<levelManager>().curntlamps++; 
            this.gameObject.GetComponent<AudioSource>().Play();
            discoverd = true;
            GameObject.Find("lampscount").GetComponent<Text>().text = ((GameManager.Instance.levels[GameManager.Instance.currentLevel].NumOfLamps)-( levelmanager.GetComponent<levelManager>().curntlamps)).ToString();
            Destroy(this.gameObject , 5);
        }
    }
}
