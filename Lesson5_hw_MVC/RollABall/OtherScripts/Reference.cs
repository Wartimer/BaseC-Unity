using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace RollABall.Player
{
    internal class Reference
    {
        private PlayerBall _playerBall;
        private Transform _mainCamera;
        private GameObject _scoreText;
        private GameObject _endGameLabel;
        private GameObject _buffsPanel;
        private Button _restartButton;
        private Canvas _canvas;

        
        public Button RestartButton
        {
            get
            {
                if (_restartButton == null)
                {
                    var button = Resources.Load<Button>("UI/RestartButton");
                    _restartButton = Object.Instantiate(button, Canvas.transform);
                }
                return _restartButton;
            }
        }
        
        public GameObject BuffsPanel
        {
            get
            {
                if (_buffsPanel == null)
                {
                    var gameObject = Resources.Load<GameObject>("UI/BuffsPanel");
                    _buffsPanel = Object.Instantiate(gameObject, Canvas.transform);
                }

                return _buffsPanel;
            }
        }
        
        public Canvas Canvas
        {
            get
            {
                if (_canvas == null)
                {
                    _canvas = UnityEngine.Object.FindObjectOfType<Canvas>();
                }

                return _canvas;
            }
        }

        public GameObject ScoreText
        {
            get
            {
                if (_scoreText == null)
                {
                    var gameObject = Resources.Load<GameObject>("UI/ScoreText");
                    _scoreText = Object.Instantiate(gameObject, Canvas.transform);
                }

                return _scoreText;
            }
        }

        public GameObject EndGameLabel
        {
            get
            {
                if (_endGameLabel == null)
                {
                    var gameObject = Resources.Load<GameObject>("UI/FinishGameLabel");
                    _endGameLabel = Object.Instantiate(gameObject, Canvas.transform);
                }

                return _endGameLabel;
            }
        }
        
        internal PlayerBall PlayerBall
        {
            get
            {
                if (_playerBall == null)
                {
                    var gameObject = Resources.Load<PlayerBall>("Player");
                    _playerBall = Object.Instantiate(gameObject, new Vector3(-4.05999994f,0.100000001f,-3.98000002f), Quaternion.identity);
                }

                return _playerBall;
            }
        }

        internal Transform MainCamera
        {
            get
            {
                if (_mainCamera == null)
                {
                    var gameObject = Resources.Load<Transform>("CameraHolder");
                    _mainCamera = UnityEngine.Object.Instantiate(gameObject, new Vector3(-4.21500015f,2.82800007f,-3.9525001f), quaternion.identity);
                    _mainCamera.localRotation = Quaternion.LookRotation(new Vector3(0f, -85f, 0f));
                }

                return _mainCamera;
            }
        }
    }
    
}