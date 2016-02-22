using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 10f;
    Vector3 movement;
    Animator anim;
    Rigidbody playerRigidbody;
    int floorMask;
    float camRayLength = 100f;
	public Vector3 prevPos = new Vector3(0, 0, 0);

    void Awake()
    {
        floorMask = LayerMask.GetMask("Floor");
        //anim = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        //float v= Input.GetAxisRaw("Vertical");
        Move(h, 1);
        //Turning();
        //Animation Control
        //Animating(h, 1);
    }
    void Move(float h, float v)
    {
		prevPos = playerRigidbody.position;

        movement.Set(h, 0f, v);
        movement = movement.normalized * speed * Time.deltaTime;

        Vector3 newPosition = transform.position + movement;
        newPosition.y = 0.25f;
        playerRigidbody.MovePosition(newPosition);

        playerRigidbody.MoveRotation(new Quaternion(0,0,0,1));
    }
    void Turning()
    {
        // Create a ray from the mouse cursor on screen in the direction of the camera.
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        // Create a RaycastHit variable to store information about what was hit by the ray.
        RaycastHit floorHit;

        // Perform the raycast and if it hits something on the floor layer...
        if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask))
        {
            // Create a vector from the player to the point on the floor the raycast from the mouse hit.
            Vector3 playerToMouse = floorHit.point - transform.position;

            // Ensure the vector is entirely along the floor plane.
            playerToMouse.y = 0f;

            // Create a quaternion (rotation) based on looking down the vector from the player to the mouse.
            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);

            // Set the player's rotation to this new rotation.
            playerRigidbody.MoveRotation(newRotation);
        }
    }
    void Animating(float h, float v)
    {
        bool walking = h != 0f || v != 0f;
        anim.SetBool("IsWalking", walking);
    }
    public void ResetSpeed()
    {
        speed = 10f;
    }
    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }
    public void IncreaseSpeed(float ammont)
    {
        speed += ammont;
    }
    public void DecreaseSpeed(float ammont)
    {
        speed -= ammont;
    }

}