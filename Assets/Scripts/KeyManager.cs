using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManager : MonoBehaviour
{
    public GameObject rightWrist = null;
    public static int i_whiteKeyNumber = 52;
    public static int i_WholeKeyNumber = 88;
    public GameObject[] wholeKeyArr = new GameObject[i_WholeKeyNumber];

    public GameObject[] rightTargetObjects = new GameObject[5];

    public Vector3[] originKeyPos = new Vector3[i_WholeKeyNumber];
    Vector3 curKeyPos = Vector3.zero;

    public bool[] isGettingUp = new bool[i_WholeKeyNumber];

    public Vector3[] onlyGetPosKey = new Vector3[5];

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < i_WholeKeyNumber; i++)
        {
            originKeyPos[i] = wholeKeyArr[i].transform.parent.transform.position;
        }

        for(int i = 0; i < i_WholeKeyNumber; i++)
        {
            isGettingUp[i] = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B)) {
            isGettingUp[10] = true;
            WhiteKeyDown(9);
            goRightWristWithThumb(9);
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            isGettingUp[9] = true;
            WhiteKeyDown(10);
            goRightWristWithThumb(10);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            isGettingUp[9] = true;
            WhiteKeyDown(10);
            goRightWristWithIndex(10);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            WhiteKeyDown(11);
            goRightWristWithMiddle(11);
        }

        for (int i = 0; i < i_WholeKeyNumber; i++)
        {
            if (isGettingUp[i] == true)
            {
                WhiteKeyUp(i);
                if (wholeKeyArr[i].transform.parent.transform.position.y > originKeyPos[i].y)
                {
                    wholeKeyArr[i].transform.parent.transform.position = originKeyPos[i];
                    isGettingUp[i] = false;
                    Debug.Log(isGettingUp[i]);
                }
            }
        }

        // Let's get distance between your wrist and key!
        if (Input.GetKeyDown(KeyCode.K))
        {
            Vector3 distBetKeyThumb = Vector3.zero;

            distBetKeyThumb = wholeKeyArr[9].transform.position - rightWrist.transform.position;

            Debug.Log(distBetKeyThumb.ToString("N3"));
        }
    }

    // check how much key should move
    /*
    void ReturnKeyYDown()
    {
        curKeyPos = whiteKeyArr[9].transform.parent.transform.position;
        Debug.Log(curKeyPos.ToString("N3"));
        Vector3 showYHeight = originKeyPos - curKeyPos;
        Debug.Log(showYHeight.ToString("N3"));
    }
    */
    
    void goRightWristWithThumb(int number)
    {
        Vector3 distBet = new Vector3(-0.253f, -0.297f, 0.811f);
        rightWrist.transform.position = wholeKeyArr[number].transform.position - distBet;
    }

    void goRightWristWithIndex(int number)
    {
        Vector3 distBet = new Vector3(0.020f, -0.280f, 0.981f);
        rightWrist.transform.position = wholeKeyArr[number].transform.position - distBet;
    }

    void goRightWristWithMiddle(int number)
    {
        Vector3 distBet = new Vector3(0.234f, -0.347f, 0.933f);
        rightWrist.transform.position = wholeKeyArr[number].transform.position - distBet;
    }

    void WhiteKeyDown(int number)
    {
        wholeKeyArr[number].transform.parent.transform.position -= new Vector3(0f, 0.051f, 0f);
    }

    void WhiteKeyUp(int number)
    {
        wholeKeyArr[number].transform.parent.transform.position += new Vector3(0, Time.deltaTime * 0.5f, 0);
    }
}
