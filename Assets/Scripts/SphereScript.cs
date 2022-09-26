using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SphereScript : MonoBehaviour
{

    private Rigidbody rb;

    public float forceMultiplier;
    public float jumpForce;
    public bool canJump;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        canJump = true;
    }

    
    void Update()
    {
        float horizontalForce = Input.GetAxis("Horizontal") * forceMultiplier;
        float verticalForce = Input.GetAxis("Vertical") * forceMultiplier;

        rb.AddForce(verticalForce, 0f, -horizontalForce);

        if(Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            rb.AddForce(0f, jumpForce, 0f, ForceMode.Impulse);
            canJump = false;
        }
    }

    private void OnCollisionEnter(Collision datosChoque)
    {
        if(datosChoque.gameObject.CompareTag("Ground"))
        {
            canJump = true;
        }
        if (datosChoque.gameObject.CompareTag("Fall") && datosChoque.gameObject.CompareTag("wall"))
        {
            SceneManager.LoadScene("MinigameStart");
        }
        if (datosChoque.gameObject.CompareTag("win"))
        {
            SceneManager.LoadScene("WinScreen");
        }
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Star"))
        {
            Destroy(other.gameObject);
            Debug.Log("no se nada0");
        }
        
    }
}
