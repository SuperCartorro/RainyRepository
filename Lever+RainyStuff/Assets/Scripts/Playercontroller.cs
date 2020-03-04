using UnityEngine;
using System.Collections;



public class Playercontroller : MonoBehaviour {
	
	//Movement Variables
	public float moveSpeed;
	public float jumpHeight;
	
	//Check if the player is on the Ground Variables   
	public Transform groundCheck; //This is the Child Empty stuck on the players feet
	private float moveVelocity;
	public float groundCheckRadius; //This is the radius checked keep small .1
	public LayerMask whatIsGround;  //This checks to see if what the player is standing on is a ground layer
	private bool grounded; //Checks to see if the player is on the ground if true then he can jump
	private bool doubleJumped; //This checks to see if the player has doublejumped if true then he cant jump
	private bool moveRight;
	private bool hittingWall;
	private bool notAtEdge;
	public Transform wallCheck;
	public float wallCheckRadius;
	public LayerMask whatIsWall;
	public Transform edgeCheck;
	//	private Animator anim;
	public float fireRate = 0.5F;
	private float nextFire = 0.0F;
	
	public Transform firepoint;
	public GameObject Bullet;

    bool collidedWithLever;

    public ToggleLever toggleLever;



	
	void Start () {
		
		//anim = GetComponent<Animator>();
	}
	
	void FixedUpdate()
	{
		
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
	}
	
	void Update () {

        if(collidedWithLever == true) 
        {
            toggleLever.checkThePlayer();
        }





        if (grounded)
			doubleJumped = false;
		
		//anim.SetBool("Grounded", grounded);
		
		if (Input.GetKey (KeyCode.Space) && grounded)
		{
			
			Jump();
		}
		
		
		if (Input.GetKey (KeyCode.Space) && !doubleJumped && !grounded)
		{
			
			Jump();
			doubleJumped = true;
		}
		if (Input.GetKeyDown("v"))
		{
			
			Jump();
		}
		
		
		if (Input.GetKeyDown("v") && !doubleJumped)
		{
			
			Jump();
			doubleJumped = true;
		}
		
		moveVelocity = 0f;
		
		if (Input.GetKey (KeyCode.D))
		{
			GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
			moveVelocity = moveSpeed;
		}
		
		
		if (Input.GetKey(KeyCode.A))
		{
			GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
			moveVelocity = -moveSpeed;
		}    
		
		GetComponent<Rigidbody2D>().velocity = new Vector2(moveVelocity,GetComponent<Rigidbody2D>().velocity.y);
		
		
		
		//anim.SetFloat("Speed", Mathf.Abs(rigidbody2D.velocity.x));
		
		//This flips the player anim to reflect the way he is facing
		if (GetComponent<Rigidbody2D>().velocity.x > 0)
			transform.localScale = new Vector3(1, 1, 1);
		
		else if (GetComponent<Rigidbody2D>().velocity.x < 0)
			transform.localScale = new Vector3(-1, 1, 1);
		
		if(Input.GetKeyDown(KeyCode.Return))
		{
			nextFire = Time.time + fireRate;
			Instantiate(Bullet, firepoint.position, firepoint.rotation);
		}
	}
	
	void Jump()
	{
		GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
	}



    void OnTriggerEnter2D(Collider2D collidedObject)
    {
        if (collidedObject.name == "LeverManager")
        {
            Debug.Log("it's " + collidedObject);

            collidedWithLever = true;
        }
    }
    void OnTriggerExit2D(Collider2D collidedObject)
    {
        if (collidedObject.name == "LeverManager")
        {
            Debug.Log("it's " + collidedObject);

            collidedWithLever = false;
        }
    }
}