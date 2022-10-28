using UnityEngine;

public class Déplacement_Personnage : MonoBehaviour
{
    [SerializeField] private LayerMask platformLayerMask;

    public Collider2D coll;
    public float moveSpeed;
    public float jumpForce;

    public bool isJumping = false;
    public bool isGrounded;

    public Transform GroundCheck_Gauche;
    public Transform GroundCheck_Droite;

    public Rigidbody2D rb;
    public SpriteRenderer spriteRenderer;
    private Vector3 velocity = Vector3.zero;
    private float horizontalMovement;

    public static Déplacement_Personnage instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de Vie_Joueur ici");
            return;
        }

        instance = this;
    }

    void Update()
    {
        
        horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;


        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            isJumping = true;
        }


    }

    void FixedUpdate()
    {
        MovePlayer(horizontalMovement);
        Flip(rb.velocity.x);
    }

    void MovePlayer(float _horizontalMovement)
    {
        Vector3 targetVelocity = new Vector2(_horizontalMovement, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);

        if (isJumping == true)
        {
            rb.AddForce(new Vector2(0f, jumpForce));
            isJumping = false;
        }
    }

    private bool IsGrounded()
    {
        float extraHeightText = 0.1f;
        RaycastHit2D raycastHit = Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, extraHeightText, platformLayerMask);
        Color rayColor;
        if (raycastHit.collider != null)
        {
            rayColor = Color.green;
        }
        else
        {
            rayColor = Color.red;
        }
        Debug.DrawRay(coll.bounds.center, Vector2.down * (coll.bounds.extents.y + extraHeightText));
        Debug.Log(raycastHit.collider);
        return raycastHit.collider != null;
    }

    void Flip(float _velocity)
    {
        if (_velocity > 0.1f)
        {
            spriteRenderer.flipX = false;
        }
        else if(_velocity < -0.1f)
        {
            spriteRenderer.flipX = true;
        }

    }
}
