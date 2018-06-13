using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade_Contact_Script : MonoBehaviour {

    public float ExplosionPow;
    public float ExplosionLift;
    public SphereCollider ExplosionArea;
    public List<Rigidbody> ObjectsToAffect;

    private Vector3 _explosionPos;
    private float _explosionRad;
    public Rigidbody OtherRigid;

    void Start()
    {
        _explosionPos = transform.position;
        _explosionRad = ExplosionArea.radius;
    }

    private void OnTriggerEnter(Collider other)
    {
        ObjectsToAffect.Add(other.attachedRigidbody);
    }

    private void OnCollisionEnter(Collision collision)
    {
        foreach (Rigidbody added in ObjectsToAffect)
        {
            Rigidbody rb = added;
            rb.AddExplosionForce(ExplosionPow, _explosionPos, _explosionRad, ExplosionLift);
        }
    }
}
