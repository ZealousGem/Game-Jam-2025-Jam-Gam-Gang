using System.Collections;

using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    Vector3 Movement;
    Vector2 LookingAround;
    Rigidbody rb;
    Transform ori;
    Camera cam;
    bool isGrounded;
    float speed = 5f;
    float vertRotation = 0f;
    float horiRotation = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cam = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        ori = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

    }
    private void FixedUpdate()
    {
        InputKey();
        MovementH();

    }

    void InputKey()
    {
        Movement = Vector3.zero;

        if (Input.GetKey(KeyCode.A)) Movement.x = -1;
        if (Input.GetKey(KeyCode.D)) Movement.x = +1;
        if (Input.GetKey(KeyCode.W)) Movement.z = +1;
        if (Input.GetKey(KeyCode.S)) Movement.z = -1;

        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            isGrounded = false;
            rb.AddForce(new Vector3(rb.linearVelocity.x, 5f, 0f), ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 10;
        }

        else
        {
            speed = 5f;
        }

        Movement = Movement.normalized;

        LookingAround = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
    }

    void MovementH()
    {

        Debug.Log("moving");
        if (rb != null)
        {
            Vector3 movingDir = (ori.forward * Movement.z + ori.right * Movement.x).normalized;
            rb.MovePosition(rb.position + movingDir.normalized * speed * Time.fixedDeltaTime);
        }

        Debug.Log("rotating");
        vertRotation -= LookingAround.y * Time.fixedDeltaTime * 100f;
        vertRotation = Mathf.Clamp(vertRotation, -90f, 90f);

        horiRotation = LookingAround.x * Time.fixedDeltaTime * 100f;
        transform.Rotate(0f, horiRotation, 0f);

        cam.transform.localRotation = Quaternion.Euler(vertRotation, 0f, 0f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;

        }
    }


}