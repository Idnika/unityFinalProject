using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculateTargets : MonoBehaviour
{
    public GameObject gameThumbTarget = null;
    public GameObject gameIndexTarget = null;
    public GameObject gameMiddleTarget = null;
    public GameObject gameRingTarget = null;
    public GameObject gamePinkyTarget = null;

    Vector3 basicDistance = Vector3.zero;

    public Vector3[] fingerOriginPos = new Vector3[5];

    KeyManager key_manager = GameObject.Find("KeyManager").GetComponent<KeyManager>();



    // Start is called before the first frame update
    void Start()
    {
        fingerOriginPos[0] = gameThumbTarget.transform.localPosition;
        fingerOriginPos[1] = gameIndexTarget.transform.localPosition;
        fingerOriginPos[2] = gameMiddleTarget.transform.localPosition;
        fingerOriginPos[3] = gameRingTarget.transform.localPosition;
        fingerOriginPos[4] = gamePinkyTarget.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)) { GetDistance(); }

        if (Input.GetKeyDown(KeyCode.B)) {
            GoToOrigin();
            ThumbOnlyInput();
        }

        if (Input.GetKeyDown(KeyCode.C)) {
            GoToOrigin();
            ThumbOnlyInput();
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            GoToOrigin();
            IndexOnlyInput();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            GoToOrigin();
            MiddleOnlyInput();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GoToOrigin();
        }
    }

    void GetDistance()
    {
        Vector3 getDist = gameMiddleTarget.transform.localPosition - fingerOriginPos[2];
        Debug.Log(getDist.ToString("N3"));
    }

    void GoToOrigin()
    {
        gameThumbTarget.transform.localPosition = fingerOriginPos[0];
        gameIndexTarget.transform.localPosition = fingerOriginPos[1];
        gameMiddleTarget.transform.localPosition = fingerOriginPos[2];
        gameRingTarget.transform.localPosition = fingerOriginPos[3];
        gamePinkyTarget.transform.localPosition = fingerOriginPos[4];
    }

    void ThumbOnlyInput()
    {
        Debug.Log("Thumb is pressing");

        // move thumb
        Vector3 thumbMoving = new Vector3(0.017f, -0.017f, 0.004f);
        gameThumbTarget.transform.localPosition += thumbMoving;
        Debug.Log(gameThumbTarget.transform.localPosition.ToString("N3"));

        // move middle finger
        Vector3 disBetFingers = new Vector3(0.2f, 0f, 0f);
        Vector3 getStretch = new Vector3(0f, 0.12f, 0.1f);
        Vector3 temp = new Vector3(gameIndexTarget.transform.position.x, gameMiddleTarget.transform.position.y, gameMiddleTarget.transform.position.z);
        temp += disBetFingers;
        temp += getStretch;
        gameMiddleTarget.transform.position = temp;

        // move index
        gameIndexTarget.transform.position += getStretch;

        // move ring
        temp = new Vector3(gameMiddleTarget.transform.position.x, gameRingTarget.transform.position.y, gameRingTarget.transform.position.z);
        temp += disBetFingers;
        temp += getStretch;
        gameRingTarget.transform.position = temp;

        // move pinky
        temp = new Vector3(gameRingTarget.transform.position.x, gamePinkyTarget.transform.position.y, gamePinkyTarget.transform.position.z);
        temp += disBetFingers;
        temp += getStretch;
        gamePinkyTarget.transform.position = temp;

        // gameRingTarget.transform.position += disBetFingers;
        // gamePinkyTarget.transform.position += disBetFingers;
    }


    void IndexOnlyInput()
    {
        Debug.Log("Index is pressing");


        Vector3 disBetFingers = new Vector3(0.2f, 0f, 0f);
        Vector3 getStretch = new Vector3(0f, 0.12f, 0.1f);
        Vector3 indexMovedDistance = new Vector3(-0.011f, -0.016f, -0.014f);
        Vector3 temp = Vector3.zero;

        // move thumb
        gameThumbTarget.transform.position += getStretch;

        // move index
        gameIndexTarget.transform.localPosition += indexMovedDistance;

        // move middle
        temp = new Vector3(gameIndexTarget.transform.position.x, gameMiddleTarget.transform.position.y, gameMiddleTarget.transform.position.z);
        temp += disBetFingers;
        temp += getStretch;
        gameMiddleTarget.transform.position = temp;

        // move ring
        temp = new Vector3(gameMiddleTarget.transform.position.x, gameRingTarget.transform.position.y, gameRingTarget.transform.position.z);
        temp += disBetFingers;
        temp += getStretch;
        gameRingTarget.transform.position = temp;

        // move pinky
        temp = new Vector3(gameRingTarget.transform.position.x, gamePinkyTarget.transform.position.y, gamePinkyTarget.transform.position.z);
        temp += disBetFingers;
        temp += getStretch;
        gamePinkyTarget.transform.position = temp;
    }

    void MiddleOnlyInput()
    {
        Debug.Log("Index is pressing");


        Vector3 disBetFingers = new Vector3(0.2f, 0f, 0f);
        Vector3 getStretch = new Vector3(0f, 0.12f, 0.1f);
        Vector3 middleMovedDistance = new Vector3(-0.002f, -0.023f, -0.012f);
        Vector3 temp = Vector3.zero;

        // move thumb
        gameThumbTarget.transform.position += getStretch;

        // move middle
        gameMiddleTarget.transform.localPosition += middleMovedDistance;

        // move index
        temp = new Vector3(gameMiddleTarget.transform.position.x, gameIndexTarget.transform.position.y, gameIndexTarget.transform.position.z);
        temp -= disBetFingers;
        temp += getStretch;
        gameIndexTarget.transform.position = temp;

        // move ring
        temp = new Vector3(gameMiddleTarget.transform.position.x, gameRingTarget.transform.position.y, gameRingTarget.transform.position.z);
        temp += disBetFingers;
        temp += getStretch;
        gameRingTarget.transform.position = temp;

        // move pinky
        temp = new Vector3(gameRingTarget.transform.position.x, gamePinkyTarget.transform.position.y, gamePinkyTarget.transform.position.z);
        temp += disBetFingers;
        temp += getStretch;
        gamePinkyTarget.transform.position = temp;
    }
}
