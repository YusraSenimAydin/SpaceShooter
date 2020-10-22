using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YokOlma : MonoBehaviour
{
    public GameObject patlama;
    public GameObject playerPatlama;
    GameObject OyunKontrol;
    OyunKontrol kontrol;//scrip


    void Start()
    {//oyun kontrolü score yapmak icin prefab tanımlamadık bu yontemle yaptık
        OyunKontrol = GameObject.FindGameObjectWithTag("oyunkontrol");
        kontrol = OyunKontrol.GetComponent<OyunKontrol>();//component oluşturduk
        

    }
    void OnTriggerEnter(Collider col)
    {
        if (col.tag != "sinir")
        {
            Destroy(col.gameObject);
            Destroy(gameObject);
            Instantiate(patlama,transform.position,transform.rotation);
            kontrol.ScoreArttir(10);

        }
        if (col.tag=="Player")
        {
            Instantiate(playerPatlama, col.transform.position, col.transform.rotation);
            kontrol.oyunBitti();

        }
   
    }
}
