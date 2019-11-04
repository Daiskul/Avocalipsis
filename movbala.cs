using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movbala : MonoBehaviour {
    public Vector3 velbala;
    public Vector3 caidabala;

	void Start () {
        velbala = new Vector3 (4, 3, 0);
        
        Destroy(this.gameObject, 5f);
	}
	

	void Update () {
        this.GetComponent<Rigidbody2D>().AddForce(new Vector2 (15,0));
        float cont = 0;
        cont += 1 * Time.deltaTime;
        
        

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("te dañe xd");
            Destroy(this.gameObject);
        }
    }
}
