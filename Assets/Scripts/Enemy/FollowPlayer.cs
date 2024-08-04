using UnityEngine;

public class FollowPlayer : MonoBehaviour 
{
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Tower").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(0,0, CalculateAngle(player.position,transform.position));
    }

    float CalculateAngle(Vector2 objectOne, Vector2 ObjectTwo)
    {
        Vector3 direction = objectOne - ObjectTwo;
        direction.Normalize();

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        return angle + 90;
    }
}
