using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UPhysics = UnityEngine.Physics;

namespace Boid {
namespace Behaviour {

public class ObstacleAvoidance : MonoBehaviour {

    [SerializeField]
    private float intensity = 0f;

    [SerializeField]
    private float distance = 0f;

    [SerializeField]
    private float anticipationDistance = 0f;

    [SerializeField]
    private float maneuverDistance = 0f;

    [SerializeField]
    private float radius = 1f;

    private List<Vector3> maneuvers = new List<Vector3>();

    private Collection collection;

    public void Start() {
        collection = GetComponent<Collection>();

        maneuvers.Add(new Vector3(0, -1, 0));
        maneuvers.Add(new Vector3(0, 1, 0));
        maneuvers.Add(new Vector3(-1, 0, 0));
        maneuvers.Add(new Vector3(1, 0, 0));
    }

    public void FixedUpdate() {
        foreach(var boid in collection.Boids) {
            if(UPhysics.Raycast(boid.Position, boid.Direction, anticipationDistance)) {
                Debug.DrawLine(boid.Position, boid.Position + anticipationDistance * boid.Direction, Color.red);
               foreach(var dir in maneuvers) {
                   var globalDir = boid.Rotation * dir;
                   
                   if(!UPhysics.SphereCast(new Ray(boid.Position, globalDir), 1f, maneuverDistance)) {
                       Debug.DrawLine(boid.Position, boid.Position + maneuverDistance * globalDir, Color.green);
                       boid.Acceleration += globalDir * intensity;
                       break;
                   }
                   else {
                       Debug.DrawLine(boid.Position, boid.Position + maneuverDistance * globalDir, Color.red);
                   }
               }
            }
            else {
                Debug.DrawLine(boid.Position, boid.Position + anticipationDistance * boid.Direction, Color.green);
            }
        }
    }
}

} // namespace Behaviour
} // namespace Boid
