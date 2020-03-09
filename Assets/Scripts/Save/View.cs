using UnityEngine;
using UnityEngine.UI;

namespace EZBall.Save
{
    internal class View : MonoBehaviour
    {
        [SerializeField] Text countText;

        internal void Set(int count)
        {
            this.countText.text = count.ToString();
        }
    }
}