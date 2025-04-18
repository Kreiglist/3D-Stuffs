using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXOnClick : MonoBehaviour
{
    [SerializeField] private AudioClip clickSound;

    private void OnMouseDown()
    {
        AudioSource.PlayClipAtPoint(clickSound, transform.position, 1f);
    }
}
