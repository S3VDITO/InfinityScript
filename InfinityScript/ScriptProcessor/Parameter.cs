using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace InfinityScript
{
    public class Parameter
    {
        private VariableType _type;
        private object _value;

        internal object InternalValue
        {
            get
            {
                return this._value;
            }
        }

        public VariableType Type
        {
            get
            {
                return this._type;
            }
        }

        internal Parameter(VariableType type, object value)
        {
            this._type = type;
            this._value = value;
        }

        public static explicit operator int(Parameter p)
        {
            return Convert.ToInt32(p._value);
        }

        public static explicit operator bool(Parameter p)
        {
            return (uint)Convert.ToInt32(p._value) > 0U;
        }

        public static explicit operator float(Parameter p)
        {
            return Convert.ToSingle(p._value);
        }

        public static explicit operator string(Parameter p)
        {
            return Convert.ToString(p._value);
        }

        public static explicit operator Entity(Parameter p)
        {
            return (Entity)p._value;
        }

        public static explicit operator HudElem(Parameter p)
        {
            return (HudElem)p._value;
        }

        public T As<T>()
        {
            return (T)Convert.ChangeType(this._value, typeof(T));
        }

        public Parameter(string v)
        {
            this._type = VariableType.String;
            this._value = (object)v;
        }

        public static implicit operator Parameter(string v)
        {
            return new Parameter(v);
        }

        public Parameter(int v)
        {
            this._type = VariableType.Integer;
            this._value = (object)v;
        }

        public static implicit operator Parameter(int v)
        {
            return new Parameter(v);
        }

        public Parameter(float v)
        {
            this._type = VariableType.Float;
            this._value = (object)v;
        }

        public static implicit operator Parameter(float v)
        {
            return new Parameter(v);
        }

        public Parameter(Vector3 v)
        {
            this._type = VariableType.Vector;
            this._value = (object)v;
        }

        public static implicit operator Parameter(Vector3 v)
        {
            return new Parameter(v);
        }

        public Parameter(Entity v)
        {
            this._type = VariableType.Entity;
            this._value = (object)v;
        }

        public static implicit operator Parameter(Entity v)
        {
            return new Parameter(v);
        }

        public Parameter(HudElem v)
        {
            this._type = VariableType.Entity;
            this._value = (object)v;
        }

        public static implicit operator Parameter(HudElem v)
        {
            return new Parameter(v);
        }

        public static implicit operator Parameter(bool v)
        {
            return new Parameter(v ? 1 : 0);
        }

        public Parameter(object v)
        {
            this._value = v;
        }

        internal void PushValue()
        {
            switch (this._type)
            {
                case VariableType.Entity:
                    GameInterface.Script_PushEntRef(((Entity)this._value).EntRef);
                    break;
                case VariableType.String:
                case VariableType.IString:
                    GameInterface.Script_PushString(Convert.ToString(this._value));
                    break;
                case VariableType.Vector:
                    Vector3 vector3 = (Vector3)this._value;
                    GameInterface.Script_PushVector(vector3.X, vector3.Y, vector3.Z);
                    break;
                case VariableType.Float:
                    GameInterface.Script_PushFloat(Convert.ToSingle(this._value));
                    break;
                case VariableType.Integer:
                    GameInterface.Script_PushInt(Convert.ToInt32(this._value));
                    break;
            }
        }

        public bool IsNull
        {
            get
            {
                return this._value == null;
            }
        }

        public override string ToString()
        {
            return this._value.ToString();
        }
    }
}
