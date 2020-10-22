using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerKontrol : MonoBehaviour
{
    Rigidbody fizik;
    float horizontal = 0;
    float vertical = 0;
    Vector3 vec;
    public float karakterHiz;
    public float minX;
    public float maxX;
    public float minZ;
    public float maxZ;
    public float egim;
    float atesZamani = 0;
    public float atesGecenSure;
    public GameObject Kursun;
    public Transform KursunNeredenCiksin;
   new AudioSource audio;

    public AudioSource Audio
    {
        get
        {
            return audio;
        }

        set
        {
            audio = value;
        }
    }

    void Start()
    {
        fizik = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
    }

     void Update()
    {
        if(Input.GetButton("Fire1")&& Time.time > atesZamani)
        {
            atesZamani = Time.time + atesGecenSure;
            Instantiate(Kursun,KursunNeredenCiksin.position,Quaternion.identity);
            audio.Play();
        }
    }

    void FixedUpdate()//fizik olaylarını kullacağımız için FixedUpdate fonk yazdım
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        vec = new Vector3(horizontal, 0, vertical);//Y ekseninde hareket etmemesi lazım
        fizik.velocity = vec * karakterHiz;//kuvvet uygulamadım.Karakterimin hızını tanımladım. Method olmadığı için parametre olarak vermedim 
        //ekrandan dışarıya çıkmaması için
        fizik.position = new Vector3
        (
            Mathf.Clamp(fizik.position.x,minX,maxX),
            0.0f,
            Mathf.Clamp(fizik.position.z,minZ,maxZ)
        );
        fizik.rotation = Quaternion.Euler(0,0,fizik.velocity.x*-egim);


    }
}