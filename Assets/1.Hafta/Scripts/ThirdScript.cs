using System.Collections.Generic;
using UnityEngine;

public class ThirdScript : MonoBehaviour
{
    // Bu scriptte BaseScript'teki b değişkenini sürekli arttırıyoruz. 
    // d değişkeni 0 dan başlayarak b değişkenine yetişmeye çalışıyor. 
    // b ve d değişkeni eşitlendiğinde işlem yapmayı bırakıyoruz.

    public BaseScript baseScriptReferance_2; //Referansı editörde sürükleyip bırakarak yaptık. Public tanımladığımız için bu şekilde yapabildik.

    

    public int d = 0;

    Dictionary<int, float> sözlük;

    Dictionary<string, string> adsoyad;
    void Update()
    {
     

        int a = Random.Range(1, 5);
        if (baseScriptReferance_2.b != d)
        {
            if (d == baseScriptReferance_2.b)
            {
                return; // işlem yapmadan update metodundan çıkıyoruz. Eşitlik sağlandığı andan itibaren.
            }

            baseScriptReferance_2.b += 1;
            d += 2;

            Debug.Log("d = "+ d + " b = " + baseScriptReferance_2.b); //konsolda değişimi görebiliriz.
        }

          
    }

   
}
