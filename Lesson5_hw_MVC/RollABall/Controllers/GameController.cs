using System;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RollABall.Player
{
    internal class GameController : MonoBehaviour, IDisposable
    {
        internal PlayerType PlayerType = PlayerType.Ball;
        private ListExecuteObject _interactiveObjects;
        private CameraController _cameraController;
        private InputController _inputController;
        private ClocksController _clocksController;
        private DisplayEndGame _displayEndGame;
        private DisplayPoints _displayPoints;
        private TrapsSpawner _trapsSpawner;
        private DeathTrap[] _traps;
        private Reference _reference;
        private int _countCoins;
        
        private void Awake()
        {
            
            _interactiveObjects = new ListExecuteObject();
            
            _reference = new Reference();
            
            Player player = null;

            if (PlayerType == PlayerType.Ball)
            {
                player = _reference.PlayerBall;
            }
            
            _cameraController = new CameraController(player.transform, _reference.MainCamera.transform);
            _interactiveObjects.AddExecuteObject(_cameraController);

            if (Application.platform == RuntimePlatform.WindowsEditor)
            {
                _inputController = new InputController(player);
                _interactiveObjects.AddExecuteObject(_inputController);
            }

            _displayEndGame = new DisplayEndGame(_reference.EndGameLabel);
            _displayPoints = new DisplayPoints(_reference.ScoreText);

            _clocksController = new ClocksController(_reference.BuffsPanel);
            _interactiveObjects.AddExecuteObject(_clocksController);
            
            foreach (var c in _interactiveObjects)
            {
                if (c is Coin coin)
                    coin.CoinGathered += AddBonuses;
            }
            
            _reference.RestartButton.onClick.AddListener(RestartGame);
            _reference.RestartButton.gameObject.SetActive(false);

            TrapsSpawner.TrapsSpawned += OnTrapsSpawned;
            Player.PlayerWin += OnPlayerWin;
            BonusProcessor.DurationEnd += ClocksProcessor.OnBonusDurationEnd;

        }

        private void Start()
        {
            ClocksProcessor.SortClocks();
            ClocksProcessor.TurnOffClocks();
        }

        private void Update()
        {
            for (var i = 0; i < _interactiveObjects.Length; i++)
            {
                var interactiveObject = _interactiveObjects[i];
                if (interactiveObject == null) continue;
                
                interactiveObject.Execute();
            }
        }
        
        public void Dispose()
        {
            Player.PlayerWin -= OnPlayerWin;
            BonusProcessor.DurationEnd -= ClocksProcessor.OnBonusDurationEnd;
            
            foreach (var t in _traps)
            {
                if (t is null) continue;
                t.CaughtPlayer -= CaughtPlayer;
                t.CaughtPlayer -= _displayEndGame.GameOver;
                Destroy(t.gameObject);
            }
            
            foreach (var c in _interactiveObjects)
            {
                if (c is Coin coin)
                    coin.CoinGathered -= AddBonuses;
            }
        }

        #region Game EventHandlers
        
        private void RestartGame()
        {
            SceneManager.LoadScene(0);
            Time.timeScale = 1f;
        }
        
        private void AddBonuses(int value)
        {
            _countCoins += value;
            _displayPoints.Display(_countCoins);
        }
        
        private void OnPlayerWin(object sender, PlayerWinEventArgs e)
        {
            _reference.RestartButton.gameObject.SetActive(true);
            _displayEndGame.Win(e.Points);
            ClocksProcessor.ClearListOfClocks();
            Time.timeScale = 0.0f;
        }

        private void CaughtPlayer(object value, Player player)
        {
            _reference.RestartButton.gameObject.SetActive(true);
            ClocksProcessor.ClearListOfClocks();
            player.Dispose();
            Time.timeScale = 0.0f;
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
