using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

namespace LD50.ToolTip
{
    public class ToolTipController : MonoBehaviour
    {
        [Header("Tooltip UI")]
        /// <summary> The background image, which will be rescaled and colored to fit accordingly. </summary>
        [SerializeField]
        [Tooltip("The background image behind the tooltip, which will be colored according to the displayed tooltip.")]
        private Image backgroundImage;

        /// <summary> The text component containing the tooltip. </summary>
        [SerializeField] [Tooltip("The text component containing the tooltip")]
        private TextMeshProUGUI toolTipText;

        [Header("Settings")]
        /// <summary> The margin left around the tooltip text. </summary>
        [SerializeField]
        [Tooltip("The margin left around the tooltip text.")]
        private Vector4 margin;

        private ToolTipInfo _lastToolTip;
        private float _width, _height;
        private string _text;
        private Camera _camera;

        private void Start()
        {
            _camera = Camera.main;
            if (backgroundImage.sprite && backgroundImage.type != Image.Type.Sliced)
            {
                Debug.LogWarning("Consider using a sliced sprite as a background image as it will be rescaled.");
            }
        }

        private void Update()
        {
            backgroundImage.gameObject.SetActive(false);

            var eventData = new PointerEventData(EventSystem.current)
            {
                position = Input.mousePosition
            };

            var results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(eventData, results);

            if (results.Count == 0)
            {
                var ray = _camera.ScreenPointToRay(Input.mousePosition);
                // 2D
                var r2D = Raycast2D(ray);
                if (!r2D.Equals(new RaycastResult())) results.Add(r2D);

                // 3D
                var r3D = Raycast3D(ray);
                if (!r3D.Equals(new RaycastResult())) results.Add(r3D);
            }


            var (toolTipToDisplay, screenPosition) = results
                .Select(r => (toolTip: r.gameObject.GetComponent<ToolTipInfo>(), r.screenPosition))
                .FirstOrDefault(t => t.toolTip && t.toolTip.ShowToolTip());


            if (!toolTipToDisplay) return;
            if (!toolTipToDisplay.Equals(_lastToolTip))
            {
                _text = toolTipToDisplay.GetToolTipText();
                (_width, _height) = toolTipToDisplay.CalculateSize(_text, (margin.x, margin.y, margin.z, margin.w));

                toolTipText.text = _text;
                backgroundImage.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, _width);
                backgroundImage.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, _height);
            }

            var pivotX = screenPosition.x < _camera.pixelWidth / 2f ? 0f : 1f;
            var pivotY = screenPosition.y < _camera.pixelHeight / 2f ? 0f : 1f;

            backgroundImage.rectTransform.pivot = new Vector2(pivotX, pivotY);
            backgroundImage.rectTransform.SetPositionAndRotation(Input.mousePosition, Quaternion.identity);
            backgroundImage.color = toolTipToDisplay.GetColor();
            backgroundImage.gameObject.SetActive(true);
        }

        private static RaycastResult Raycast3D(Ray ray)
        {
            return Physics.Raycast(ray, out var hit)
                ? new RaycastResult
                {
                    gameObject = hit.collider.gameObject,
                    screenPosition = Input.mousePosition
                }
                : new RaycastResult();
        }

        private RaycastResult Raycast2D(Ray ray)
        {
            var positionOnZ0 = ray.origin - _camera.transform.position.z * ray.direction / ray.direction.z;
            var hit = Physics2D.Linecast(positionOnZ0, positionOnZ0);

            return hit.collider != null
                ? new RaycastResult
                {
                    gameObject = hit.collider.gameObject,
                    screenPosition = Input.mousePosition
                }
                : new RaycastResult();
        }
    }
}