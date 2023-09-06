using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class playermovement : MonoBehaviour
{
    Rigidbody2D rgb;
    Vector3 velocity; //karakterimizin hýzýný belirlemek için tanýmladýk
    public Animator animator; // animasyon için bir animator oluþturduk
    float speedamount = 8f; // hýz için
    float jumpamount = 10f; // zýplamak için
    // Start is called before the first frame update
    public int score; // score tanýmlanmasý için player moment içine tanýmlama yaptýk
    public TextMeshProUGUI PlayerScoreText; // score texte yazdýrmak için kullandýk
    void Start()
    {
        rgb = GetComponent<Rigidbody2D>(); // rgb yukarda tanýmlananý buraya çaðýrdýk ve hangi türde olmasýný saðladýk
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerScoreText.text = score.ToString(); // oyuncu her altýn aldýðýnda text yerine skor yazmasý için
        velocity = new Vector3(Input.GetAxis("Horizontal"),0f);
         //bu saða ve sola gitmesi için tanýmladýk ve hýzýný belirledik 
         transform.position += velocity * speedamount * Time.deltaTime;// burada karakterimizin hareketleri ve hýz deðerleri ile bize yönlendirme saðlýyor
        animator.SetFloat("speed",Mathf.Abs(Input.GetAxis("Horizontal"))); // animator horizontala eþitlendiðinde hem koþma hemde yürümesi için
        if (Input.GetButtonDown("Jump") && !animator.GetBool("ýsjumping"))//eðer butona basýldýðýmda zýplayacaksa
        {
            rgb.AddForce(Vector3.up * jumpamount, ForceMode2D.Impulse); // rgb ekle vector3 yukarý çarp yukarda tanýmlanan jumpamount ve tek bir kere basým ve tek basým
            animator.SetBool("ýsjumping", true);
        }

        if (animator.GetBool("ýsjumping")&& Mathf.Approximately(rgb.velocity.y,0))
        {
            animator.SetBool("ýsjumping", false);
        }

        if (Input.GetAxisRaw("Horizontal")==-1)
        {
            transform.rotation = Quaternion.Euler(0f, 180, 0f);
        }
        else if (Input.GetAxisRaw("Horizontal")==1)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision) // bize collision 2d de zemin için kullanýlacak bir nesne yaptýk
    {
        if (collision.gameObject.name == "Ground") //eðer zemin eþit ise name 
        {
            animator.SetBool("ýsjumping", false); //jump birdaha zýplamasýn
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Ground")
        {
            animator.SetBool("ýsjumping", true);
        }
    }
}
