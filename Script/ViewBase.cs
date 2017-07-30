using OpenUi.Transition;
using UnityEngine;

namespace OpenUi
{
    [RequireComponent(typeof(ShowTransition))]
    [RequireComponent(typeof(HideTransition))]
    public class ViewBase : MonoBehaviour
    {
        protected ShowTransition showTransition;
        protected HideTransition hideTransition;

        protected virtual void Awake()
        {
            showTransition = GetComponent<ShowTransition>();
            hideTransition = GetComponent<HideTransition>();
        }
    }
}