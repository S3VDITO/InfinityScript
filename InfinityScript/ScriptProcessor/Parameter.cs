using System;

namespace InfinityScript
{
    public class Parameter
    {
        internal object InternalValue { get; }

        public VariableType Type { get; }

        internal Parameter(VariableType type, object value)
        {
            Type = type;
            InternalValue = value;
        }

        public Parameter(string v)
        {
            Type = VariableType.String;
            InternalValue = v;
        }

        public Parameter(int v)
        {
            Type = VariableType.Integer;
            InternalValue = v;
        }

        public Parameter(float v)
        {
            Type = VariableType.Float;
            InternalValue = v;
        }

        public Parameter(Vector3 v)
        {
            Type = VariableType.Vector;
            InternalValue = v;
        }

        public Parameter(Entity v)
        {
            Type = VariableType.Entity;
            InternalValue = v;
        }

        public Parameter(HudElem v)
        {
            Type = VariableType.Entity;
            InternalValue = v;
        }

        public Parameter(object v) => InternalValue = v;

        internal void PushValue()
        {
            switch (Type)
            {
                case VariableType.Entity:
                    GameInterface.Script_PushEntRef(((Entity)InternalValue).EntRef);
                    break;
                case VariableType.String:
                case VariableType.IString:
                    GameInterface.Script_PushString(Convert.ToString(InternalValue));
                    break;
                case VariableType.Vector:
                    Vector3 vector3 = (Vector3)InternalValue;
                    GameInterface.Script_PushVector(vector3.X, vector3.Y, vector3.Z);
                    break;
                case VariableType.Float:
                    GameInterface.Script_PushFloat(Convert.ToSingle(InternalValue));
                    break;
                case VariableType.Integer:
                    GameInterface.Script_PushInt(Convert.ToInt32(InternalValue));
                    break;
            }
        }

        public static explicit operator int(Parameter p) => Convert.ToInt32(p.InternalValue);

        public static explicit operator bool(Parameter p) => Convert.ToInt32(p.InternalValue) > 0;

        public static explicit operator float(Parameter p) => Convert.ToSingle(p.InternalValue);

        public static explicit operator string(Parameter p) => Convert.ToString(p.InternalValue);

        public static explicit operator Entity(Parameter p) => (Entity)p.InternalValue;

        public static explicit operator HudElem(Parameter p) => (HudElem)p.InternalValue;

        public static implicit operator Parameter(string v) => new Parameter(v);

        public static implicit operator Parameter(int v) => new Parameter(v);

        public static implicit operator Parameter(float v) => new Parameter(v);

        public static implicit operator Parameter(Vector3 v) => new Parameter(v);

        public static implicit operator Parameter(Entity v) => new Parameter(v);

        public static implicit operator Parameter(HudElem v) => new Parameter(v);

        public static implicit operator Parameter(bool v) => new Parameter(v ? 1 : 0);

        public T As<T>() => (T)Convert.ChangeType(InternalValue, typeof(T));

        public bool IsNull =>  InternalValue == null;

        public override string ToString() => InternalValue.ToString();
    }
}
