using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public GameObject splitFruit;
    public float force = 15f;

    private Rigidbody2D rb;

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * force, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Blade")
        {
            //Vector3 direction = collision.transform.position - transform.position;
            //Quaternion rotation = Quaternion.LookRotation(direction).normalized;

            GameObject sliced = Instantiate(splitFruit, transform.position, transform.rotation);
            Destroy(gameObject);
            Destroy(sliced, 3f);
        }
    }
}
