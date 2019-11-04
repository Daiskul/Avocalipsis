using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movia : MonoBehaviour {
    public Vector3 vel;
    public GameObject pivote1;
    public GameObject pivote2;
    public bool der=true;
   

n	void Start () {
        vel = new Vector3 (2*Time.deltaTime , 0,0);
	}
	

	void Update () {
        if (der == true)
        {
            derecha();
            this.GetComponent<SpriteRenderer>().flipX = true;
        }
        if (der==false)
        {
            izquierda();
            this.GetComponent<SpriteRenderer>().flipX = false;
        }
        if (this.transform.position.x>=pivote2.transform.position.x)
        {
            der=false;
        }
        if (this.transform.position.x <= pivote1.transform.position.x)
        {
            der = true;
        }

    }
    void derecha()
    {
        this.transform.position += vel;
        
    }
    void izquierda()
    {
        this.transform.position -= vel;
    }
}
