using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Boid {

public class Data : MonoBehaviour {

    // attributes
    public int team;
    public float reloadLaser;
    private Vector3 acceleration = Vector3.zero;

    // unit vector
    [SerializeField]
    private Vector3 direction = Vector3.forward;

    [SerializeField]
    private float speed = 1f;

    public Vector3 Acceleration {
        get => acceleration;
        set {
            acceleration = value;
        }
    }

    public Vector3 Direction {
        get => direction;
        set {
            direction = value.normalized;
        }
    }

    public Vector3 Position {
        get => transform.position;
        set {
            transform.position = value;
        }
    }

    public Quaternion Rotation {
        get => Quaternion.FromToRotation(Vector3.forward, direction);
    }

    public float Speed {
        get => speed;
        set {
            speed = value;
        }
    }

    public Vector3 Velocity {
        get => speed * direction;
        set {
            speed = value.magnitude;
            if(speed != 0)
                direction = value / speed;
        }
    }

    static public float Distance(Data a, Data b) {
        return Vector3.Distance(a.Position, b.Position);
    }
}

} // namespace Boid
