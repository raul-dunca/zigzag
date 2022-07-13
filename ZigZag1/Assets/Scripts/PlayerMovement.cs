using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform rayStart;
    private Animator anim;
    private Rigidbody rb;
    private bool iswalkingright=true;
    private GameManager gameManager;
    public GameObject CrystalEffect;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        gameManager = FindObjectOfType<GameManager>();
    }
    private void FixedUpdate()
    {
        if(!gameManager.GameSarted)
        {
            return;
        }else
        {
            anim.SetTrigger("GameStarted");
        }    
        rb.transform.position = transform.position + transform.forward * 2 * Time.deltaTime;
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Switch();
        }
        RaycastHit hit;
        if(!Physics.Raycast(rayStart.position,-transform.up,out hit,Mathf.Infinity)) 
        {
            if(transform.position.y <= 0.4)
            anim.SetTrigger("Isfalling");
        }
        if(transform.position.y<=-10)
        {
            gameManager.EndGame();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Crystal")
        {
            Destroy(other.gameObject);
            gameManager.IncreaseScore();
            GameObject g = Instantiate(CrystalEffect, rayStart.transform.position,Quaternion.identity);
            Destroy(g, 2);
            Destroy(other.gameObject);
        }
    }
    private void Switch()
    {
        if(!gameManager.GameSarted)
        {
            return;
        }
        iswalkingright = !iswalkingright;
        if(iswalkingright==true)
        
            transform.rotation = Quaternion.Euler(0, 45, 0);
        else
            transform.rotation = Quaternion.Euler(0, -45, 0);

    }
}
