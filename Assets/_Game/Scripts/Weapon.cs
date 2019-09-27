using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public bool activated;
    public float rotationSpeed;
    
    // Update is called once per frame
    void Update()
    {
        if (activated) {
            transform.localEulerAngles += Vector3.forward * rotationSpeed * Time.deltaTime;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        print(collision.gameObject.name);

        activated = false;
        GetComponent<Rigidbody>().Sleep();
        GetComponent<Rigidbody>().collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
        GetComponent<Rigidbody>().isKinematic = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Breakable")) {
            if (other.GetComponent<BreakBox>() != null) {
                other.GetComponent<BreakBox>().Break();
            }
        }
    }
}
