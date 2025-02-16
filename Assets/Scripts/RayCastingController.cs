using Unity.VisualScripting;
using UnityEngine;

public class RayCastingController : MonoBehaviour
{
	[SerializeField] private float speed = 1.5f;
	private bool hasLightOfSight = false;
	private GameObject player;
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		player = GameObject.FindGameObjectWithTag("Raycasting");
		Debug.Log(player.tag);
	}

	// Update is called once per frame
	void Update()
	{
		if (hasLightOfSight)
		{
			transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
		}
	}

	private void FixedUpdate()
	{
		int layerMask = ~LayerMask.GetMask("enemy");	
		RaycastHit2D ray = Physics2D.Raycast(transform.position, player.transform.position - transform.position, Mathf.Infinity, layerMask);
		Debug.Log(ray.collider);
		if (ray.collider != null)
		{
			//Debug.Log(ray.collider.gameObject.tag);
			hasLightOfSight = ray.collider.gameObject == player;
			if (hasLightOfSight)
			{
				Debug.DrawRay(transform.position, player.transform.position - transform.position, Color.green);
			}
			else
			{
				Debug.DrawRay(transform.position, player.transform.position - transform.position, Color.red);
			}
		}
	}
}
