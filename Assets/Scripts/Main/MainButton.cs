using UnityEngine;
using UnityEngine.UI;

namespace EZBall.Main
{
    internal sealed class MainButton : MonoBehaviour
    {
        [SerializeField] Text text;
        [SerializeField] Button button;

        internal Button Button => this.button;

        internal MainButton Set(string text)
        {
            this.text.text = text;

            return this;
        }
    }
}