using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Boid {
namespace Behaviours {

public class Alignement : MonoBehaviour {

    //Structure de boid pour envoyer les informations au shader
    private struct alignementBoids{
        public Vector3 position, acceleration;
    }
    
    [SerializeField]
    public ComputeShader cshader;

    [SerializeField]
    private float intensity = 0f;

    [SerializeField]
    private float radius = 0f;
    
    private alignementBoids[] alignementData;
    private Collection collection;

    private int kernelHandle;

    private ComputeBuffer alignementBuffer;

    void Start() {
        collection = GetComponent<Collection>();
        kernelHandle = cshader.FindKernel("AlignementKernel"); //Initialise l'index du kernel
        alignementBuffer = new ComputeBuffer(collection.Count, 3*2*sizeof(float));
    }

    void FixedUpdate() {
        //Crée le tableau de positions et acceleration de boids de cette frame
        this.alignementData = new alignementBoids[collection.Count];
        int boidsCount = 0;
        foreach(var current in collection.Boids) {
            alignementData[boidsCount].position = current.Position;
            alignementData[boidsCount].acceleration = current.Acceleration;
            boidsCount++;
        }
        //Met a jour le buffer d'alignement
        alignementBuffer.SetData(this.alignementData);

        //Met a jour le shader
        cshader.SetBuffer(this.kernelHandle, "currentBuffer", alignementBuffer);
        cshader.SetFloat("intensity", intensity);
        cshader.SetFloat("radius", radius);
        cshader.SetFloat("boidsCount", boidsCount);

        //Execute le shader
        cshader.Dispatch(this.kernelHandle, collection.Count, 1, 1);

        //Recupère les infos du shader une fois les calculs finis et désalloue le buffer
        alignementBuffer.GetData(this.alignementData);

        //Met a jour chaque boids
        boidsCount = 0;
        foreach(var current in collection.Boids) {
            current.Acceleration +=  alignementData[boidsCount].acceleration;
            boidsCount++;
        }
    }
    void OnDestroy(){
            alignementBuffer.Release();
        }
}

} // namespace Behaviour
} // namespace Boid
