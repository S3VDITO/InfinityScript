using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InfinityScript
{
    public class HudElem
    {
        internal string _shader = "";
        private static HudElem _uiParent;
        private HudElem _parent;
        private int _xOffset;
        private int _yOffset;
        private string _point;
        private string _relativePoint;

        public Entity Entity { get; set; }

        public static HudElem UIParent
        {
            get
            {
                if (_uiParent == null)
                    _uiParent = new HudElem();
                return _uiParent;
            }
        }

        private HudElem()
        {
            Entity = null;
            Children = new List<HudElem>();
        }

        internal HudElem(Entity entity)
        {
            Entity = entity;
            Children = new List<HudElem>();
        }

        public static HudElem GetHudElem(int entRef)
        {
            return new HudElem(new Entity(entRef));
        }

        public float X
        {
            get
            {
                switch (Entity)
                {
                    case null:
                        return 0.0f;
                    default:
                        return Entity.GetField(0) != null ? (float)Entity.GetField(0) : 0.0f;
                }
            }
            set
            {
                Entity.SetField(0, value);
            }
        }

        public float Y
        {
            get
            {
                switch (Entity)
                {
                    case null:
                        return 0.0f;
                    default:
                        return Entity.GetField(1) != null ? (float)Entity.GetField(1) : 0.0f;
                }
            }
            set
            {
                Entity.SetField(1, value);
            }
        }

        public float Z
        {
            get
            {
                switch (Entity)
                {
                    case null:
                        return 0.0f;
                    default:
                        return Entity.GetField(2) != null ? (float)Entity.GetField(2) : 0.0f;
                }
            }
            set
            {
                Entity.SetField(2, value);
            }
        }

        public float FontScale
        {
            get
            {
                switch (Entity)
                {
                    case null:
                        return 0.0f;
                    default:
                        return Entity.GetField(3) != null ? (float)Entity.GetField(3) : 0.0f;
                }
            }
            set
            {
                Entity.SetField(3, value);
            }
        }

        public Fonts Font
        {
            get
            {
                Fonts result;
                return Entity.GetField(4) == null || !Enum.TryParse((string)Entity.GetField(4), out result) ? Fonts.Default : result;
            }
            set
            {
                Entity.SetField(4, value.ToString().ToLowerInvariant());
            }
        }

        public XAlignments AlignX
        {
            get
            {
                if (Entity == null)
                    return XAlignments.Center;

                if (Entity.GetField(5) == null)
                    return XAlignments.Center;

                string lowerInvariant = ((string)Entity.GetField(5)).ToLowerInvariant();

                if (lowerInvariant == "left")
                    return XAlignments.Left;

                return lowerInvariant == "right" ? XAlignments.Right : XAlignments.Center;
            }
            set
            {
                Entity.SetField(5, value.ToString().ToLowerInvariant());
            }
        }

        public YAlignments AlignY
        {
            get
            {
                if (Entity == null)
                    return YAlignments.Middle;

                if (Entity.GetField(6) == null)
                    return YAlignments.Middle;

                string lowerInvariant = ((string)Entity.GetField(6)).ToLowerInvariant();

                if (lowerInvariant == "top")
                    return YAlignments.Top;

                return lowerInvariant == "bottom" ? YAlignments.Bottom : YAlignments.Middle;
            }
            set
            {
                Entity.SetField(6, value.ToString().ToLowerInvariant());
            }
        }

        public HorzAlignments HorzAlign
        {
            get
            {
                if (Entity == null)
                    return HorzAlignments.NoScale;

                if (Entity.GetField(7) == null)
                    return HorzAlignments.NoScale;

                switch (((string)Entity.GetField(7)).ToLowerInvariant())
                {
                    case "alignto640":
                        return HorzAlignments.AlignTo640;
                    case "center":
                        return HorzAlignments.Center;
                    case "center_adjustable":
                        return HorzAlignments.Center_Adjustable;
                    case "center_safearea":
                        return HorzAlignments.Center_SafeArea;
                    case "fullscreen":
                        return HorzAlignments.Fullscreen;
                    case "left":
                        return HorzAlignments.Left;
                    case "left_adjustable":
                        return HorzAlignments.Left_Adjustable;
                    case "right":
                        return HorzAlignments.Right;
                    case "right_adjustable":
                        return HorzAlignments.Right_Adjustable;
                    case "subleft":
                        return HorzAlignments.SubLeft;
                    default:
                        return HorzAlignments.NoScale;
                }
            }
            set
            {
                Entity.SetField(7, value.ToString().ToLowerInvariant());
            }
        }

        public VertAlignments VertAlign
        {
            get
            {
                if (Entity == null)
                    return VertAlignments.NoScale;

                if (Entity.GetField(8) == null)
                    return VertAlignments.NoScale;

                switch (((string)Entity.GetField(8)).ToLowerInvariant())
                {
                    case "alignto640":
                        return VertAlignments.AlignTo640;
                    case "bottom":
                        return VertAlignments.Bottom;
                    case "bottom_adjustable":
                        return VertAlignments.Bottom_Adjustable;
                    case "center_adjustable":
                        return VertAlignments.Center_Adjustable;
                    case "center_safearea":
                        return VertAlignments.Center_SafeArea;
                    case "fullscreen":
                        return VertAlignments.Fullscreen;
                    case "middle":
                        return VertAlignments.Middle;
                    case "subtop":
                        return VertAlignments.SubTop;
                    case "top":
                        return VertAlignments.Top;
                    case "top_adjustable":
                        return VertAlignments.Top_Adjustable;
                    default:
                        return VertAlignments.NoScale;
                }
            }
            set
            {
                Entity.SetField(8, value.ToString().ToLowerInvariant());
            }
        }

        public float Alpha
        {
            get
            {
                return Entity.GetField(10) == null ? 0.0f : (float)Entity.GetField(10);
            }
            set
            {
                Entity.SetField(10, value);
            }
        }

        public float GlowAlpha
        {
            get
            {
                return Entity.GetField(18) == null ? 0.0f : (float)Entity.GetField(18);
            }
            set
            {
                Entity.SetField(18, value);
            }
        }

        public int Sort
        {
            get
            {
                return Entity.GetField(12) == null ? 0 : (int)Entity.GetField(12);
            }
            set
            {
                Entity.SetField(12, value);
            }
        }

        public bool HideWhenInMenu
        {
            get
            {
                return Entity.GetField(16) != null && (int)Entity.GetField(16) > 0;
            }
            set
            {
                Entity.SetField(16, value);
            }
        }

        public bool LowResBackground
        {
            get
            {
                return Entity.GetField(14) != null && (int)Entity.GetField(14) > 0;
            }
            set
            {
                Entity.SetField(14, value);
            }
        }

        public bool HideWhenDead
        {
            get
            {
                return Entity.GetField(15) != null && (int)Entity.GetField(15) > 0;
            }
            set
            {
                Entity.SetField(15, value);
            }
        }

        public bool HideIn3rdPerson
        {
            get
            {
                return Entity.GetField(20) != null && (int)Entity.GetField(20) > 0;
            }
            set
            {
                Entity.SetField(20, value);
            }
        }

        public bool HideWhenInDemo
        {
            get
            {
                return Entity.GetField(21) != null && (int)Entity.GetField(21) > 0;
            }
            set
            {
                Entity.SetField(21, value);
            }
        }

        public bool Archived
        {
            get
            {
                return Entity.GetField(19) != null && (int)Entity.GetField(19) > 0;
            }
            set
            {
                Entity.SetField(19, value);
            }
        }

        public bool Foreground
        {
            get
            {
                return Entity.GetField(13) != null && (int)Entity.GetField(13) > 0;
            }
            set
            {
                Entity.SetField(13, value);
            }
        }

        public Vector3 Color
        {
            get
            {
                return Entity.GetField(9) == null ? Vector3.Zero : Entity.GetField(9).As<Vector3>();
            }
            set
            {
                Entity.SetField(9, value);
            }
        }

        public Vector3 GlowColor
        {
            get
            {
                return Entity.GetField(17) == null ? Vector3.Zero : Entity.GetField(17).As<Vector3>();
            }
            set
            {
                Entity.SetField(17, value);
            }
        }

        public string Label
        {
            get
            {
                return Entity.GetField(11) == null ? "" : (string)Entity.GetField(11);
            }
            set
            {
                Entity.SetField(11, value);
            }
        }

        public Parameter GetField(string name)
        {
            return Entity.GetField(name);
        }

        public Parameter GetField(int index)
        {
            return Entity.GetField(index);
        }

        public void SetField(string name, Parameter value)
        {
            Entity.SetField(name, value);
        }

        public static HudElem CreateFontString(Entity client, Fonts font, float fontScale)
        {
            HudElem hudElem = GSCFunctions.NewClientHudElem(client);
            hudElem.Font = font;
            hudElem.FontScale = fontScale;
            hudElem.X = 0.0f;
            hudElem.Y = 0.0f;
            hudElem.Height = (int)(12.0 * fontScale);
            hudElem.Parent = UIParent;
            return hudElem;
        }

        public static HudElem CreateServerFontString(HudElem.Fonts font, float fontScale)
        {
            HudElem hudElem = GSCFunctions.NewHudElem();
            hudElem.Font = font;
            hudElem.FontScale = fontScale;
            hudElem.X = 0.0f;
            hudElem.Y = 0.0f;
            hudElem.Height = (int)(12.0 * fontScale);
            hudElem.Parent = UIParent;
            return hudElem;
        }

        public static HudElem CreateIcon(Entity client, string shader, int width, int height)
        {
            HudElem hud = GSCFunctions.NewClientHudElem(client);
            hud.X = 0.0f;
            hud.Y = 0.0f;
            hud.Width = width;
            hud.Height = height;
            hud.Parent = UIParent;
            if (shader != null)
            {
                hud.SetShader(shader, width, height);
                hud._shader = shader;
            }
            return hud;
        }

        public List<HudElem> Children { get; set; }

        public HudElem Parent
        {
            get
            {
                return _parent;
            }
            set
            {
                if (_parent != null)
                    _parent.Children.Remove(this);
                _parent = value;
                _parent.Children.Add(this);
            }
        }

        public void SetPoint(string point)
        {
            SetPoint(point, point, 0, 0, 0);
        }

        public void SetPoint(string point, string relativePoint)
        {
            SetPoint(point, relativePoint, 0, 0, 0);
        }

        public void SetPoint(string point, string relativePoint, int xOffset)
        {
            SetPoint(point, relativePoint, xOffset, 0, 0);
        }

        public void SetPoint(string point, string relativePoint, int xOffset, int yOffset)
        {
            SetPoint(point, relativePoint, xOffset, yOffset, 0);
        }

        public void SetPoint(string point, string relativePoint, int xOffset, int yOffset, float moveTime)
        {
            var element = Parent;

            point = point.ToLowerInvariant();
            relativePoint = relativePoint.ToLowerInvariant();

            if (moveTime > 0)
                this.MoveOverTime(moveTime);

            _xOffset = xOffset;
            _yOffset = yOffset;
            _point = point;

            AlignX = XAlignments.Center;
            AlignY = YAlignments.Middle;

            if (point.Contains("top"))
                AlignY = YAlignments.Top;
            else if (point.Contains("bottom"))
                AlignY = YAlignments.Bottom;
            if (point.Contains("left"))
                AlignX = XAlignments.Left;
            else if (point.Contains("right"))
                AlignX = XAlignments.Right;

            HorzAlignments horzAlignments = HorzAlignments.Center_Adjustable;
            VertAlignments vertAlignments = VertAlignments.Middle;

            if (relativePoint.Contains("top"))
                vertAlignments = VertAlignments.Top_Adjustable;
            else if (relativePoint.Contains("bottom"))
                vertAlignments = VertAlignments.Bottom_Adjustable;
            if (relativePoint.Contains("left"))
                horzAlignments = HorzAlignments.Left_Adjustable;
            else if (relativePoint.Contains("right"))
                horzAlignments = HorzAlignments.Right_Adjustable;

            if (Parent.Entity == null)
            {
                HorzAlign = horzAlignments;
                VertAlign = vertAlignments;
            }
            else
            {
                HorzAlign = Parent.HorzAlign;
                VertAlign = Parent.VertAlign;
            }

            int xFactor;
            int yFactor;
            int offsetX;
            int offsetY;

            if (horzAlignments.ToString().Split('_')[0] == Parent.AlignX.ToString())
            {
                offsetX = 0;
                xFactor = 0;
            }
            else if (horzAlignments == HorzAlignments.Center || Parent.AlignX == XAlignments.Center)
            {
                offsetX = (element.Width == 0) ? 0 : (element.Width / 2);
                xFactor = horzAlignments == HorzAlignments.Left_Adjustable || Parent.AlignX == XAlignments.Right ? -1 : 1;
            }
            else
            {
                offsetX = element.Width;
                xFactor = horzAlignments != HorzAlignments.Left_Adjustable ? 1 : -1;
            }

            X = element.X + (offsetX * xFactor);

            if (vertAlignments.ToString().Split('_')[0] == Parent.AlignY.ToString())
            {
                offsetY = 0;
                yFactor = 0;
            }
            else if (vertAlignments == VertAlignments.Middle || Parent.AlignY == YAlignments.Middle)
            {
                offsetY = (element.Height == 0) ? 0 : (element.Height / 2);
                yFactor = vertAlignments == VertAlignments.Top_Adjustable || Parent.AlignY == YAlignments.Bottom ? -1 : 1;
            }
            else
            {
                offsetY = element.Height;
                yFactor = vertAlignments != VertAlignments.Top_Adjustable ? 1 : -1;
            }

            Y = element.Y + (offsetY * yFactor);

            X += _xOffset;
            Y += _yOffset;

            // setpointbar stuff

            UpdateChildren();
        }

        private void UpdateChildren()
        {
            foreach (HudElem child in Children)
                child.SetPoint(child._point, child._relativePoint, child._xOffset, child._yOffset);
        }

        public int Width { get; set; }

        public int Height { get; set; }

        public string Shader
        {
            get
            {
                return _shader;
            }
            set
            {
                this.SetShader(value, 64, 64);
                _shader = value;
            }
        }

        public enum HorzAlignments
        {
            SubLeft,
            Left,
            Center,
            Right,
            Fullscreen,
            NoScale,
            AlignTo640,
            Center_SafeArea,
            Center_Adjustable,
            Left_Adjustable,
            Right_Adjustable,
        }

        public enum VertAlignments
        {
            SubTop,
            Top,
            Middle,
            Bottom,
            Fullscreen,
            NoScale,
            AlignTo640,
            Center_SafeArea,
            Center_Adjustable,
            Top_Adjustable,
            Bottom_Adjustable,
        }

        public enum XAlignments
        {
            Left,
            Center,
            Right,
        }

        public enum YAlignments
        {
            Top,
            Middle,
            Bottom,
        }

        public enum Fonts
        {
            Big,
            Bold,
            ExtraBig,
            HudBig,
            HudSmall,
            Normal,
            Objective,
            Small,
            Default,
        }
    }
}
