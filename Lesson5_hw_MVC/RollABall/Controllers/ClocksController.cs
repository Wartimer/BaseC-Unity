using UnityEngine;

namespace RollABall.Player
{
    public class ClocksController : IExecute
    {
        private GameObject _buffsPanel;

        public ClocksController(GameObject buffsPanel)
        {
            _buffsPanel = buffsPanel;
        }
        
        public void Execute()
        {
            BonusProcessor.ProcessDurations();
            ClocksProcessor.ProcessClocks();
        }
    }
}