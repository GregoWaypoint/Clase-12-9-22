using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SphereScript : MonoBehaviour
{

    private Rigidbody rb;

    public float forceMultiplier;
    public float jumpForce;
    public bool canJump;

    public int itemsCollected;
    public TextMeshProUGUI score;

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
        if (datosChoque.gameObject.CompareTag("Fall") || datosChoque.gameObject.CompareTag("wall"))
        {
            SceneManager.LoadScene("MinigameStart");
        }
        if (datosChoque.gameObject.CompareTag("win"))
        {
            if(itemsCollected == 7)
            {
                SceneManager.LoadScene("WinScreen");
            }
            else
            {
                score.text = score.text + "\t te faltan BOBO";
            }          
        }
       
    }

    private void OnCollisionExit(Collision datosChoque)
    {
        if (datosChoque.gameObject.CompareTag("win"))
        {
            score.text = $"Stars {itemsCollected}/7";
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Star"))
        {
            Destroy(other.gameObject);
            itemsCollected ++;
            score.text = $"Stars {itemsCollected}/7";
            //score.color = new Color(Random.Range(0, 255), Random.Range(0, 255), Random.Range(0, 255));
            score.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
            //score.color = Color.red;
        }
        
    }
}
