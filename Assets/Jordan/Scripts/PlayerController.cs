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
    bool walk = false;
    float MouseSpeed;
    [SerializeField]float speed = 10f;
    [SerializeField] float sprintSpeed = 20f;
    [SerializeField] float vertRotation = 0f;
   // [SerializeField] float horiRotation = 0f;

    void Start()
    {

        try { AudioManager.Instance.StopMusic("type"); } catch { }
        try
        {
            MouseSpeed = MouseSensitivity.instance.Amount;
        }

        catch {

            MouseSpeed = 100f;

        }

        try
        {
            AudioManager.Instance.PlaySound("station");
        }

        catch { }
        rb = GetComponent<Rigidbody>();
        cam = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        ori = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        Application.targetFrameRate = 60;
    }

    private void Update()
    {
        InputKey();
        LookAround();
    }
    private void FixedUpdate()
    {
       
        MovementH();
    }


    void InputKey()
    {
        Movement = Vector3.zero;

        if (Input.GetKey(KeyCode.A)) Movement.x = -1; 
        if (Input.GetKey(KeyCode.D))  Movement.x = +1; 
        if (Input.GetKey(KeyCode.W))  Movement.z = +1; 
        if (Input.GetKey(KeyCode.S))  Movement.z = -1; 

        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            isGrounded = false;
            rb.AddForce(new Vector3(rb.linearVelocity.x, 5f, 0f), ForceMode.Impulse);
        }

        
        Movement = Movement.normalized;
        if (Movement == Vector3.zero)
        {
            try
            {
                AudioManager.Instance.StopMusic("movement");
            }

            catch { }
        }

        else if(!walk)
        {
            StartCoroutine(Walking());
        }

        
        LookingAround = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
    }

    IEnumerator Walking()
    {

            walk = true;
      
        if (Movement != Vector3.zero)
        {
            try { AudioManager.Instance.PlaySound("movement"); } catch { }
            yield return new WaitForSeconds(3f);
        }

        else
        {
            try { AudioManager.Instance.StopMusic("movement"); } catch { }
            yield return new WaitForSeconds(0.1f);
        }

        walk = false;


    }

    void MovementH()
    {

       // Debug.Log("moving");
        if (rb != null)
        {
            Vector3 movingDir = (ori.forward * Movement.z + ori.right * Movement.x).normalized;
            rb.MovePosition(rb.position + movingDir.normalized * speed * Time.fixedDeltaTime);
        }

        
    }

    void LookAround()
    {
        //  Debug.Log("rotating");
        vertRotation -= LookingAround.y * Time.deltaTime * MouseSpeed;
        vertRotation = Mathf.Clamp(vertRotation, -90f, 90f);


        transform.Rotate(0f, LookingAround.x * Time.deltaTime * MouseSpeed, 0f);
        //  Debug.Log("Horizontal Y Rotation: " + transform.eulerAngles.y);


        cam.transform.localRotation = Quaternion.Euler(vertRotation, 0f, 0f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("PickedUp"))
        {
            isGrounded = true;

        }
    }
}