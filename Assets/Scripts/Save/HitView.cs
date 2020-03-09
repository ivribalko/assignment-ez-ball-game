using EZBall.Rife;
using UnityEngine;
using UnityEngine.UI;

namespace EZBall.Save
{
    internal class HitView : MonoBehaviour, IView
    {
        [SerializeField] Text countText;

        public void Show()
        {
            this.gameObject.SetActive(true);
        }

        public void Hide()
        {
            this.gameObject.SetActive(false);
        }

        internal void Set(int count)
        {
            this.countText.text = count.ToString();
        }
    }
}