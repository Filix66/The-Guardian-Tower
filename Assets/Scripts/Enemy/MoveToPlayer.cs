using UnityEngine;

public class MoveToPlayer : MonoBehaviour
{
    [Header("Component")]
    public Transform player;
    public Rigidbody2D rb2D;
    public Stats stats;

    [Header("Variable")]
    private Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        stats = GetComponent<Stats>();
        player = GameObject.Find("Tower").GetComponent<Transform>();
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        direction = Direction(player.position, transform.position);
    }

    private void FixedUpdate()
    {
        moveToward(direction);
    }

    void moveToward(Vector3 direction)
    {
        rb2D.MovePosition(transform.position + (direction * stats.GetSpeed() * Time.fixedDeltaTime));
    }

    Vector3 Direction(Vector3 objectOne, Vector3 ObjectTwo)
    {
        Vector3 direction = objectOne - ObjectTwo;
        direction.Normalize();

        return direction;
    }
}