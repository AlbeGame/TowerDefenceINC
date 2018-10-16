using UnityEngine;

public class Debugger : MonoBehaviour {

    private void OnMouseEnter()
    {
        Debug.Log("Enter " + gameObject.name);
    }
}
