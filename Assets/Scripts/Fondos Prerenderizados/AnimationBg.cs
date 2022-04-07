using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationBg : MonoBehaviour
{
    [SerializeField] float velocidad = 1.5f;
    [SerializeField] List<Sprite> spritesToSwap;
    SpriteRenderer spriteRenderer;

    private void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    IEnumerator SwapSprites() {
    int spriteIndex = 0;
    while (true) {
        spriteRenderer.sprite = spritesToSwap[spriteIndex];
            // ^ replace the sprite
        spriteIndex++;
        if (spriteIndex == spritesToSwap.Count) spriteIndex = 0;
            // ^ loop back to first sprite
        yield return new WaitForSeconds(velocidad); // adjust this time as desired
        }
    }

    private void OnEnable() {
        StartCoroutine("SwapSprites");
    }

    private void OnDisable() {
        StopCoroutine("SwapSprites");
    }

}
