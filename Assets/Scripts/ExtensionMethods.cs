using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Utils
{
    public static class ExtensionMethods
    {

        #region Tweening

        #region Rotation

        public static Coroutine DORotation(this MonoBehaviour self, Transform target, Vector3 endValue, float duration, float delay,
            AnimationCurve ease, bool isLocal = true, Action OnComplete = null)
        {
            return self.StartCoroutine(DORotationRoutine(target, endValue, duration, delay, ease, isLocal, OnComplete));
        }

        private static IEnumerator DORotationRoutine(Transform target, Vector3 endValue, float duration, float delay,
            AnimationCurve ease, bool isLocal = true, Action OnComplete = null)
        {
            if (delay > 0)
            {
                yield return new WaitForSeconds(delay);
            }

            float epsilon = 0;
            Quaternion startValue = isLocal ? target.localRotation : target.rotation;
            Quaternion endQ = Quaternion.Euler(endValue);
            if (isLocal)
            {
                while (epsilon < duration)
                {
                    epsilon += Time.deltaTime;
                    float t = epsilon / duration;
                    target.localRotation = Quaternion.Slerp(startValue, endQ, ease.Evaluate(t));
                    yield return null;
                }
                target.localRotation = endQ;
            }
            else
            {
                while (epsilon < duration)
                {
                    epsilon += Time.deltaTime;
                    float t = epsilon / duration;
                    target.rotation = Quaternion.Slerp(startValue, endQ, ease.Evaluate(t));
                    yield return null;
                }

                target.rotation = endQ;
            }
            OnComplete?.Invoke();
        }

        #endregion

        #region Scale

        public static Coroutine DoScale(this MonoBehaviour self, Transform target, Vector3 endValue, float duration, float delay,
            AnimationCurve ease, Action OnComplete = null)
        {
            return self.StartCoroutine(DOScaleRoutine(target, endValue, duration, delay, ease, OnComplete));
        }

        private static IEnumerator DOScaleRoutine(Transform target, Vector3 endValue, float duration, float delay,
            AnimationCurve ease, Action OnComplete = null)
        {
            if (delay > 0)
            {
                yield return new WaitForSeconds(delay);
            }

            float epsilon = 0;
            Vector3 startValue = target.localScale;
            while (epsilon < duration)
            {
                epsilon += Time.deltaTime;
                float t = epsilon / duration;
                target.localScale = Vector3.Lerp(startValue, endValue, ease.Evaluate(t));
                yield return null;
            }

            target.localScale = endValue;
            OnComplete?.Invoke();
        }

        #endregion

        #region Fade

        public static Coroutine DoFade(this MonoBehaviour self, Graphic target, float endValue, float duration, float delay,
            AnimationCurve ease, Action OnComplete = null)
        {
            return self.StartCoroutine(DOFadeRoutine(target, endValue, duration, delay, ease, OnComplete));
        }

        private static IEnumerator DOFadeRoutine(Graphic target, float endValue, float duration, float delay,
            AnimationCurve ease, Action OnComplete = null)
        {
            if (delay > 0)
            {
                yield return new WaitForSeconds(delay);
            }

            float epsilon = 0;
            Color startColor = target.color;
            Color endColor = startColor;
            endColor.a = endValue;
            while (epsilon < duration)
            {
                epsilon += Time.deltaTime;
                float t = epsilon / duration;
                target.color = Color.Lerp(startColor, endColor, ease.Evaluate(t));
                yield return null;
            }

            target.color = endColor;
            OnComplete?.Invoke();
        }

        #endregion

        #endregion
    }
}