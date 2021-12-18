using UnityEngine;
using PathCreation;

public class BirdsPath : MonoBehaviour 
{
    public PathCreator birdspath;
    public float speed = 2;
    float dist;
    
    void Update()
    {
    dist += speed * Time.deltaTime;
    transform.position = birdspath.path.GetPointAtDistance(dist);
    }
}
