using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    bool canJump;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //gameObject.transform.position = new Vector3(gameObject.transform.position.x + 10f * Time.deltaTime ,gameObject.transform.position.y,gameObject.transform.position.z);
        if(Input.GetKey("a")){
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-500f * Time.deltaTime, 0));
            gameObject.GetComponent<Animator>().SetBool("moving", true);
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }

        if(Input.GetKey("d")){
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(500f *Time.deltaTime, 0));
            gameObject.GetComponent<Animator>().SetBool("moving", true);
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }

        if(!Input.GetKey("a") && !Input.GetKey("d")){
            gameObject.GetComponent<Animator>().SetBool("moving", false);
        }
        
        if(Input.GetKeyDown("space")){
            canJump = false;
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 300f));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.transform.tag == "Ground"){
            canJump = true;
        }
    }
}
