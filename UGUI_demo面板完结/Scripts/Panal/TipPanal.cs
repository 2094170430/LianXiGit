    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;

    public class TipPanal : BasePanal
    {
        public Text text;
        public Button btn;
        public override void init()
        {
            btn.onClick.AddListener(() => { 
            PanalMag.Instance.HindPanal<TipPanal>();
            });
        }
        // Start is called before the first frame update
    
        public void changeText(string str)
        { 
        text.text = str;
        }
    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
}
