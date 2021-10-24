using UnityEditor.AssetImporters;
using UnityEngine;

namespace RollABall.Player
{
    internal static class PlayerMatController
    {
        private static Material _baseMaterial;

        internal static Material BaseMaterial
        {
            get => _baseMaterial;
            private set => _baseMaterial = value;
        }
        internal static Material SwapMaterial(Material bonusMat)
        {
            return bonusMat;
        }

        internal static Material ReturnMaterial()
        {
            return _baseMaterial;
        }

        internal static void SetMaterial(Material playerMat)
        {
            BaseMaterial = playerMat;
        }

        internal static void ResetBaseMaterial()
        {
            _baseMaterial = null;
        }
    }
}