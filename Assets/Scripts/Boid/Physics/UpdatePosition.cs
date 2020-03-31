using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Boid {
namespace Physics {

public class UpdatePosition : MonoBehaviour {
    
    private Collection collection;

    void Start() {
        collection = GetComponent<Collection>();
    }

    void FixedUpdate() {
        foreach(var boid in collection.Boids)
            boid.Position += Time.deltaTime * boid.Velocity;
    }
}

} // namespace Physics
} // namespace Boid
