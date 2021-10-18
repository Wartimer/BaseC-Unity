using System.Collections;
using UnityEngine;

namespace RollABall.Player
{
    internal sealed class CameraShaker : MonoBehaviour
    {
        internal IEnumerator Shake(float duration, float magnitude)
        {
            var originalPos = transform.localPosition;

            var elapsed = 0.0f;

            while (elapsed < duration)
            {
                var x = Random.Range(-1f, 1f) * magnitude;
                var y = Random.Range(-1f, 1f) * magnitude;

                transform.localPosition = new Vector3(x, y, originalPos.z);

                elapsed += Time.deltaTime;
                
                yield return null;
            }

            transform.localPosition = originalPos;
        }
    }
}