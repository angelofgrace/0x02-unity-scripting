using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public int health = 5;

    private Rigidbody rigid;
    private int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody> ();
    }

    // Update is called once per frame
    void Update()
    {
        float xDirection = Input.GetAxis("Horizontal");
        float zDirection = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(xDirection, 0.0f, zDirection);

        rigid.AddForce (moveDirection * speed);

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Pickup")
        {
            score += 1;
            Debug.Log("Score: " + score);
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.tag == "Trap")
        {
            health -= 1;
            Debug.Log("Health: " + health);
        }
    }
}
