using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Boid {
namespace Physics {

public class ResetAcceleration : MonoBehaviour {
    
    [SerializeField]
    private float coef = 0f;

    private Collection collection;

    void Start() {
        collection = GetComponent<Collection>();
    }

    void FixedUpdate() {
        foreach(var boid in collection.Boids)
            boid.Acceleration *= coef;
    }
}

} // namespace Physics
} // namespace Boid
