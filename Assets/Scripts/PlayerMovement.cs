using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float moveSpeed;
    public float climbSpeed;
    public float jumpForce;
    private bool isJumping;
    private bool isGrounded;
    [HideInInspector]
    public bool isClimbing;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask collisionLayers;
    public Rigidbody2D rb;
    public Animator animator;
    public SpriteRenderer spriteRenderer;//visuel du personnage
    private Vector3 velocity = Vector3.zero;
    private float horizontalMovement;
    private float verticalMovement;
    // Update is called once per frame
    void Update()
    {

       
        horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        verticalMovement = Input.GetAxis("Vertical") * climbSpeed * Time.deltaTime;


        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            //rb.AddForce(Vector2.up * 5f, ForceMode2D.Impulse);
            isJumping = true;
        }

        Flip(rb.linearVelocity.x);
        float characterVelocity = Mathf.Abs(rb.linearVelocity.x);
        animator.SetFloat("Speed", characterVelocity);
        animator.SetBool("isClimbing", isClimbing);
    }
    void FixedUpdate()//    OPeration Physique pas des Inputs
    {
    isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, collisionLayers);
    MovePlayer(horizontalMovement, verticalMovement);

    }
    void MovePlayer(float _horizontalMovement ,float _verticalMovement)
    {
        if (!isClimbing)
        {
            Vector3 targetVelocity = new Vector2(_horizontalMovement, rb.linearVelocity.y);
            rb.linearVelocity = Vector3.SmoothDamp(rb.linearVelocity, targetVelocity, ref velocity, 0.05f);
            if (isJumping)
            {
                rb.AddForce(new Vector2(0f, jumpForce));
                isJumping = false;
            }
        }
        else
        {
            //déplacement en verticale du joueur
              Vector3 targetVelocity = new Vector2(0, _verticalMovement);
            rb.linearVelocity = Vector3.SmoothDamp(rb.linearVelocity, targetVelocity, ref velocity, 0.05f);
            
           
         }
       
    }
    void Flip(float _velocity)
    {
        if (_velocity > 0.1f)
        {
            spriteRenderer.flipX = false;
        }
        else if (_velocity < -0.1f)
        {
            spriteRenderer.flipX = true;

        }

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
     }
}
