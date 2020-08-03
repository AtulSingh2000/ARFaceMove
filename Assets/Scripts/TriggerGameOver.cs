using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TriggerGameOver : MonoBehaviour
{
    private UIManager UI;
    public GameObject GameOverPanel;
    public GameObject GameWinPanel;
    // Start is called before the first frame update
    void Start()
    {
        GameOverPanel.SetActive(false);
        Vector3 tmpPos = transform.position;
        tmpPos.x = Mathf.Clamp(tmpPos.x, -1.8f, 1.8f);
        transform.position = tmpPos;

        UI = GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Wall"))
        {
           // Debug.Log("Yes!!");
            GameOverPanel.SetActive(true);
            //Time.timeScale = 0;
           
        }
        if(other.gameObject.CompareTag("Call"))
        {
            GameWinPanel.SetActive(true);
            Debug.Log("Win");
        }
    }

    public void Restart()
    {

        UI.Restar();
    }
}

