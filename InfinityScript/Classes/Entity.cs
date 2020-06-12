using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;

namespace InfinityScript
{
    public class Entity : Notifiable
    {
        public static Entity Level = new Entity(2046);
        private static Dictionary<int, Entity> _entities = new Dictionary<int, Entity>();
        private Dictionary<string, Parameter> _privateFields = new Dictionary<string, Parameter>();
        private int _entRef;

        internal Entity(int entRef)
        {
            _entRef = entRef;
            OnNotify("spawned_player", thisEntity =>
            {
                if (thisEntity.SpawnedPlayer == null)
                    return;
                thisEntity.SpawnedPlayer();
            });
        }

        public int EntRef => _entRef;

        public void OnNotify(string type, Action<Entity> handler) =>
            OnNotifyInternal(type, handler);

        public void OnNotify(string type, Action<Entity, Parameter> handler) =>
            OnNotifyInternal(type, handler);
        public void OnNotify(string type, Action<Entity, Parameter, Parameter> handler) =>
            OnNotifyInternal(type, handler);

        public void OnNotify(string type, Action<Entity, Parameter, Parameter, Parameter> handler) =>
            OnNotifyInternal(type, handler);

        public void OnNotify(string type, Action<Entity, Parameter, Parameter, Parameter, Parameter> handler) =>
            OnNotifyInternal(type, handler);
        
        public void OnNotify(string type, Action<Entity, Parameter, Parameter, Parameter, Parameter, Parameter> handler) =>
            OnNotifyInternal(type, handler);

        public void OnNotify(string type, Action<Entity, Parameter, Parameter, Parameter, Parameter, Parameter, Parameter> handler) =>
            OnNotifyInternal(type, handler);

        public void OnNotify(string type, Action<Entity, Parameter, Parameter, Parameter, Parameter, Parameter, Parameter, Parameter> handler) =>
            OnNotifyInternal(type, handler);

        public void OnNotify(string type, Action<Entity, Parameter, Parameter, Parameter, Parameter, Parameter, Parameter, Parameter, Parameter> handler) =>
            OnNotifyInternal(type, handler);

        public void OnNotify(string type, Action<Entity, Parameter, Parameter, Parameter, Parameter, Parameter, Parameter, Parameter, Parameter, Parameter> handler) =>
            OnNotifyInternal(type, handler);

        public void OnNotify(string type, Action<Entity, Parameter, Parameter, Parameter, Parameter, Parameter, Parameter, Parameter, Parameter, Parameter, Parameter> handler) =>
            OnNotifyInternal(type, handler);

        public IEnumerator WaitTill(string type)
        {
            yield return Coroutine.WaitTill(this, type);
        }

        public IEnumerator WaitTill_any(params string[] type)
        {
            yield return Coroutine.WaitTill_any(this, type);
        }

        public IEnumerator WaitTill_notify_or_timeout(string type, int time, Action<string> returnString = null)
        {
            yield return Coroutine.WaitTill_notify_or_timeout(this, type, time, returnString);
        }

        public event Action SpawnedPlayer;

        public bool IsAlive => GSCFunctions.IsAlive(this);

        public bool IsPlayer => GSCFunctions.IsPlayer(this);

        public string CurrentWeapon => this.GetCurrentWeapon();

        public long GUID => long.Parse(this.GetGUID(), NumberStyles.HexNumber);

        public string Code_Classname
        {
            get
            {
                return (string)GetField(0);
            }
            set
            {
                SetField(0, value);
            }
        }

        public string Classname
        {
            get
            {
                return (string)GetField(1);
            }
            set
            {
                SetField(1, value);
            }
        }

        public Vector3 Origin
        {
            get
            {
                return GetField(2).As<Vector3>();
            }
            set
            {
                SetField(2, value);
            }
        }

        public string Model
        {
            get
            {
                return (string)GetField(3);
            }
            set
            {
                this.SetModel(value);
                SetField(3, value);
            }
        }

        public int SpawnFlags
        {
            get
            {
                return (int)GetField(4);
            }
            set
            {
                SetField(4, value);
            }
        }

        public string Target
        {
            get
            {
                return (string)GetField(5);
            }
            set
            {
                SetField(5, value);
            }
        }

        public string TargetName
        {
            get
            {
                return (string)GetField(6);
            }
            set
            {
                SetField(6, value);
            }
        }

        public int Count
        {
            get
            {
                return (int)GetField(7);
            }
            set
            {
                SetField(7, value);
            }
        }

        public int Health
        {
            get
            {
                return (int)GetField(8);
            }
            set
            {
                SetField(8, value);
            }
        }

        public int dmg
        {
            get
            {
                return (int)GetField(9);
            }
            set
            {
                SetField(9, value);
            }
        }

        public Vector3 Angles
        {
            get
            {
                return GetField(10).As<Vector3>();
            }
            set
            {
                SetField(10, value);
            }
        }

        public int BirthTime => (int)GetField(11);

        public string Script_LinkName
        {
            get
            {
                return (string)GetField(12);
            }
            set
            {
                SetField(12, value);
            }
        }

        public Vector3 SlideVelocity
        {
            get
            {
                return GetField(13).As<Vector3>();
            }
            set
            {
                SetField(13, value);
            }
        }

        public string Name => (string)GetField(24576);

        public string SessionTeam
        {
            get
            {
                return (string)GetField(24577);
            }
            set
            {
                SetField(24577, value);
            }
        }

        public string SessionState
        {
            get
            {
                return (string)GetField(24578);
            }
            set
            {
                SetField(24578, value);
            }
        }

        public int MaxHealth
        {
            get
            {
                return (int)GetField(24579);
            }
            set
            {
                SetField(24579, value);
            }
        }

        public int Score
        {
            get
            {
                return (int)GetField(24580);
            }
            set
            {
                SetField(24580, value);
            }
        }

        public int Deaths
        {
            get
            {
                return (int)GetField(24581);
            }
            set
            {
                SetField(24581, value);
            }
        }

        public string StatusIcon
        {
            get
            {
                return (string)GetField(24582);
            }
            set
            {
                SetField(24582, value);
            }
        }

        public string HeadIcon
        {
            get
            {
                return (string)GetField(24583);
            }
            set
            {
                SetField(24583, value);
            }
        }

        public string HeadIconTeam
        {
            get
            {
                return (string)GetField(24584);
            }
            set
            {
                SetField(24584, value);
            }
        }

        public int Kills
        {
            get
            {
                return (int)GetField(24585);
            }
            set
            {
                SetField(24585, value);
            }
        }

        public int Assists
        {
            get
            {
                return (int)GetField(24586);
            }
            set
            {
                SetField(24586, value);
            }
        }

        public bool HasRadar
        {
            get
            {
                return (int)GetField(24587) > 0;
            }
            set
            {
                SetField(24587, (value ? 0 : 1));
            }
        }

        public bool IsRadarBlocked
        {
            get
            {
                return (int)GetField(24588) > 0;
            }
            set
            {
                SetField(24588, value ? 0 : 1);
            }
        }

        public bool HasField(string name)
        {
            name = name.ToLowerInvariant();
            return _privateFields.ContainsKey(name);
        }

        public void ClearField(string name)
        {
            name = name.ToLowerInvariant();
            _privateFields.Remove(name);
        }

        internal void ClearAllFields() => _privateFields.Clear();

        public Parameter GetField(string name)
        {
            name = name.ToLowerInvariant();
            return _privateFields[name];
        }

        internal Parameter GetField(int fieldID)
        {
            Parameter parameter = null;
            GameInterface.Script_GetField(this._entRef, fieldID);
            switch (GameInterface.Script_GetType(0))
            {
                case VariableType.Entity:
                    parameter = new Entity(GameInterface.Script_GetEntRef(0));
                    break;
                case VariableType.String:
                case VariableType.IString:
                    parameter = GameInterface.Script_GetString(0);
                    break;
                case VariableType.Vector:
                    Vector3 vector;
                    GameInterface.Script_GetVector(0, out vector);
                    parameter = vector;
                    break;
                case VariableType.Float:
                    parameter = GameInterface.Script_GetFloat(0);
                    break;
                case VariableType.Integer:
                    parameter = GameInterface.Script_GetInt(0);
                    break;
            }
            GameInterface.Script_CleanReturnStack();
            return parameter;
        }

        public T GetField<T>(string name) => GetField(name).As<T>();

        public T GetField<T>(int fieldID) => GetField(fieldID).As<T>();

        public void SetField(string name, Parameter value)
        {
            name = name.ToLowerInvariant();
            _privateFields[name] = value;
        }

        public void SetField(int fieldID, Parameter value)
        {
            value.PushValue();
            GameInterface.Script_SetField(_entRef, fieldID);
        }

        public void Notify(string type, params Parameter[] parameters)
        {
            foreach (Parameter parameter in ((IEnumerable<Parameter>)parameters).Reverse())
                parameter.PushValue();

            GameInterface.Script_NotifyNum(_entRef, type, parameters.Length);
        }

        public static Entity GetEntity(int entRef)
        {
            if (_entities.ContainsKey(entRef))
                return _entities[entRef];
            Entity entity = new Entity(entRef);
            _entities[entRef] = entity;
            if (entRef < 18)
                entity.OnNotify("disconnect", ent => _entities.Remove(ent.EntRef));
            return entity;
        }

        internal static void RunAll(Action<Entity> cb)
        {
            foreach (Entity entity in _entities.Values.ToArray())
            {
                try
                {
                    cb(entity);
                }
                catch (Exception ex)
                {
                    Log.Write(LogLevel.Error, "Exception during RunAll call: {0}", (object)ex.ToString());
                }
            }
        }

        public int UserID => (int)(GUID & uint.MaxValue);

        public int Ping => GameInterface.GetPing(_entRef);

        public IPEndPoint IP
        {
            get
            {
                long clientAddress = GameInterface.GetClientAddress(_entRef);
                return new IPEndPoint(new IPAddress(clientAddress >> 32), (int)(clientAddress & uint.MaxValue));
            }
        }

        public string HWID => GameInterface.GetEntrefHWID(EntRef);

        public override string ToString() => $"[Entity:{_entRef >> 16}:{_entRef & ushort.MaxValue}]";

        public override int GetHashCode() => _entRef;

        public override bool Equals(object obj) => obj is Entity entity && entity.EntRef == EntRef;
    }
}
