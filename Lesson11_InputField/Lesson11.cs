using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lesson11 : MonoBehaviour
{
    InputField i;
    // Start is called before the first frame update
    void Start()
    {
        i = GetComponent<InputField>();
        i.onEndEdit.AddListener(change2);
    }
    public void change(string a)
    {
        print("内容改变现在是"+a);
    }
     void change2(string b)
    {
        print("代码内容改变现在是" + b);
    }
    // Update is called once per frame
    void Update()
    {
    }
}
