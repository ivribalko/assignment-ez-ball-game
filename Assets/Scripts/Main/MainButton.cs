using UnityEngine;
using UnityEngine.UI;

namespace EZBall.Main
{
    internal partial class MainButton : MonoBehaviour
    {
        [SerializeField] private Text text;
        [SerializeField] private Button button;

        internal MainButton SetText(string text)
        {
            this.text.text = text;

            return this;
        }

        internal MainButton SetParent(Transform parent)
        {
            this.transform.SetParent(parent);
            this.transform.localScale = Vector3.one;

            return this;
        }
    }
}