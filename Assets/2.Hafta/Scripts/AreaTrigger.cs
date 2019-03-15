using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaTrigger : MonoBehaviour
{
    public float scaleRate = 1.2f; // Scale oranı 

    // Trigger metodlarına bir örnek
    // Objenin collider'ı trigger özelliğine sahip olması için isTrigger true yapıldı.
    // editör üzerinde collider componenti altında bu seçeneği görebilirsiniz
    // kod ile de buna erişebiliriz.

    private void OnTriggerEnter(Collider other)
    {
        // Trigger gerçekleşen diğer objenin scale vektörünü vektörümüze atıyoruz.
        Vector3 localScale = other.gameObject.transform.localScale;

        // Eğer bu obje "-" tag'ine sahipse, trigger alanına giren diğer objenin scale değerini düşürüyoruz. 
        if (this.CompareTag("-") && other.CompareTag("Player"))
        {
            other.gameObject.transform.localScale = new Vector3(localScale.x / scaleRate, localScale.y / scaleRate, localScale.z / scaleRate);
        }
        // Eğer bu obje "+" tag'ine sahipse, trigger alanına giren diğer objenin scale değerini arttırıyoruz. 
        else if ( this.CompareTag("+") && other.CompareTag("Player"))
        {
            other.gameObject.transform.localScale = new Vector3(localScale.x * scaleRate, localScale.y * scaleRate, localScale.z * scaleRate);
        }
    }
}
