using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ManagerScr : MonoBehaviour
{
    public GameObject cube;
    public GameObject fallCube;
    public GameObject pivotCamera;

    public GameObject yHeight;
    public int pengali;
    public float timer;
    public Quaternion targetRotCamera ;
    public int sumbuY;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI deathScoreText;
    void Start()
    {
        for (int i = 0; i < pengali; i++)
        {

            for (int j = 0; j < pengali; j++)
            {
                var cubeFloor = Instantiate(cube, new Vector3(j, 0, i), Quaternion.identity);
            }
        }
        sumbuY = 45;
    }

    void Update()
    {
        if(timer > 0)
        {
            
            timer -= Time.deltaTime;
        }
        else
        {
            //Function
            SpawnFallCube();
            timer = 0.5f;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
            sumbuY += 90;

        if (Input.GetKeyDown(KeyCode.LeftArrow))
            sumbuY -= 90;
        targetRotCamera = Quaternion.Euler(30, sumbuY, 0);
        pivotCamera.transform.localRotation = Quaternion.Slerp(pivotCamera.transform.localRotation, targetRotCamera, 15 * Time.deltaTime);

        if (int.Parse(scoreText.text) < Mathf.Round(yHeight.transform.localPosition.y))
        {
            scoreText.text = Mathf.Round(yHeight.transform.localPosition.y).ToString();
        }
        deathScoreText.text = scoreText.text;
    }
    
    public void SpawnFallCube()
    { 
        var spawnedCube = Instantiate(fallCube, new Vector3(Random.Range(0,pengali), 100, Random.Range(0, pengali)), Quaternion.identity);
    }
}
