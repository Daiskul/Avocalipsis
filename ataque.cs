using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ataque : MonoBehaviour {
    public GameObject miataque;
    public GameObject posicionmiataque;
    public bool atacado = false;
    

	void Update () {
        if (Input.GetKeyDown(KeyCode.G) && atacado == false)
        {
            GameObject copiataque = Instantiate(miataque, posicionmiataque.transform.position, miataque.transform.rotation);
            Destroy(copiataque, .3f);
            atacado = true;

        }
        
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "damage"&&Input.GetKeyDown(KeyCode.G) && atacado == false)
        {
            Destroy(collision.gameObject);
        }
    }
}
