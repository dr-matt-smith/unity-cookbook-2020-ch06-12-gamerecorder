using UnityEngine;

public class ExplodeChildren : MonoBehaviour
{
    public float magnitude = 200f;
    public float radius = 3f;

    private RecordTransformHierarchy _recordTransformHierarchy;

    private void Awake()
    {
        _recordTransformHierarchy = GetComponent<RecordTransformHierarchy>();
    }

    void Update()
    {
        if (Input.GetKeyUp("space"))
        {
            // enable animation recorder
            _recordTransformHierarchy.enabled = true;
            
            // add explosion force to child objects           
            Explode();
        }
    }
	
    private void Explode()
    {
        foreach(Transform child in transform.GetAllChildren()){
            Rigidbody2D rigidbody2D = child.GetComponent<Rigidbody2D>();
            rigidbody2D.AddExplosionForce(child.transform.position - transform.position, magnitude, radius);
        }
    }
	
}