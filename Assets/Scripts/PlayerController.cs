using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] public Rigidbody playerbody;
    [SerializeField] public float speed = 2f;
    [SerializeField] public float jumpForce = 7f;
    [SerializeField] public float jumpCoolDown = 2f;
    Vector3 playerInput;
    Coroutine coolDownTimer;
    bool canJump;


    void Start()
    {
        playerbody = this.GetComponent<Rigidbody>();
        canJump = true;
    }

    
    void Update()
    {
        Vector3 playerPositionForward = this.transform.position;
        playerPositionForward.z += Input.GetAxis("Vertical") * speed * Time.deltaTime;
        this.transform.position = playerPositionForward;

        Vector3 playerPositionSideways = this.transform.position;
        playerPositionSideways.x += Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        this.transform.position = playerPositionSideways;

        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            playerbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            coolDownTimer = StartCoroutine(jumpCooldownTimer());
        }
    }

    private IEnumerator jumpCooldownTimer()
    {
        canJump = false;
        yield return new WaitForSeconds(jumpCoolDown);
        canJump = true;
    }
}
