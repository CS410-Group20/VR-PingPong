using UnityEngine;

public class FollowObject : MonoBehaviour
{
    public Transform followObject;

    public float speed = 10f;
    
    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, followObject.position, speed * Time.deltaTime);
    }
}
