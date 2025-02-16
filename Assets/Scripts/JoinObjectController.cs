using UnityEngine;

public class JoinObjectController : MonoBehaviour
{
	private HingeJoint hinge;
	public float force = 100f;

	void Start()
	{
		hinge = GetComponent<HingeJoint>();
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			Debug.Log("asdf");
			JointMotor motor = hinge.motor;
			motor.force = force;
			motor.targetVelocity = 90f; // Xoay 90 độ
			motor.freeSpin = false;
			hinge.motor = motor;
			hinge.useMotor = true;
		}
	}
}
