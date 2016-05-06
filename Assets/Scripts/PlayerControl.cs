using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerControl : MonoBehaviour
{

	public GuiController gui; 				// Access to the GUI 
	public bool timeEnabled = true;
	public bool accelEnabled = true;
	public bool jumpEnabled = true;
	public bool dashEnabled = true;

	public bool facingRight = true;			// For determining which way the player is currently facing.
	[HideInInspector]
	public bool jump = false;				// Condition for whether the player should jump.
	private bool dash = false; 

	public float moveForce = 365f;			// Amount of force added to move the player left and right.
	public float maxSpeed = 5f;				// The fastest the player can travel in the x axis.
	public AudioClip[] jumpClips;			// Array of clips for when the player jumps.
	public float jumpPower = 15f;
	public int   maxJumps = 2;
	public float dashPower = 25f;
	public int 	 dashCooldown = 4;			// in seconds 

	public float percentageTimeLeft = 1.0f;

	/* NOT USED
	public AudioClip[] taunts;				// Array of clips for when the player taunts.
	public float tauntProbability = 50f;	// Chance of a taunt happening.
	public float tauntDelay = 1f;			// Delay for when the taunt should happen.
	private int tauntIndex;					// The index of the taunts array indicating the most recent taunt.
	*/ 

	private Transform groundCheck;			// A position marking where to check if the player is grounded.
	private bool grounded = false;			// Whether or not the player is grounded.
	private Animator anim;					// Reference to the player's animator component.
	private int jumpCount;					// Number of times the player has jumped since touching the ground
	private float lastDashTime;

	private static float MIN_JUMP_POWER = 8f;
	private static float MIN_SPEED = 2f;

	void Start() {
		lastDashTime = 0;

		gui.timeEnabled = timeEnabled;
		gui.accelEnabled = accelEnabled;
		gui.jumpEnabled = jumpEnabled;
		gui.dashEnabled = dashEnabled;
		gui.updateIconsEnabled ();

		jumpPower = MIN_JUMP_POWER + (jumpPower - MIN_JUMP_POWER) * percentageTimeLeft;
		maxSpeed = MIN_SPEED + (maxSpeed - MIN_SPEED) * percentageTimeLeft;
		gui.updateTimeDisplay (percentageTimeLeft);
	}

	void Awake()
	{
		// Setting up references.
		groundCheck = transform.Find("groundCheck");
		anim = GetComponent<Animator>();
		
	}


	void Update()
	{
		/*
		grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));  
		if (Input.GetButtonDown ("Jump") && grounded)
			jump = true;
        */
		/* Jump */
		// The player is grounded if a linecast to the groundcheck position hits anything on the ground layer.
		grounded = Physics2D.Raycast (
			transform.position, 									 // From players pos ...
			Vector2.down, 											// ... check downwards ...
			GetComponent<BoxCollider2D> ().bounds.extents.y + 0.05f, // ... to the edge of our feet ... 
			1 << LayerMask.NameToLayer("Ground")					// ... for a ground collider
		);

		if (grounded)
			jumpCount = 0;

		// If the jump button is pressed and the player is grounded then the player should jump.
		if (Input.GetButtonDown ("Jump") && (grounded || (jumpEnabled && jumpCount < maxJumps))) {
			jump = true;
			jumpCount++;
		}

		/* Dash */
		lastDashTime -= Time.deltaTime;
		if (Input.GetKey (KeyCode.LeftShift) && (lastDashTime < 0) && dashEnabled) {
			dash = true;
		}

		/* restart */
		if (Input.GetKey (KeyCode.R)) {
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}

	}


	void FixedUpdate ()
	{
		Rigidbody2D rb = GetComponent<Rigidbody2D> ();

		// Cache the horizontal input.
		float h = Input.GetAxis("Horizontal");	// Left (-1) or right (1)

		// The Speed animator parameter is set to the absolute value of the horizontal input.
		anim.SetFloat("Speed", Mathf.Abs(h));

		if(Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x) < maxSpeed)
			GetComponent<Rigidbody2D>().AddForce(Vector2.right * h * moveForce);

		/*
		// If the player is changing direction (h has a different sign to velocity.x) or hasn't reached maxSpeed yet...
		if(h * GetComponent<Rigidbody2D>().velocity.x < maxSpeed)
			// ... add a force to the player.
			GetComponent<Rigidbody2D>().AddForce(Vector2.right * h * moveForce);


		// If the player's horizontal velocity is greater than the maxSpeed...
		if(Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x) > maxSpeed)
			// ... set the player's velocity to the maxSpeed in the x axis.
			// Mathf.Sign returns a 1 or -1
			GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Sign(GetComponent<Rigidbody2D>().velocity.x) * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);
		*/

		// If the input is moving the player right and the player is facing left...
		if(h > 0 && !facingRight)
			// ... flip the player.
			Flip();
		// Otherwise if the input is moving the player left and the player is facing right...
		else if(h < 0 && facingRight)
			// ... flip the player.
			Flip();

		// If the player should jump...
		if(jump)
		{
			// Set the Jump animator trigger parameter.
			anim.SetTrigger("Jump");

			// Play a random jump audio clip.
			int i = Random.Range(0, jumpClips.Length);
			AudioSource.PlayClipAtPoint(jumpClips[i], transform.position);

			// Add a vertical force to the player.
			// GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce));
			rb.velocity = transform.up * jumpPower;

			// Make sure the player can't jump again until the jump conditions from Update are satisfied.
			jump = false;

			Debug.Log ("Jumped");
		}

		// If the player should dash
		if (dash) {
			// anim
			// sound
			if (facingRight)
				rb.velocity = transform.right * dashPower;
			else
				rb.velocity = transform.right * -dashPower;
			dash = false;
			lastDashTime = dashCooldown;
			Debug.Log ("Dashed");
		}

	}
	
	
	void Flip ()
	{
		// Switch the way the player is labelled as facing.
		facingRight = !facingRight;

		// Multiply the player's x local scale by -1. (change directions, but keep speed)
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	/*
	public IEnumerator Taunt()
	{
		// Check the random chance of taunting.
		float tauntChance = Random.Range(0f, 100f);
		if(tauntChance > tauntProbability)
		{
			// Wait for tauntDelay number of seconds.
			yield return new WaitForSeconds(tauntDelay);

			// If there is no clip currently playing.
			if(!GetComponent<AudioSource>().isPlaying)
			{
				// Choose a random, but different taunt.
				tauntIndex = TauntRandom();

				// Play the new taunt.
				GetComponent<AudioSource>().clip = taunts[tauntIndex];
				GetComponent<AudioSource>().Play();
			}
		}
	}


	int TauntRandom()
	{
		// Choose a random index of the taunts array.
		int i = Random.Range(0, taunts.Length);

		// If it's the same as the previous taunt...
		if(i == tauntIndex)
			// ... try another random taunt.
			return TauntRandom();
		else
			// Otherwise return this index.
			return i;
	}
	*/
}
