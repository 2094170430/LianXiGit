using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lesson14 : MonoBehaviour
{
    public Light Light;
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<Dropdown>().onValueChanged.AddListener((a) => {
            if (a == 0)
            { 
            Light.gameObject.SetActive(true);
            }
            else 
            {
                Light.gameObject.SetActive(false);
            }

        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
