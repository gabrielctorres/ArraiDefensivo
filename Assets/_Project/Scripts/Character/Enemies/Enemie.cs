using PathCreation;
using UnityEngine;

public class Enemie : Entity
{
    [Header("Controle")]
    [SerializeField] private bool canMove = true;

    [Header("Vari�veis")]
    [SerializeField] public float speed;

    [Header("Esqueci o nome")]
    [SerializeField] protected Rigidbody2D rb;
    private PathCreator pathCreator;
    public float offSetMovement = 0.32f;

    private Animator animator;
    float distanceTravalled;

    // Start is called before the first frame update
    public override void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        if (pathCreator != null)
            transform.position = pathCreator.path.GetPointAtDistance(0.5f);
        else
            pathCreator = GameObject.Find("Path Creator").GetComponent<PathCreator>();
    }

    public void FixedUpdate()
    {
        if (canMove && pathCreator != null)
            MoveInPath();
    }

    public void MoveInPath()
    {
        distanceTravalled += speed * Time.deltaTime;
        Vector2 aux = pathCreator.path.GetPointAtDistance(distanceTravalled);
        Vector2 fixedPosition = new Vector2(aux.x, aux.y + offSetMovement);
        rb.MovePosition(fixedPosition);
        animator.SetFloat("Horizontal", pathCreator.path.GetDirectionAtDistance(distanceTravalled).x);
        animator.SetFloat("Vertical", pathCreator.path.GetDirectionAtDistance(distanceTravalled).y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Fim"))
        {
            //collision.GetComponent<Entity>().TakeDamage(damage);
            Destroy(gameObject);
            EnemySpawner.onEnemyDestroy?.Invoke();
        }
    }
}
