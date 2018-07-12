using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade_Contact_Script : MonoBehaviour {

    public float ExplosionPow;
    public float ExplosionLift;
    public SphereCollider ExplosionArea;
    public List<Rigidbody> RigidsAffected;
    public int Damage;
    public List<GameObject> ObjectsDamaged;

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
		if (other.GetComponent<Rigidbody> () != null) 
		{
			RigidsAffected.Add (other.attachedRigidbody);
		}

        if (other.GetComponent<Health_Script> () != null)
        {
            ObjectsDamaged.Add (other.gameObject);
        }
    }

	private void OnTriggerExit(Collider other)
	{
		RigidsAffected.Remove(other.attachedRigidbody);
	}

    private void OnCollisionEnter(Collision collision)
    {
        foreach (Rigidbody added in RigidsAffected)
        {
            added.AddExplosionForce(ExplosionPow, _explosionPos, _explosionRad, ExplosionLift);
        }

        foreach (GameObject added in ObjectsDamaged)
        {
            Component _healthScript = added.GetComponent<Health_Script>();
        }

        //Destroy(gameObject);
    }
}
