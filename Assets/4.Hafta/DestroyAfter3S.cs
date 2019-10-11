using System;
using UnityEngine;

public class DestroyAfter3S : MonoBehaviour
{
  //Referans Tipleri   Referans değişkeni
    Transform            buObjeTransformu;  
    MeshRenderer         buObjeRenderer;
    Collider             buObjeCollider;
    GameObject           adam;


    // Start is called before the first frame update
    void Start()
    {
        adam = this.gameObject;
        buObjeTransformu = adam.transform;                  //referans olarak transform alma


        buObjeTransformu = adam.GetComponent<Transform>();  //referans olarak transform alma 
        
    }


    void Update()
    {
        GitveYokOl(3,5,7,3f,2.5f);
    }

    private void GitveYokOl(int xe,int ye,int ze, float timeToDie, float movespeed)
    {
        if (adam.transform.position.x < xe)
        {
            adam.transform.Translate(movespeed*Time.deltaTime, 0, 0);
        }
        else if (adam.transform.position.y < ye)
        {
            adam.transform.Translate(0, movespeed * Time.deltaTime, 0);
        }
        else if (adam.transform.position.z < ze)
        {
            adam.transform.Translate(0, 0, movespeed * Time.deltaTime);
        }
        else
        {
            Destroy(adam, timeToDie);
        }
    }
}
