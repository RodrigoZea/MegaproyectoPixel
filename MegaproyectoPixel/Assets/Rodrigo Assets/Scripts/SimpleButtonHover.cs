using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Due to Unity's button normal behavior not changing the text color as well on any event, a script was extracted from the internet.
// this was extracted from: https://answers.unity.com/questions/940456/how-to-change-text-color-on-hover-in-new-gui.html
[RequireComponent (typeof(Button))]
public class SimpleButtonHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    Text txt;
    Color baseColor;
    Button btn;
    bool interactableDelay;

    void Start ()
    {
        txt = GetComponentInChildren<Text>();
        baseColor = txt.color;
        btn = gameObject.GetComponent<Button> ();
        interactableDelay = btn.interactable;
    }

    void Update ()
    {
        if (btn.interactable != interactableDelay) {
            if (btn.interactable) {
                txt.color = baseColor * btn.colors.normalColor * btn.colors.colorMultiplier;
            } else {
                txt.color = baseColor * btn.colors.disabledColor * btn.colors.colorMultiplier;
            }
        }
        interactableDelay = btn.interactable;
    }

    public void OnPointerEnter (PointerEventData eventData)
    {
        if (btn.interactable) {
            txt.color = baseColor * btn.colors.highlightedColor * btn.colors.colorMultiplier;
        } else {
            txt.color = baseColor * btn.colors.disabledColor * btn.colors.colorMultiplier;
        }
    }

    public void OnPointerDown (PointerEventData eventData)
    {
        if (btn.interactable) {
            txt.color = baseColor * btn.colors.pressedColor * btn.colors.colorMultiplier;
        } else {
            txt.color = baseColor * btn.colors.disabledColor * btn.colors.colorMultiplier;
        }
    }

    public void OnPointerUp (PointerEventData eventData)
    {
        if (btn.interactable) {
            txt.color = baseColor * btn.colors.highlightedColor * btn.colors.colorMultiplier;
        } else {
            txt.color = baseColor * btn.colors.disabledColor * btn.colors.colorMultiplier;
        }
    }

    public void OnPointerExit (PointerEventData eventData)
    {
        if (btn.interactable) {
            txt.color = baseColor * btn.colors.normalColor * btn.colors.colorMultiplier;
        } else {
            txt.color = baseColor * btn.colors.disabledColor * btn.colors.colorMultiplier;
        }
    }

}