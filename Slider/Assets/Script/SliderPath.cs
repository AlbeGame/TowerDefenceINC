using UnityEngine;

public class SliderPath : MonoBehaviour
{
    public OriginSide StartingSide;
    BoxCollider2D coll;

    private void Start()
    {
        coll = GetComponent<BoxCollider2D>();
    }

    public Vector3 GetOriginSideCenter()
    {
        switch (StartingSide)
        {
            case OriginSide.None:
                return transform.position;
            case OriginSide.Left:
                return transform.position + (Vector3.left * coll.size.x)/2;
            case OriginSide.Top:
                return transform.position + (Vector3.up * coll.size.y)/ 2;
            case OriginSide.Bottom:
                return transform.position + (Vector3.down * coll.size.y)/ 2;
            case OriginSide.Right:
                return transform.position + (Vector3.right * coll.size.x)/ 2;
            default:
                break;
        }

        //default exit
        return transform.position;
    }

    public enum OriginSide { None, Left, Top, Bottom, Right }
}
