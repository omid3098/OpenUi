using System;
using Prime31.ZestKit;
using UnityEngine;

namespace OpenUi.Transition
{
    public static class TransformExtention
    {
        #region Fade
        /// <summary>
        /// Fades In a Ui Transform using CanvasGroup component
        /// </summary>
        /// <param name="transform">self transform to fade in</param>
        /// <param name="duration">fading duration time in seconds</param>
        /// <param name="easeType">fading easeType</param>
        /// <param name="onCompleteCallback">callback on tween completion</param>
        /// <param name="blockRaycast">block Raycasts during tween time?</param>
        /// <returns>returns ITween<float> that can be used for other purposes.</returns>
        public static ITween<float> FadeIn(this Transform transform,
            float duration,
            EaseType easeType = EaseType.Linear,
            Action onCompleteCallback = null,
            bool blockRaycast = false)
        {
            CanvasGroup image = InitCanvasGroup(transform, blockRaycast);
            image.alpha = 0;
            ITween<float> tween = image.ZKalphaTo(1f, duration);
            tween.setEaseType(easeType);
            tween.setCompletionHandler((t) =>
            {
                if (onCompleteCallback != null)
                    onCompleteCallback.Invoke();
                image.blocksRaycasts = true;
            });
            tween.start();
            return tween;
        }

        /// <summary>
        /// Fades out a Ui Transform using CanvasGroup component
        /// </summary>
        /// <param name="transform">self transform to fade out</param>
        /// <param name="duration">fading duration time in seconds</param>
        /// <param name="easeType">fading easeType</param>
        /// <param name="onCompleteCallback">callback on tween completion</param>
        /// <param name="deactiveOnComplete">Whether deactive object when fade out completed?</param>
        /// <param name="blockRaycast">block Raycasts during tween time?</param>
        /// <returns>returns ITween<float> that can be used for other purposes.</returns>
        public static ITween<float> FadeOut(this Transform transform,
            float duration,
            EaseType easeType = EaseType.Linear,
            Action onCompleteCallback = null,
            bool deactiveOnComplete = false,
            bool blockRaycast = false)
        {
            CanvasGroup image = InitCanvasGroup(transform, blockRaycast);
            image.alpha = 1;
            ITween<float> tween = image.ZKalphaTo(0f, duration);
            tween.setEaseType(easeType);
            tween.setCompletionHandler((t) =>
            {
                if (onCompleteCallback != null)
                    onCompleteCallback.Invoke();
                image.blocksRaycasts = true;
                if (deactiveOnComplete)
                    transform.gameObject.SetActive(false);
            });
            tween.start();
            return tween;
        }
        #endregion

        #region Scale
        /// <summary>
        /// Scale In a Ui Transform
        /// </summary>
        /// <param name="transform">self transform</param>
        /// <param name="duration">scale tween duration</param>
        /// <param name="easeType">tween easeType</param>
        /// <param name="onCompleteCallback">scale in completion callback</param>
        /// <param name="blockRaycast">block raycasts during tweening</param>
        /// <returns>returns ITween<Vector3> that can be used for other purposes.</returns>
        public static ITween<Vector3> ScaleIn(this Transform transform,
            float duration,
            EaseType easeType = EaseType.Linear,
            Action onCompleteCallback = null,
            bool blockRaycast = false)
        {
            CanvasGroup image = InitCanvasGroup(transform, blockRaycast);
            transform.localScale = new Vector2(0, 0);
            ITween<Vector3> tween = transform.ZKlocalScaleTo(new Vector3(1, 1, 1), duration);
            FillInTween(easeType, onCompleteCallback, image, tween);
            return tween;
        }
        /// <summary>
        /// Scale Out a Ui Transform
        /// </summary>
        /// <param name="transform">self transform</param>
        /// <param name="duration">scale tween duration</param>
        /// <param name="easeType">tween easeType</param>
        /// <param name="onCompleteCallback">scale out completion callback</param>
        /// <param name="blockRaycast">block raycasts during tweening</param>
        /// <returns>returns ITween<Vector3> that can be used for other purposes.</returns>
        public static ITween<Vector3> ScaleOut(this Transform transform,
            float duration,
            EaseType easeType = EaseType.Linear,
            Action onCompleteCallback = null,
            bool deactiveOnComplete = false,
            bool blockRaycast = false)
        {
            CanvasGroup image = InitCanvasGroup(transform, blockRaycast);
            ITween<Vector3> tween = transform.ZKlocalScaleTo(new Vector3(0, 0, 0), duration);
            FillOutTween(transform, easeType, onCompleteCallback, deactiveOnComplete, image, tween);
            return tween;
        }

        /// <summary>
        /// Scale In along X a Ui Transform
        /// </summary>
        /// <param name="transform">self transform</param>
        /// <param name="duration">scale tween duration</param>
        /// <param name="easeType">tween easeType</param>
        /// <param name="onCompleteCallback">scale in completion callback</param>
        /// <param name="blockRaycast">block raycasts during tweening</param>
        /// <returns>returns ITween<Vector3> that can be used for other purposes.</returns>
        public static ITween<Vector3> ScaleInX(this Transform transform,
            float duration,
            EaseType easeType = EaseType.Linear,
            Action onCompleteCallback = null,
            bool blockRaycast = false)
        {
            CanvasGroup image = InitCanvasGroup(transform, blockRaycast);
            transform.localScale = new Vector2(0, 1);
            ITween<Vector3> tween = transform.ZKlocalScaleTo(new Vector3(1, 1, 1), duration);
            FillInTween(easeType, onCompleteCallback, image, tween);
            return tween;
        }

        /// <summary>
        /// Scale Out along X a Ui Transform
        /// </summary>
        /// <param name="transform">self transform</param>
        /// <param name="duration">scale tween duration</param>
        /// <param name="easeType">tween easeType</param>
        /// <param name="onCompleteCallback">scale out completion callback</param>
        /// <param name="blockRaycast">block raycasts during tweening</param>
        /// <returns>returns ITween<Vector3> that can be used for other purposes.</returns>
        public static ITween<Vector3> ScaleOutX(this Transform transform,
            float duration,
            EaseType easeType = EaseType.Linear,
            Action onCompleteCallback = null,
            bool deactiveOnComplete = false,
            bool blockRaycast = false)
        {
            var image = InitCanvasGroup(transform, blockRaycast);
            ITween<Vector3> tween = transform.ZKlocalScaleTo(new Vector2(0, 1), duration);
            FillOutTween(transform, easeType, onCompleteCallback, deactiveOnComplete, image, tween);
            return tween;
        }

        /// <summary>
        /// Scale In along Y a Ui Transform
        /// </summary>
        /// <param name="transform">self transform</param>
        /// <param name="duration">scale tween duration</param>
        /// <param name="easeType">tween easeType</param>
        /// <param name="onCompleteCallback">scale in completion callback</param>
        /// <param name="blockRaycast">block raycasts during tweening</param>
        /// <returns>returns ITween<Vector3> that can be used for other purposes.</returns>
        public static ITween<Vector3> ScaleInY(this Transform transform,
            float duration,
            EaseType easeType = EaseType.Linear,
            Action onCompleteCallback = null,
            bool blockRaycast = false)
        {
            CanvasGroup image = InitCanvasGroup(transform, blockRaycast);
            transform.localScale = new Vector2(1, 0);
            ITween<Vector3> tween = transform.ZKlocalScaleTo(new Vector3(1, 1, 1), duration);
            FillInTween(easeType, onCompleteCallback, image, tween);
            return tween;
        }

        /// <summary>
        /// Scale Out along Y a Ui Transform
        /// </summary>
        /// <param name="transform">self transform</param>
        /// <param name="duration">scale tween duration</param>
        /// <param name="easeType">tween easeType</param>
        /// <param name="onCompleteCallback">scale out completion callback</param>
        /// <param name="blockRaycast">block raycasts during tweening</param>
        /// <returns>returns ITween<Vector3> that can be used for other purposes.</returns>
        public static ITween<Vector3> ScaleOutY(this Transform transform,
            float duration,
            EaseType easeType = EaseType.Linear,
            Action onCompleteCallback = null,
            bool deactiveOnComplete = false,
            bool blockRaycast = false)
        {
            var image = InitCanvasGroup(transform, blockRaycast);
            ITween<Vector3> tween = transform.ZKlocalScaleTo(new Vector2(1, 0), duration);
            FillOutTween(transform, easeType, onCompleteCallback, deactiveOnComplete, image, tween);
            return tween;
        }
        #endregion

        #region Slide
        public static ITween<Vector3> SlideIn(this Transform transform,
            float duration,
            EaseType easeType = EaseType.Linear,
            Action onCompleteCallback = null,
            bool deactiveOnComplete = false,
            bool blockRaycast = false,
            slideDirection direction = slideDirection.up)
        {
            CanvasGroup image = InitCanvasGroup(transform, blockRaycast);
            var xOffset = Screen.width;
            var yOffset = Screen.height;
            var startPos = transform.position;
            switch (direction)
            {
                case slideDirection.left:
                    transform.position += new Vector3(-xOffset, 0f);
                    break;
                case slideDirection.right:
                    transform.position += new Vector3(xOffset, 0f);
                    break;
                case slideDirection.up:
                    transform.position += new Vector3(0, yOffset);
                    break;
                case slideDirection.down:
                    transform.position += new Vector3(0, -yOffset);
                    break;
            }
            ITween<Vector3> tween = transform.ZKpositionTo(startPos, duration);
            FillOutTween(transform, easeType, onCompleteCallback, deactiveOnComplete, image, tween);
            return tween;
        }
        public static ITween<Vector3> SlideOut(this Transform transform,
            float duration,
            EaseType easeType = EaseType.Linear,
            Action onCompleteCallback = null,
            bool deactiveOnComplete = false,
            bool blockRaycast = false,
            slideDirection direction = slideDirection.up)
        {
            CanvasGroup image = InitCanvasGroup(transform, blockRaycast);
            var xOffset = Screen.width;
            var yOffset = Screen.height;
            var startPos = transform.position;
            var destPos = transform.position;
            switch (direction)
            {
                case slideDirection.left:
                    destPos += new Vector3(-xOffset, 0f);
                    break;
                case slideDirection.right:
                    destPos += new Vector3(xOffset, 0f);
                    break;
                case slideDirection.up:
                    destPos += new Vector3(0, yOffset);
                    break;
                case slideDirection.down:
                    destPos += new Vector3(0, -yOffset);
                    break;
            }
            ITween<Vector3> tween = transform.ZKpositionTo(destPos, duration);
            tween.setEaseType(easeType);
            tween.setCompletionHandler((t) =>
            {
                if (onCompleteCallback != null)
                    onCompleteCallback.Invoke();
                image.blocksRaycasts = true;
                transform.position = startPos;
                if (deactiveOnComplete)
                    transform.gameObject.SetActive(false);
            });
            tween.start();
            return tween;
        }
        #endregion

        private static CanvasGroup InitCanvasGroup(Transform transform, bool blockRaycast)
        {
            if (!transform.gameObject.activeInHierarchy) transform.gameObject.SetActive(true);
            var image = transform.GetComponent<CanvasGroup>();
            if (image == null) image = transform.gameObject.AddComponent<CanvasGroup>();
            image.alpha = 1;
            image.blocksRaycasts = blockRaycast;
            transform.localScale = new Vector3(1, 1, 1);
            return image;
        }
        private static void FillInTween(EaseType easeType, Action onCompleteCallback, CanvasGroup image, ITween<Vector3> tween)
        {
            tween.setEaseType(easeType);
            tween.setCompletionHandler((t) =>
            {
                if (onCompleteCallback != null)
                    onCompleteCallback.Invoke();
                image.blocksRaycasts = true;
            });
            tween.start();
        }
        private static void FillOutTween(Transform transform, EaseType easeType, Action onCompleteCallback, bool deactiveOnComplete, CanvasGroup image, ITween<Vector3> tween)
        {
            tween.setEaseType(easeType);
            tween.setCompletionHandler((t) =>
            {
                if (onCompleteCallback != null)
                    onCompleteCallback.Invoke();
                image.blocksRaycasts = true;
                if (deactiveOnComplete)
                    transform.gameObject.SetActive(false);
            });
            tween.start();
        }
    }
}