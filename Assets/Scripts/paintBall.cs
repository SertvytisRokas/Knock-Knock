using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paintBall : MonoBehaviour
{

    public float speed;

    void Update()
    {

        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        Destroy(this.gameObject, 3f);
    }
    
    private void OnTriggerEnter(Collider other)
    {

            Destroy(this);

    }
    


}
