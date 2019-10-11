using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondScript : MonoBehaviour
{
    // Bu scriptte thirdScript'teki d değişkeninin baseScriptteki b değişkenine eşit olması durumunu kontrol ediyoruz.

    public BaseScript baseScriptReferance;

    ThirdScript thirdScriptReferance;
    
    void Start()
    {
        baseScriptReferance = gameObject.GetComponent<BaseScript>();
        thirdScriptReferance = GetComponent<ThirdScript>();
    }
    

    void Update()
    {
        if(thirdScriptReferance.d == baseScriptReferance.b)
        {
            Debug.Log("D ve B eşitlendi.");
            baseScriptReferance.b_ve_d_Esit_Mi = true;
        }
    }
}
