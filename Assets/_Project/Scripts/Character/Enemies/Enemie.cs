using PathCreation;
using UnityEngine;

public class Enemie : Entity
{
    [Header("Controle")]
    [SerializeField] private bool canMove = true;

    [Header("Vari�veis")]
    [SerializeField] protected float speed;
    [SerializeField] protected float currentSpeed;

    [Header("Esqueci o nome")]
    [SerializeField] protected Rigidbody2D rb;
    private PathCreator pathCreator;

    float distanceTravalled;

    // Start is called before the first frame update
    public override void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (GameObject.Find("Path").GetComponent<PathCreator>() != null)
            pathCreator = GameObject.Find("Path").GetComponent<PathCreator>();
        if (pathCreator != null)
            transform.position = pathCreator.path.GetPointAtDistance(0.5f);
    }

    public void FixedUpdate()
    {
        if (canMove)
            MoveInPath();
    }

    public void MoveInPath()
    {
        distanceTravalled += speed * Time.deltaTime;
        rb.MovePosition(pathCreator.path.GetPointAtDistance(distanceTravalled));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //collision.GetComponent<Entity>().TakeDamage(damage);
            Destroy(gameObject);
            EnemySpawner.onEnemyDestroy?.Invoke();
        }
    }
}
