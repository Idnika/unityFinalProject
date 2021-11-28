using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;

public class SheetReader : MonoBehaviour
{
    int[,] inputText = new int[50000, 7];
    int whyNot = 1;

    void Awake()
    {
        Debug.Log("Awake 진입");
        for (int i = 0; i < 50000; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                inputText[i, j] = -100;
                // Debug.Log(inputText[i, j]);
            }
            // Debug.Log("살려주세요");
        }

        string filePath = @"C:\Users\Jaehee Choi\Desktop\SaveMeIK\Assets\InputText\SimpleTest1.txt";
        ReadFile(filePath);
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (whyNot == 1)
        {
            for (int i = 0; i < 50; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    inputText[i, j] = -100;
                    Debug.Log(inputText[i, j]);
                }
                Debug.Log("살려주세요");
            }

            string filePath = @"C:\Users\Jaehee Choi\Desktop\SaveMeIK\Assets\InputText\SimpleTest1.txt";
            ReadFile(filePath);

            Debug.Log("Check 되었습니다.");

            whyNot = 0;
        }
        */
    }

    void ReadFile(string path)
    {
        StreamReader sr = File.OpenText(path);
        string input = "";
        // 파일을 줄단위로 읽는다.

        Debug.Log("ReadFile 진입");
        for(int i = 0; i < 50000; i++)
        {
            for(int j = 0; j < 7; j++)
            {
                input = sr.ReadLine();
                if (input == null) { break; }

                inputText[i, j] = int.Parse(input);
            }
        }
        sr.Close(); // 파일 읽기후 반드시 해준다.
    }
}
