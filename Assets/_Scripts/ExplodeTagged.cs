using UnityEngine;

public class ExplodeTagged : MonoBehaviour
{
    public RecordTransformHierarchy recordTransformHierarchy;
    public float magnitude = 200f;
    public float radius = 3f;

    private GameObject[] _gameObjects;    

    private void Awake()
    {
        _gameObjects = GameObject.FindGameObjectsWithTag("Block");
    }

    void Update()
    {
        if (Input.GetKeyUp("space"))
        {
            // enable animation recorder
            recordTransformHierarchy.enabled = true;
            
            // add explosion force to child objects           
            Explode();
        }
    }
	
    private void Explode()
    {
        foreach(GameObject gameObject in _gameObjects){
            Rigidbody2D rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
            rigidbody2D.AddExplosionForce(gameObject.transform.position - transform.position, magnitude, radius);
        }
    }
	
}