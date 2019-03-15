using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseScript : MonoBehaviour
{

    //private int a = 10;   //Başka scriptler bu değişkene erişemiyor. Editörde de gözükmüyor.
    public int b = 20;   // Başka scriptler bu değişkene erişebiliyor ve değerini bu objenin instance'ı için değiştirebiliyor. Editörde de gözüküyor ve değiştirilebiliyoruz.
    public bool b_ve_d_Esit_Mi = false;

    public Material red;
    public Material green;
    MeshRenderer mesh;


    childScript child;  // child objesindeki childScript componentine erişmek için kullandığımız değişken. 


    void Start()
    {
        //a = 20; //başlangıçta değiştirebiliyoruz.

        mesh = this.GetComponent<MeshRenderer>(); //player objesinin MeshRenderer componentinin referans ataması.


        child = this.GetComponentInChildren<childScript>(); //Player'ın altındaki 'child' adlı objedeki childScript componentinin referans ataması.
        child.t = true; //childScriptinin t değişkenini değiştirilmesi.
    }

    void Update()
    {
        // Oyun başladıktan sonra K ve Y tuşları ile Player objesinin Mesh'inin materyalini değiştiriyoruz.
        if (Input.GetKeyDown(KeyCode.K))
        {
            mesh.material = red;
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            mesh.material = green;
        }

        if(b_ve_d_Esit_Mi)
        {
            Debug.Log("b ve d Eşitlenmiş");  // thirdScript'te yapılan değişiklikler sonucu SecondScript bu değişkenlerin eşitlendiğini doğrulayıp baseScript'e haber veriyor.
        }
    }
}
