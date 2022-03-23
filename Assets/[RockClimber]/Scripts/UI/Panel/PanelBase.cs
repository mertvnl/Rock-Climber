using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public abstract class PanelBase : MonoBehaviour
{
    private CanvasGroup canvasGroup;
    public CanvasGroup CanvasGroup { get { return canvasGroup == null ? canvasGroup = GetComponent<CanvasGroup>() : canvasGroup; } }

    private const float FADE_DELAY = 0.5f;

    public virtual void ShowPanel()
    {
        CanvasGroup.DOFade(1, FADE_DELAY)
            .OnComplete(()=>
            {
                CanvasGroup.interactable = true;
                CanvasGroup.blocksRaycasts = true;
            }).SetTarget(transform);
    }

    public virtual void HidePanel()
    {
        CanvasGroup.DOFade(0, FADE_DELAY)
            .OnComplete(() =>
            {
                CanvasGroup.interactable = false;
                CanvasGroup.blocksRaycasts = false;
            }).SetTarget(transform);
    }

    private void OnDestroy()
    {
        DOTween.Kill(transform);
    }
}
