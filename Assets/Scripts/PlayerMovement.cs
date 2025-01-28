using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Moving Variables")]
    [SerializeField] private float speed = 3.0f; // How fast the player moves
    [HideInInspector] public Vector2 Direction; // Direction of player movement

    // Update is called once per frame
    void Update()
    {
        UpdateMovement();
    }

    // Function called once per frame for moving the character
    void UpdateMovement()
    {
        transform.position += new Vector3(speed * Direction.x * Time.deltaTime, speed * Direction.y * Time.deltaTime);
    }
}
