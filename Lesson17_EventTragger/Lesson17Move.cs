using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Lesson17Move : MonoBehaviour
{
    public GameObject Object;
    public float speed= 10;
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(false);
    }
    public void Forward(BaseEventData  b)
    {
        Object.transform.Translate(Vector3.forward*speed*Time.deltaTime);
    
    }
    public void Later(BaseEventData b)
    {

        Object.transform.Translate(-Vector3.forward * speed * Time.deltaTime);

    }
    public void Left(BaseEventData b)
    {

        Object.transform.Translate(Vector3.left * speed * Time.deltaTime);

    }
    public void Right(BaseEventData b)
    {
        Object.transform.Translate(Vector3.right * speed * Time.deltaTime);


    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
