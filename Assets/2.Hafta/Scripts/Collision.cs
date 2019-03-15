using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    // Bu script'de Collision mekaniği nedir ona bakıyoruz.
    // Enter-Exit dizayn mantığıyla objelerin çarpışmalarını ve
    // çarpıştıkları sürece birbirleriyle etkileşimlerini kodlayabiliyoruz.
    // OnCollisionEnter - çarpışma anında 
    // OncollisionExit - çarpışma bittiği anda koşan metodlar
    // OncollisionStay metodu ise çarpışma süresince her frame de tekrar çağırılır
    // Bu çağrılar unity MonoBehaviour tarafından yapılır.


    void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<MeshRenderer>().material = this.GetComponent<MeshRenderer>().material;
        }
    }

    void OnCollisionExit(UnityEngine.Collision collision)
    {
        collision.gameObject.transform.position = new Vector3(0, collision.gameObject.transform.position.y, 0);
    }
}
