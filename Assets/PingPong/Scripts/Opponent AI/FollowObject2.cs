using UnityEngine;

public class FollowObject2 : MonoBehaviour
{
    [SerializeField] private Transform followObject;

    [SerializeField] private float speed = 10f;

    private Vector3 positionDifference;
    
    private void Start()
    {
        positionDifference = transform.position - followObject.position;
    }

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, followObject.position + positionDifference, speed * Time.deltaTime);
    }
}
