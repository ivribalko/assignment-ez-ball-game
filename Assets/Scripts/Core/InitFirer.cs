using UnityEngine;
using Zenject;

namespace EZBall.Core
{
    public class InitFirer : MonoBehaviour
    {
        private SignalBus signalBus;

        [Inject]
        private void InjectMeWith(SignalBus signalBus)
        {
            this.signalBus = signalBus;
        }

        private void Start()
        {
            this.signalBus.Fire<InitSignal>();
        }
    }
}