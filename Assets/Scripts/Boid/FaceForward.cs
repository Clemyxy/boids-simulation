using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceForward : MonoBehaviour {
    private Boid.Data parent;

    void Start() {
        parent = GetComponentInParent<Boid.Data>();
    }

    void Update() {
        transform.rotation = Quaternion.LookRotation(parent.Direction);
    }
}
