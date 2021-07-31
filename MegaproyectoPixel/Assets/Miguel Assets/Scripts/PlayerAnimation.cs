using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField]
    private Rig aimLayer;
    [SerializeField]
    private float aimDuration = 0.3f;
    private bool aimLayerBool;
    Animator animator;
    int velocityXHash, velocityZHash;
    float velocityZ,velocityX = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        velocityXHash = Animator.StringToHash("VelocityX");
        velocityZHash = Animator.StringToHash("VelocityZ");
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat(velocityXHash,velocityX);
        animator.SetFloat(velocityZHash,velocityZ);
        if(aimLayerBool){
            if(aimLayer.weight < 1.0f){
                aimLayer.weight += Time.deltaTime / aimDuration;
            }
        } else {
            if(aimLayer.weight > 0.0f){
                aimLayer.weight -= Time.deltaTime / aimDuration;
            }
        }
    }

    public void ChangeVelocity(float vx, float vz){
        velocityX = vx;
        velocityZ = vz;
    }

    public void enableAimLayer() {
        aimLayerBool = true;
    }

    public void disableAimLayer() {
        aimLayerBool = false;
    }
}
