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
        Debug.Log("Awake ����");
        for (int i = 0; i < 50000; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                inputText[i, j] = -100;
                // Debug.Log(inputText[i, j]);
            }
            // Debug.Log("����ּ���");
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
                Debug.Log("����ּ���");
            }

            string filePath = @"C:\Users\Jaehee Choi\Desktop\SaveMeIK\Assets\InputText\SimpleTest1.txt";
            ReadFile(filePath);

            Debug.Log("Check �Ǿ����ϴ�.");

            whyNot = 0;
        }
        */
    }

    void ReadFile(string path)
    {
        StreamReader sr = File.OpenText(path);
        string input = "";
        // ������ �ٴ����� �д´�.

        Debug.Log("ReadFile ����");
        for(int i = 0; i < 50000; i++)
        {
            for(int j = 0; j < 7; j++)
            {
                input = sr.ReadLine();
                if (input == null) { break; }

                inputText[i, j] = int.Parse(input);
            }
        }
        sr.Close(); // ���� �б��� �ݵ�� ���ش�.
    }
}
