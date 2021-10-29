using UnityEngine;

public class FollowObject : MonoBehaviour
{
    [SerializeField] private Transform followObject;

    [SerializeField] private float speed = 10f;
    
    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, followObject.position, speed * Time.deltaTime);
    }
}
