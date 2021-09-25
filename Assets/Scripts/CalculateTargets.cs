using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculateTargets : MonoBehaviour
{
    public GameObject[] Targets = new GameObject[5];

    /*
    public GameObject gameThumbTarget = null;
    public GameObject gameIndexTarget = null;
    public GameObject gameMiddleTarget = null;
    public GameObject gameRingTarget = null;
    public GameObject gamePinkyTarget = null;
    */

    Vector3 basicDistance = Vector3.zero;

    public Vector3[] fingerOriginPos = new Vector3[5];

    public GameObject rightWrist = null;

    KeyManager key_manager;

    // KeyManager key_manager = GameObject.Find("KeyManager").GetComponent<KeyManager>();

    Vector3 wristOrigin = Vector3.zero;



    // Start is called before the first frame update
    void Start()
    {
        fingerOriginPos[0] = Targets[0].transform.localPosition;
        fingerOriginPos[1] = Targets[1].transform.localPosition;
        fingerOriginPos[2] = Targets[2].transform.localPosition;
        fingerOriginPos[3] = Targets[3].transform.localPosition;
        fingerOriginPos[4] = Targets[4].transform.localPosition;

        key_manager = GameObject.Find("KeyManager").GetComponent<KeyManager>();
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

        if (Input.GetKeyDown(KeyCode.Z))
        {
            Debug.Log("object�� ���� 30��° �ǹ�");
            Debug.Log(key_manager.wholeKeyArr[30].transform.position);
            Debug.Log("object�� ���� 33��° �ǹ�");
            Debug.Log(key_manager.wholeKeyArr[33].transform.position);
            MoveHands(30, -1, -1, -1, 33);
            Debug.Log(Targets[0].transform.position);
            Debug.Log(Targets[4].transform.position);
        }

        // rightWrist�� ���� �ǹ��� ĥ �� �����̴� ���� : (0.058, 0.071, 0.231)

        // �� �� ���� �� rightWrist�� global position : (-1.702, 1.766, 0.564)
    }

    void GetDistance()
    {
        Vector3 getDist = Targets[2].transform.localPosition - fingerOriginPos[2];
        Debug.Log(getDist.ToString("N3"));
    }

    void MoveHands(int thumb, int index, int middle, int ring, int pinky)
    {
        if (thumb >= 52)
        { }
        else
        {
            if (
                (thumb != -1 && index == -1 && middle == -1 && ring == -1 && pinky == -1) ||
                (thumb == -1 && index != -1 && middle == -1 && ring == -1 && pinky == -1) ||
                (thumb == -1 && index == -1 && middle != -1 && ring == -1 && pinky == -1) ||
                (thumb == -1 && index == -1 && middle == -1 && ring != -1 && pinky == -1) ||
                (thumb == -1 && index == -1 && middle == -1 && ring == -1 && pinky != -1))
            {
                // �հ��� �ϳ��� ����ϴ� �� ����
            }
            else if (thumb == -1 && index == -1 && middle == -1 && ring == -1 && pinky == -1)
            {
                // ��ǥ ���� (�ƹ��͵� ġ�� ����)
            }
            else
            {
                Debug.Log("�ϴ� �� ����");
                // ����� ���(�հ��� �� �� �̻��� ������ ��)

                int i_minFinger = minFinger(thumb, index, middle, ring, pinky);
                int i_maxFinger = maxFinger(thumb, index, middle, ring, pinky);

                

                if (i_minFinger == 0) { }

                // �ո��� ��ġ�� �߰� X�� ���ϱ�
                Vector3 getAverage = key_manager.wholeKeyArr[].transform.position + key_manager.wholeKeyArr[].transform.position;
                getAverage = getAverage / 2;
                Debug.Log("������������޴µ�...����");
                Debug.Log(getAverage);

                rightWrist.transform.position = new Vector3(getAverage.x, 1.766f, 0.564f);


                Targets[i_minFinger].transform.position = key_manager.wholeKeyArr[i_minFinger].transform.position;
                Targets[i_maxFinger].transform.position = key_manager.wholeKeyArr[i_maxFinger].transform.position;
            }
        }


    }

    // �ټ� �հ��� �� ���� ���� (Ȱ��ȭ��) ��ȣ ���ϱ�
    int minFinger(int thumb, int index, int middle, int ring, int pinky)
    {
        int[] hands = { thumb, index, middle, ring, pinky };
        for (int i = 0; i < 5; i++)
        {
            if (hands[i] != -1)
            {
                return i;
            }
        }

        Debug.Log("�հ��� �Է°��� �̻���(minFinger�� ������ ������)");
        return -99;
    }

    // �ټ� �հ��� �� ���� ū (Ȱ��ȭ��) ��ȣ ���ϱ�
    int maxFinger(int thumb, int index, int middle, int ring, int pinky)
    {
        int[] hands = { thumb, index, middle, ring, pinky };
        for (int i = 4; i >= 0; i--)
        {
            if (hands[i] != -1)
            {
                return i;
            }
        }

        Debug.Log("�հ��� �Է°��� �̻���(maxFinger�� ������ ������)");
        return -99;
    }

    void GoToOrigin()
    {
        Targets[0].transform.localPosition = fingerOriginPos[0];
        Targets[1].transform.localPosition = fingerOriginPos[1];
        Targets[2].transform.localPosition = fingerOriginPos[2];
        Targets[3].transform.localPosition = fingerOriginPos[3];
        Targets[4].transform.localPosition = fingerOriginPos[4];
    }

    void ThumbOnlyInput()
    {
        Debug.Log("Thumb is pressing");

        // move thumb
        Vector3 thumbMoving = new Vector3(0.017f, -0.017f, 0.004f);
        Targets[0].transform.localPosition += thumbMoving;
        Debug.Log(Targets[0].transform.localPosition.ToString("N3"));

        // move middle finger
        Vector3 disBetFingers = new Vector3(0.2f, 0f, 0f);
        Vector3 getStretch = new Vector3(0f, 0.12f, 0.1f);
        Vector3 temp = new Vector3(Targets[1].transform.position.x, Targets[2].transform.position.y, Targets[2].transform.position.z);
        temp += disBetFingers;
        temp += getStretch;
        Targets[2].transform.position = temp;

        // move index
        Targets[1].transform.position += getStretch;

        // move ring
        temp = new Vector3(Targets[2].transform.position.x, Targets[3].transform.position.y, Targets[3].transform.position.z);
        temp += disBetFingers;
        temp += getStretch;
        Targets[3].transform.position = temp;

        // move pinky
        temp = new Vector3(Targets[3].transform.position.x, Targets[4].transform.position.y, Targets[4].transform.position.z);
        temp += disBetFingers;
        temp += getStretch;
        Targets[4].transform.position = temp;

        // Targets[3].transform.position += disBetFingers;
        // Targets[4].transform.position += disBetFingers;
    }


    void IndexOnlyInput()
    {
        Debug.Log("Index is pressing");


        Vector3 disBetFingers = new Vector3(0.2f, 0f, 0f);
        Vector3 getStretch = new Vector3(0f, 0.12f, 0.1f);
        Vector3 indexMovedDistance = new Vector3(-0.011f, -0.016f, -0.014f);
        Vector3 temp = Vector3.zero;

        // move thumb
        Targets[0].transform.position += getStretch;

        // move index
        Targets[1].transform.localPosition += indexMovedDistance;

        // move middle
        temp = new Vector3(Targets[1].transform.position.x, Targets[2].transform.position.y, Targets[2].transform.position.z);
        temp += disBetFingers;
        temp += getStretch;
        Targets[2].transform.position = temp;

        // move ring
        temp = new Vector3(Targets[2].transform.position.x, Targets[3].transform.position.y, Targets[3].transform.position.z);
        temp += disBetFingers;
        temp += getStretch;
        Targets[3].transform.position = temp;

        // move pinky
        temp = new Vector3(Targets[3].transform.position.x, Targets[4].transform.position.y, Targets[4].transform.position.z);
        temp += disBetFingers;
        temp += getStretch;
        Targets[4].transform.position = temp;
    }

    void MiddleOnlyInput()
    {
        Debug.Log("Index is pressing");


        Vector3 disBetFingers = new Vector3(0.2f, 0f, 0f);
        Vector3 getStretch = new Vector3(0f, 0.12f, 0.1f);
        Vector3 middleMovedDistance = new Vector3(-0.002f, -0.023f, -0.012f);
        Vector3 temp = Vector3.zero;

        // move thumb
        Targets[0].transform.position += getStretch;

        // move middle
        Targets[2].transform.localPosition += middleMovedDistance;

        // move index
        temp = new Vector3(Targets[2].transform.position.x, Targets[1].transform.position.y, Targets[1].transform.position.z);
        temp -= disBetFingers;
        temp += getStretch;
        Targets[1].transform.position = temp;

        // move ring
        temp = new Vector3(Targets[2].transform.position.x, Targets[3].transform.position.y, Targets[3].transform.position.z);
        temp += disBetFingers;
        temp += getStretch;
        Targets[3].transform.position = temp;

        // move pinky
        temp = new Vector3(Targets[3].transform.position.x, Targets[4].transform.position.y, Targets[4].transform.position.z);
        temp += disBetFingers;
        temp += getStretch;
        Targets[4].transform.position = temp;
    }
}
