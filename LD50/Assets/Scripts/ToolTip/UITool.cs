using UnityEngine;

namespace LD50.ToolTip
{
    public class UITool : ToolTipInfo {

        public Color textColor;
        public Color backgroundColor;
        public bool show;
        [TextArea]
        public string text;

        public override Color GetColor() {
            return backgroundColor;
        }

        public override string GetToolTipText() {
            return string.Format(text, ColorUtility.ToHtmlStringRGBA(textColor));
        }

        public override bool ShowToolTip() {
            return show;
        }
    }
}