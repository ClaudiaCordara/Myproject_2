using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class train_castle : MonoBehaviour
{
    public PathCreator pathCreator;
    const float StartSpeed = 3.0f;    
    public float speed = StartSpeed;
    public float distanceTravelled;
    public EndOfPathInstruction end;
    private Vector3 startPosition = new Vector3(0.4f, 0, 0); //posizione iniziale trenino
    private Quaternion offset; //per sistemare la rotazione del trenino lungo il path
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (speed < 7.0f)
        {
            speed += 0.02f;
        }
        distanceTravelled += speed * Time.deltaTime;
        transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, end);
        offset = pathCreator.path.GetRotation(1);
        transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled, end) * offset * offset;
    }
}