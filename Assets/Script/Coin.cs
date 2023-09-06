using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision) //collision olu�turduk 2 boyutlu olmas� i�in
    {
        if (collision.gameObject.tag.Equals("Player")) // benim unitydeki player objem olan� buraya yans�tt�m tag�n�da player yapt�m unityden
        {
            playermovement player = collision.gameObject.GetComponent<playermovement>(); //playermoment kodu collision e�itlemesini yapt�k
            player.score += 5; //score artt�rma i�lemi yapt�k 
            gameObject.SetActive(false); //paran�n ekrandan kaybolmas� i�in yaz�lan kodlama 
        }
    }
}
