using UnityEngine;

public class MouseController : MonoBehaviour
{
    private GameObject selectedObject; // Selected object on mouse

    // Update is called once per frame
    void Update()
    {
        UpdateMouse();
    }

    // Function called once per frame for updating mouse position and input
    void UpdateMouse()
    {
        // Personal Variables
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); // Mouse position in world view

        if (Input.GetMouseButtonDown(0))
        {
            Collider2D obj = Physics2D.OverlapPoint(mousePos);

            selectedObject = obj.transform.gameObject;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            selectedObject = null;
        }

        if (selectedObject != null)
        {
            selectedObject.transform.position = mousePos;
        }
    }
}
