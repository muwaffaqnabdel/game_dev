using UnityEngine;

public class WheelController : MonoBehaviour
{
    public WheelCollider fl, fr, rl, rr;
    public Transform flMesh, frMesh, rlMesh, rrMesh;

    public float motorForce = 500f;

    void Update()
    {
        UpdateWheel(fl, flMesh);
        UpdateWheel(fr, frMesh);
        UpdateWheel(rl, rlMesh);
        UpdateWheel(rr, rrMesh);
    }

    void FixedUpdate()
    {
        float v = Input.GetAxis("Vertical");

        rl.motorTorque = v * motorForce;
        rr.motorTorque = v * motorForce;
    }

    void UpdateWheel(WheelCollider col, Transform mesh)
    {
        Vector3 pos;
        Quaternion rot;
        col.GetWorldPose(out pos, out rot);

        mesh.position = pos;
        mesh.rotation = rot;
    }
}