using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.UI;

public class AimOptions : MonoBehaviour
{
    [SerializeField] 
    private Slider aimSlider;
    [SerializeField]
    private Text aimSliderText;
    [SerializeField]
    private Cinemachine.CinemachineVirtualCamera aimCamera;
    [SerializeField] 
    private Slider lookSlider;
    [SerializeField]
    private Text lookSliderText;
    [SerializeField]
    private Cinemachine.CinemachineVirtualCamera lookCamera;
    // Start is called before the first frame update
    void Start()
    {
        aimSlider.value = aimCamera.GetCinemachineComponent<CinemachinePOV>().m_VerticalAxis.m_MaxSpeed;
        lookSlider.value = lookCamera.GetCinemachineComponent<CinemachinePOV>().m_VerticalAxis.m_MaxSpeed;
        aimSliderText.text = aimSlider.value.ToString();
        lookSliderText.text = lookSlider.value.ToString();
        

        aimSlider.onValueChanged.AddListener((v) => {
            aimSliderText.text = v.ToString("0.00");
            aimCamera.GetCinemachineComponent<CinemachinePOV>().m_VerticalAxis.m_MaxSpeed = v;
            aimCamera.GetCinemachineComponent<CinemachinePOV>().m_HorizontalAxis.m_MaxSpeed = v;
        });

        lookSlider.onValueChanged.AddListener((v) => {
            lookSliderText.text = v.ToString("0.00");
            lookCamera.GetCinemachineComponent<CinemachinePOV>().m_VerticalAxis.m_MaxSpeed = v;
            lookCamera.GetCinemachineComponent<CinemachinePOV>().m_HorizontalAxis.m_MaxSpeed = v;
        });
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
