using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public LayerMask rayIgnoreLayer;
    public float damage = 1f;
    public Transform muzzle;
    public float fireInterval = 1f;
    float lastFireTime = 0f;
    AudioSource fireSFX;
    public AudioClip fireSFXClip;

    public List<ParticleSystem> muzzleFlash;
    public TrailRenderer tracerEffect;
    public ParticleSystem impactEffect;

    private void Awake()
    {
        fireSFX = GetComponent<AudioSource>();
        if (!fireSFX) fireSFX = gameObject.AddComponent<AudioSource>();
        fireSFX.playOnAwake = false;
        fireSFX.loop = false;

        muzzleFlash = GetComponentsInChildren<ParticleSystem>().ToList();
    }
    private void Update()
    {  
        if (Input.GetMouseButton(0))
        {
            Fire();
        }
    }

    public void Fire()
    {
        if (Time.time - lastFireTime < fireInterval)
            return;

        lastFireTime = Time.time;
        fireSFX.PlayOneShot(fireSFXClip);
        RaycastHit hit;
        var tracer = Instantiate(tracerEffect, muzzle.position, Quaternion.identity);
        tracer.AddPosition(muzzle.position);
        Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, float.MaxValue, ~rayIgnoreLayer);
        if (hit.collider)
        {
            tracer.transform.position = hit.point;
            GameObject hitObj = hit.collider.gameObject;
            Health health = hitObj.GetComponent<Health>();
            if(health != null)
            {
                Debug.Log(damage);
                health.TakeDamage(damage);
            }
            else if (hit.collider.GetComponent<OutcomeController>() != null)
            {
                // hit outcome
                hit.collider.GetComponent<OutcomeController>().OnSelectPrice();
            }
        }

        if (impactEffect)
        {
            impactEffect.transform.position = hit.transform.position;
            impactEffect.transform.forward = hit.normal;
            impactEffect.Emit(1);
        }

        # if UNITY_EDITOR
        Debug.Log(hit.collider);
        # endif

    }
}