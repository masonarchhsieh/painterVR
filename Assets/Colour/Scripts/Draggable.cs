using UnityEngine;
using Leap.Unity;

public class Draggable : MonoBehaviour
{
    // add the hand obj;
	public bool fixX;
	public bool fixY;
    public Transform thumb;
    public FingerModel index;

    public Leap.Unity.ExtendedFingerDetector extendedFingerDetector;
	bool dragging;

	void FixedUpdate()
	{
        // If findger touch this
        bool standby_gesture = extendedFingerDetector.IsActive;
        if (standby_gesture) { 
        //if (Input.GetMouseButtonDown(0)) {
			dragging = false;
            Ray ray = index.GetRay();
            RaycastHit hit;
            //if (GetComponent<Collider>().Raycast(ray, out hit, Mathf.Infinity)) {
            if (GetComponent<Collider>().Raycast(ray, out hit, .05f)) {
				dragging = true;
			}
		}

        // If finger is not there
        if ((standby_gesture = extendedFingerDetector.IsActive) != true) dragging = false;
        //if (Input.GetMouseButtonUp(0)) dragging = false;
        if (dragging && standby_gesture)
        {
            Ray ray = index.GetRay();
            RaycastHit hit;
            //if (GetComponent<Collider>().Raycast(ray, out hit, Mathf.Infinity))
            if (GetComponent<Collider>().Raycast(ray, out hit, .05f))
            {
                //var point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                var point = hit.point;
                point = GetComponent<Collider>().ClosestPointOnBounds(point);
                SetThumbPosition(point);
                SendMessage("OnDrag", Vector3.one - (thumb.position - GetComponent<Collider>().bounds.min) / GetComponent<Collider>().bounds.size.x);
            }
        }
	}

	void SetDragPoint(Vector3 point)
	{
		point = (Vector3.one - point) * GetComponent<Collider>().bounds.size.x + GetComponent<Collider>().bounds.min;
		SetThumbPosition(point);
	}

	void SetThumbPosition(Vector3 point)
	{
		thumb.position = new Vector3(fixX ? thumb.position.x : point.x, fixY ? thumb.position.y : point.y, thumb.position.z);
	}

    void SetColorFromRemoteMenu(float temp)
    {
        Vector3 point =  ((Vector3.one) * temp) * GetComponent<Collider>().bounds.size.x + GetComponent<Collider>().bounds.min;
        SetThumbPosition(point);
    }

    void CalibrateThumb()
    {
        thumb.rotation = this.transform.rotation;
    }
}
