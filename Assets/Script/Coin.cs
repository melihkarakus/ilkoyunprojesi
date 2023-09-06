using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision) //collision oluþturduk 2 boyutlu olmasý için
    {
        if (collision.gameObject.tag.Equals("Player")) // benim unitydeki player objem olaný buraya yansýttým tagýnýda player yaptým unityden
        {
            playermovement player = collision.gameObject.GetComponent<playermovement>(); //playermoment kodu collision eþitlemesini yaptýk
            player.score += 5; //score arttýrma iþlemi yaptýk 
            gameObject.SetActive(false); //paranýn ekrandan kaybolmasý için yazýlan kodlama 
        }
    }
}
