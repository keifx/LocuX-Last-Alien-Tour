using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ManagerScr : MonoBehaviour
{
    public GameObject cube;
    public GameObject fallCube;
    public GameObject pivotCamera;
    public GameObject yHeightReference;

    public int squareSize;
    private float timerFallingCube;
    public float timerMultiplier;
    private Quaternion targetRotCamera;
    public int sumbuX;
    public int sumbuY;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI deathScoreText;

    void Start()
    {
        //squareSize = 4;
        //sumbuX = 35;
        //sumbuY = 45;

        GenerateBaseCube(squareSize, cube);
    }

    //all here are update per frame
    // so it won't stack
    private void FixedUpdate()
    {
        targetRotCamera = Quaternion.Euler(sumbuX, sumbuY, 0);
        pivotCamera.transform.localRotation = Quaternion.Slerp(pivotCamera.transform.localRotation, targetRotCamera, 15 * Time.deltaTime);
    }

    void Update()
    {
        //camera falling frequency
        if(timerFallingCube > 0)
        {
            timerFallingCube -= Time.deltaTime;
        }
        else
        {
            SpawnFallCube();
            timerFallingCube = 0.5f;
        }

        //camera Y lock the to the character character jump
        if (Input.GetKeyDown(KeyCode.RightArrow))
            sumbuY += 90;

        if (Input.GetKeyDown(KeyCode.LeftArrow))
            sumbuY -= 90;

        //score update
        if (int.Parse(scoreText.text) < Mathf.Round(yHeightReference.transform.localPosition.y))
        {
            scoreText.text = Mathf.Round(yHeightReference.transform.localPosition.y).ToString();
        }
        deathScoreText.text = scoreText.text;
    }

    private void GenerateBaseCube(int size, GameObject g)
    {
        //generate base plane
        //j for x
        //i for z
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                var cubeFloor = Instantiate(g, new Vector3(j, 0, i), Quaternion.identity);
            }
        }
    }
    
    public void SpawnFallCube()
    { 
        var spawnedCube = Instantiate(fallCube, new Vector3(Random.Range(0,squareSize), 100, Random.Range(0, squareSize)), Quaternion.identity);
    }
}
