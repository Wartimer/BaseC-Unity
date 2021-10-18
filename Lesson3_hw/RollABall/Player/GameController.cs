using System;
using System.Linq;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace RollABall.Player
{
    public class GameController : MonoBehaviour, IDisposable
    {
        public Text _finishGameLabel; 
        private InterObjContainer _interactiveObjects;
        private DisplayEndGame _displayEndGame;
        private DeathTrap[] _traps;
        private void Awake()
        {
            _interactiveObjects = new InterObjContainer();
            _interactiveObjects.Subscribe(FindObjectsOfType<InteractiveObject>());
            _displayEndGame = new DisplayEndGame(_finishGameLabel);
            
            TrapsSpawner.TrapsSpawned += OnTrapsSpawned;
            Player.PlayerWin += OnPlayerWin;
            BonusProcessor.DurationEnd += ClocksProcessor.OnBonusDurationEnd;
            InterObjContainer.BonusesSubscribed += OnBonusesSubscribed;

        }
        
        private void Start()
        {
            ClocksProcessor.SortClocks();
            ClocksProcessor.TurnOffClocks();
        }

        private void Update()
        {
            
            for (var i = 0; i <= _interactiveObjects.numberOfBonuses; i++)
            {
                var interactiveObject = _interactiveObjects[i];
                
                if(interactiveObject == null) continue;
                
                if(interactiveObject is IFlay flay) flay.Flay();
                
                if(interactiveObject is IFlicker flicker) flicker.Flicker();
                
                if(interactiveObject is IRotation rotation) rotation.Rotation();
            }
            
            BonusProcessor.ProcessDurations();
            ClocksProcessor.ProcessClocks();
        }
        
        public void Dispose()
        {
            TrapsSpawner.TrapsSpawned -= OnTrapsSpawned;
            Player.PlayerWin -= OnPlayerWin;
            BonusProcessor.DurationEnd -= ClocksProcessor.OnBonusDurationEnd;
            InterObjContainer.BonusesSubscribed -= OnBonusesSubscribed;
            
            foreach (var t in _traps)
            {
                if (t is null) continue;
                t.CaughtPlayer -= CaughtPlayer;
                t.CaughtPlayer -= _displayEndGame.GameOver;
                Destroy(t.gameObject);
            }
            
            for (var i = 0; i <= _interactiveObjects.numberOfBonuses; i++)
            {
                var io = _interactiveObjects[i];
                if (io == null) continue;
                Destroy(io.gameObject);
            }

        }

        #region EventHandlers
        private void OnPlayerWin(object sender, PlayerWinEventArgs e)
        {
            _displayEndGame.Win(e.Points);
            Time.timeScale = 0.0f;
        }

        private void CaughtPlayer(object value)
        {
            Time.timeScale = 0.0f;
        }
        
        private void OnBonusesSubscribed(object sender, InterObjContainerEventArgs e)
        {
            for (var i = 0; i <= _interactiveObjects.numberOfBonuses; i++)
            {
                var io = _interactiveObjects[i];
                if (io == null) continue;
            }
        }
        
        private void OnTrapsSpawned()
        {
            _traps = FindObjectsOfType<DeathTrap>();
            foreach (var t in _traps)
            {
                t.CaughtPlayer += CaughtPlayer;
                t.CaughtPlayer += _displayEndGame.GameOver;
            }
        }
        
        #endregion
    }
}
