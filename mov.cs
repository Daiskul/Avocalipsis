using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mov : MonoBehaviour {
    public Vector3 velocidad;
    public Vector3 salto;
    public bool jump = false;
    public GameObject gestorsemillas;
    public GameObject semilla;
    public int missemillas=0;
    public ataque elataquejug;
    public float cont = 0;
    public int vidas=3;
    public int hp=3;
    public GameObject spawnpoint;
    public bool invul = false;
    public bool cogersemilla = false;
    public bool estoyenmaceta = false;
    public GameObject[] aguacates;
    public GameObject[] macetas;
    public GameObject[] posicmacetas;


    void Start () {
        velocidad = new Vector3 (4, 0, 0);
        salto = new Vector3(0, 10, 0);
	}
	
	void Update () {
        //movimiento
        if (Input.GetKey(KeyCode.D))
            this.transform.position += velocidad * Time.deltaTime;
           
        if (Input.GetKey(KeyCode.A))
            this.transform.position -= velocidad * Time.deltaTime;
        if (Input.GetKey(KeyCode.Space)&&jump==false)
        {
            jump = true;
            this.GetComponent<Rigidbody2D>().velocity = salto;
        }
        //dejar semillas
        if (Input.GetKeyDown(KeyCode.J) && missemillas >= 1 && estoyenmaceta==true)
        {
            macetas[0].gameObject.transform.position = posicmacetas[1].transform.position;
            macetas[1].gameObject.transform.position = posicmacetas[0].transform.position;
            missemillas -= 1;
        }
        if (elataquejug.atacado == true)
        {
            elataquejug.enabled = false;
            
            cont += 1 * Time.deltaTime;
            if (cont >= 0.8f)
            {
                elataquejug.atacado = false;
                elataquejug.enabled = true;
                cont = 0;
            }
        }
        //MORIR
        if (hp<=0)
        {
            vidas -= 1;
            this.transform.position = spawnpoint.transform.position;
            hp = 3;
        }


    }
    //colisiones
    void OnCollisionEnter2D ( Collision2D other )
    {
        
        if (other.gameObject.tag == "suelo")
            jump = false;
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        //recoger semillas
        if (collision.gameObject.tag == "soul" && Input.GetKeyDown(KeyCode.H)&&cogersemilla==false)
        {
            aguacates[0].transform.position = semilla.transform.position;
            Destroy(collision.gameObject);
            StartCoroutine("nomasitems");
            
            missemillas += 1;
            Debug.Log("" + missemillas);
        }
        if (collision.gameObject.tag == "maceta")
        {
            estoyenmaceta = true;

        }
    }

     void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "maceta")
        {
            estoyenmaceta = false;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "damage"&&invul==false){
            hp -= 1;
            StartCoroutine("invulnerable");

        }
    }
    IEnumerator invulnerable()
    {
        invul = true;
        yield return new WaitForSeconds(1);
        invul = false;
    }
    IEnumerator nomasitems()
    {
        cogersemilla = true;
        yield return new WaitForSeconds(1);
        cogersemilla = false;
    }

}
