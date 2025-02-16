using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public float speed = 3f;
    private Rigidbody2D rb;
    private float movement;
    public float jumpHeight = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
		movement = Input.GetAxis("Horizontal");

		if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

	private void FixedUpdate()
	{
		rb.linearVelocity = new Vector2(movement * speed, rb.linearVelocityY);

		//body type kinematic
		/*float moveX = Input.GetAxis("Horizontal");
		float moveY = Input.GetAxis("Vertical");
		Vector2 moveDirection = new Vector2(moveX, moveY).normalized;
		rb.MovePosition(rb.position + moveDirection * speed * Time.fixedDeltaTime);*/
	}

    void Jump()
    {
		rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0);
		rb.AddForce(new Vector2(0f, jumpHeight), ForceMode2D.Impulse);
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Obstacle")
        {
            Debug.Log("hit obstacle");
        }
	}

	private void OnCollisionStay2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Obstacle")
        {
            Debug.Log("hitting");
        }
	}

	private void OnCollisionExit2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Obstacle")
		{
			Debug.Log("exit obstacle");
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Start")
		{
			Debug.Log("start game");
		}
		if (collision.gameObject.tag == "End")
		{
			Debug.Log("finish game");
		}
	}
}
