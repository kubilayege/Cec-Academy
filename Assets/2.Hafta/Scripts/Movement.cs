using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    float horizontal;
    float vertical;
    public float speed = 300f;
    public float jumpSpeed = 300f;
    public float jumpMultiplier = 1.2f;

    public int jumpCount = 1;
    
    public bool jumpReleased = true;
    public bool onAir = false;
    public bool jumpPressed = false;
    public bool isGrounded = false;
    public bool jumpHold = false;


    public Vector3 movementVector; // Hareketin yönünü ve büyüklüğünü belirten vektör
    public Vector3 jumpVector;
    Rigidbody rb; 


    void Start()
    {
        rb = this.GetComponent<Rigidbody>(); //objenin rigidbody componentine referans aldık. 
    }

    void Update()
    {
        // Horizontal ve Vertical özel tanımlardır. Bu tanımları Editör üzerinde Input kısmında unity default olarak yapmıştır. 
        // Bu gibi özel tanımlar yapılarak tuşlara anlam yükleyebiliriz.
        // Horizontal klavyedeki A-D-<-> tuşlarını kapsar. Ayrıca Gamepad ile x eksenindeki hareketleri algılar.
        // Vertical ise aynı şekilde W-S-uparrow-downarrow tuşlarını kapsar. Z ekseni ile ifade edilir.
        horizontal = Input.GetAxis("Horizontal");  
        vertical = Input.GetAxis("Vertical");

        // horizontal ve vertical değerleri alıp hız vektörü oluşturuyoruz. Speed değişkeni bu vektörün büyüklüğünü değiştirebilmemiz için çarpılır
        // Bu şekilde vektörün boyutunu bir değişkene bağlayarak istediğimiz şekle sokabiliriz.
        movementVector = new Vector3(horizontal, 0, vertical) * speed * Time.deltaTime;
        jumpVector = Vector3.up * jumpSpeed * Time.deltaTime;

        // Karakteri Zıplatmak istediğimizde kullanmak için 2 adet bool değişken kullanıyoruz.
        // Bu bool değer true olduğunda zıplamak istiyoruz. Tuşa basılı tuttuğumuz sürece zıplamanın kuvveti artması için 
        // Tuştan çektiğimiz anda başka bir değişken aktif oluyor.
        jumpPressed = Input.GetKeyDown(KeyCode.Space);
        jumpReleased = Input.GetKeyUp(KeyCode.Space);

    }

    void FixedUpdate()
    {
        // Eğer belirlenen zıplama sınırından az zıpladıysa ve zıplama tuşu basıldıysa
        if (jumpPressed && jumpCount > 0)
        {
            jumpHold = true; // JumpRelased bool değeri true olana kadar tuşa basılı tuttuğumuz için bu bool değişkenle o durumu tutuyoruz.
            onAir = true;  // Bu iki koşul sağlanıyorsa havadayız diyebiliriz. Ground objesiyle temas olana kadar true olabilir.

            // Zıplama kuvveti ekleniyor
            // Havadayken tekrar zıplanıldığında hızlıca hız vektörü değişmesi için velocityChange kuvvet modunda ekliyoruz.
            rb.AddForce(jumpVector, ForceMode.VelocityChange);

            // Zıplama sayısı tutuluyor
            jumpCount = jumpCount - 1;
        }

        // Havada ve jump tuşu basılı tutuluyorsa koşullarında iken;
        if (onAir && jumpHold)
        {
            Vector3 accVector = jumpVector * jumpMultiplier;  // yeni bir vektör tanımlıyoruz. Bu vektör zıplama vektörünün katı olucak şekilde.
            rb.AddForce(accVector, ForceMode.Acceleration); // bu tanımladığımız vektörü rigidbody komponentine ekliyoruz. Bu kuvvet ivme kazandırması için ilgili
                                                                                                                                 // forcemode'da ekleniyor.
        }

        // Space tuşunu bıraktığımız halde;
        if (jumpReleased)
        {
            // basılı tuttuğumuzu belirten bool değişkeni false yapıyoruz.
            jumpHold = false;
        }

        // Eğer obje yerdeyse;
        if (isGrounded)
        {
            // Zıplama sayısı default değerine setlenir.
            jumpCount = 1;
        }

        // Hareket vektörünü rigidbody'mize ekliyoruz. Bu satır sayesinde hareket edebiliyoruz.
        
        rb.AddForce(movementVector, ForceMode.Force);
        // rb.MovePosition(movementVector);    
    }


    // Yerde olup olmadığımızı kontrol etmek için Collision Enter-Exit yapısı kullanıyoruz.
    void OnCollisionEnter(UnityEngine.Collision collision)
    {
        // Eğer objemiz bir başka objeyle çarpıştığında bu objenin tag'i ground ise;
        if(collision.gameObject.CompareTag("Ground"))
        {
            // Artık havada değiliz.
            onAir = false;
            // Yerdeyiz.
            isGrounded = true;
        }
    }

    void OnCollisionExit(UnityEngine.Collision collision)
    {
        // Obje Ground tag'li objeyle teması kestiyse; 
        if (collision.gameObject.CompareTag("Ground"))
        {
            // Havadayız
            onAir = true;
            isGrounded = false;
        }
    }
}
