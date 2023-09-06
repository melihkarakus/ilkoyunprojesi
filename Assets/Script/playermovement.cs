using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class playermovement : MonoBehaviour
{
    Rigidbody2D rgb;
    Vector3 velocity; //karakterimizin h�z�n� belirlemek i�in tan�mlad�k
    public Animator animator; // animasyon i�in bir animator olu�turduk
    float speedamount = 8f; // h�z i�in
    float jumpamount = 10f; // z�plamak i�in
    // Start is called before the first frame update
    public int score; // score tan�mlanmas� i�in player moment i�ine tan�mlama yapt�k
    public TextMeshProUGUI PlayerScoreText; // score texte yazd�rmak i�in kulland�k
    void Start()
    {
        rgb = GetComponent<Rigidbody2D>(); // rgb yukarda tan�mlanan� buraya �a��rd�k ve hangi t�rde olmas�n� sa�lad�k
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerScoreText.text = score.ToString(); // oyuncu her alt�n ald���nda text yerine skor yazmas� i�in
        velocity = new Vector3(Input.GetAxis("Horizontal"),0f);
         //bu sa�a ve sola gitmesi i�in tan�mlad�k ve h�z�n� belirledik 
         transform.position += velocity * speedamount * Time.deltaTime;// burada karakterimizin hareketleri ve h�z de�erleri ile bize y�nlendirme sa�l�yor
        animator.SetFloat("speed",Mathf.Abs(Input.GetAxis("Horizontal"))); // animator horizontala e�itlendi�inde hem ko�ma hemde y�r�mesi i�in
        if (Input.GetButtonDown("Jump") && !animator.GetBool("�sjumping"))//e�er butona bas�ld���mda z�playacaksa
        {
            rgb.AddForce(Vector3.up * jumpamount, ForceMode2D.Impulse); // rgb ekle vector3 yukar� �arp yukarda tan�mlanan jumpamount ve tek bir kere bas�m ve tek bas�m
            animator.SetBool("�sjumping", true);
        }

        if (animator.GetBool("�sjumping")&& Mathf.Approximately(rgb.velocity.y,0))
        {
            animator.SetBool("�sjumping", false);
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
    private void OnCollisionEnter2D(Collision2D collision) // bize collision 2d de zemin i�in kullan�lacak bir nesne yapt�k
    {
        if (collision.gameObject.name == "Ground") //e�er zemin e�it ise name 
        {
            animator.SetBool("�sjumping", false); //jump birdaha z�plamas�n
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Ground")
        {
            animator.SetBool("�sjumping", true);
        }
    }
}
