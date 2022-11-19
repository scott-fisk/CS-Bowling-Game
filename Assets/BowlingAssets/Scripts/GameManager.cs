using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public GameObject ball;
    public int score = 0;
    
    GameObject[] pins;
    public Text scoreUI;

    Vector3[] positions;

    // Start is called before the first frame update
    void Start()
    {
        pins = GameObject.FindGameObjectsWithTag("Pin");
        positions = new Vector3[pins.Length];

        for(int i = 0; i < pins.Length; i++)
        {
            positions[i] = pins[i].transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        MoveBall();

        if (Input.GetKeyDown(KeyCode.Space) || ball.transform.position.y < 0.2)
        {
            CountPinsDown();
        }  
    }

    void MoveBall()
    {
        if(ball.transform.position.z >= 36.8)
        {
            Vector3 position = ball.transform.position;
            position -= Vector3.right * Input.GetAxis("Horizontal") * Time.deltaTime;
            position.x = Mathf.Clamp(position.x, 9.07f, 9.74f);
            ball.transform.position = position;
        }
       
    }

    void CountPinsDown()
    {
        for(int i = 0; i < pins.Length; i++)
        {
            if (pins[i].transform.eulerAngles.z > 1 && pins[i].transform.eulerAngles.z < 355 && pins[i].activeSelf)
            {
                score++;
                pins[i].SetActive(false);
            }
        }

        scoreUI.text = score.ToString();
    }

    public void ResetTheGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
