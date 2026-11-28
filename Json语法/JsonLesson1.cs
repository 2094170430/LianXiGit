using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
[System.Serializable]
public class Student
{
    public int age;
    public string name;
    public Student(int a,string n)
    { 
    age =a;
    name = n;
    }
}
public class MrMeng
{
    public int age;
    public string name;
    public float weight;
    public double weight2;
    public int[] ints;
    public List<int> ids;
    public List<Student> students;

    public Dictionary<int,int> counts;
    public Dictionary<string, string> counts2;

    public Student xiaoming;
    [SerializeField]
    private int a = 3;
    [SerializeField]
    protected int b = 1;


}
public class JsonLesson1 : MonoBehaviour
{
    // Start is called before the first frame update
    MrMeng m =new MrMeng();
    private void Awake()
    {
        m.age = 1;
        m.name = "mengyuan";
        m.weight = 1.2f;
        m.weight2=1.21;
        m.ints = new int[] {1,2 };
        m.ids = new List<int>(){1,2};
        m.students = new List<Student>(){new Student(1,"saobi"),new Student(2,"jiba") };
        m.counts = new Dictionary<int, int>() { {1,2 },{3,4 } };
        m.counts2 = new Dictionary<string, string>() { {"meng","x" } };
        m.xiaoming = new Student(1,"yindi");
        
        File.WriteAllText(Application.persistentDataPath + "/Test.json", "孟塬的库");//写数据
        print(Application.persistentDataPath);
        string i = File.ReadAllText(Application.persistentDataPath + "/Test.json");//读数据
        print(i);
        //json序列化
        string j = JsonUtility.ToJson(m);
        File.WriteAllText(Application.persistentDataPath + "/Test2.json", j);//写数据












    }

}
