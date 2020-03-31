using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Boid {
namespace Physics {

public class UpdateVelocity : MonoBehaviour {
    
    private Collection collection;

    void Start() {
        collection = GetComponent<Collection>();
    }

    void FixedUpdate() {
        foreach(var boid in collection.Boids)
            boid.Velocity += Time.deltaTime * boid.Acceleration;
    }
}

} // namespace Physics
} // namespace Boid
