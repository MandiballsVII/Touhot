using UnityEngine;
using UnityEngine.EventSystems;

public class HoverButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        // Acción al entrar: agrandar ligeramente
        //transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
        AudioManager.Instance.PlayOneShot(FMOD_Events.Instance.ButtonHover, transform.position);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // Acción al salir: volver al tamaño original
        //transform.localScale = Vector3.one;
    }
}
