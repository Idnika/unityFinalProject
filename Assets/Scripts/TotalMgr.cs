using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotalMgr : MonoBehaviour
{
    KeyManager key_manager;
    CalculateTargets calculate_targets;
    SheetReader sheet_reader;


    // Start is called before the first frame update
    void Start()
    {
        key_manager = GameObject.Find("KeyManager").GetComponent<KeyManager>();
        calculate_targets = GameObject.Find("CalculateTargets").GetComponent<CalculateTargets>();
        sheet_reader = GameObject.Find("SheetReaderMgr").GetComponent<SheetReader>();
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < 50000; i++) // 악보를 시작해봅시다
        {
            if (sheet_reader.inputText[i, 0] != -100) // 첫 숫자가 -100으로 시작하면 탈출
            {
                int[] get_finger = new int[5];
                for (int k = 0; k < 5; k++)
                {
                    get_finger[k] = sheet_reader.inputText[i, k];
                }

                calculate_targets.MoveHands(get_finger[0], get_finger[1], get_finger[2], get_finger[3], get_finger[4]);
            }
            else { break;  }
        }
    }

    // Get single finger move
    void SingleFingerMove()
    { }
}
