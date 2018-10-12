using UnityEngine;

public class InputController : MonoBehaviour {

    Rigidbody2D rigid;
	// Use this for initialization
	void Start () {
        rigid = GetComponent<Rigidbody2D>();
	}

    private void OnMouseDrag()
    {
        Vector3 mousePos = Camera.current.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = new Vector2(transform.position.x, transform.position.z) - new Vector2(mousePos.x, mousePos.z);
        rigid.AddForce(direction);
    }
}
