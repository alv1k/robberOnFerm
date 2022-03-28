using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class secondController : MonoBehaviour
{
    // Start is called before the first frame update
    float vertical;
    float horizontal;
    Transform tr;
    float jumpForce = 10f;
    Rigidbody rb;
    bool isGrounded = false;
    [SerializeField] TextMeshProUGUI startText;
    [SerializeField] TextMeshProUGUI scoreText;
    public static int score = 0;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

        vertical = Input.GetAxis("Vertical");
        rb.AddRelativeForce(0,0,vertical * 2f);
        horizontal = Input.GetAxis("Horizontal");
        tr.Rotate(0, horizontal* 0.05f,0);


        if(Input.GetKeyDown("space") && isGrounded == true){
            rb.AddForce(0,10f,0, ForceMode.Impulse);
            rb.drag = 2;
            rb.angularDrag = 2;
        }
        if(Input.GetKeyDown("g")){
            Destroy(startText);
        }
    }

    void OnCollisionEnter(Collision col){
        if(col.gameObject.tag == "ground"){
            isGrounded = true;
            rb.drag = 0;
            rb.angularDrag = 0;
        }
        if(col.gameObject.tag == "animal"){
            score = score + 1;
            scoreText.text = "Животных: " + score;
            Destroy(col.gameObject);
        }
    }
    void OnCollisionExit(Collision col){
        if(col.gameObject.tag == "ground"){
            isGrounded = false;
        }
    }
}
