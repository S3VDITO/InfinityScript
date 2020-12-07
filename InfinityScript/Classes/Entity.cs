using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;

namespace InfinityScript
{
    public class Entity : Notifiable
    {
        public static Entity Level = new Entity(2046);
        private Dictionary<string, Parameter> _privateFields = new Dictionary<string, Parameter>();

        internal Entity(int entRef)
        {
            EntRef = entRef;
        }

        public int EntRef { get; }

        /// <summary>
        /// Checks status player (false = KIA, true = alive)
        /// </summary>
        public bool IsAlive => 
            GSCFunctions.IsAlive(this);

        /// <summary>
        /// Checks if an entity is a player
        /// </summary>
        public bool IsPlayer => 
            GSCFunctions.IsPlayer(this);

        /// <summary>
        /// Get weapon name on hands
        /// </summary>
        public string CurrentWeapon => 
            this.GetCurrentWeapon();

        /// <summary>
        /// Get player GUID
        /// </summary>
        public long GUID => 
            long.Parse(this.GetGUID(), NumberStyles.HexNumber);

        public string Code_Classname
        {
            get => (string)GetField(0);
            set => SetField(0, value);
        }

        public string Classname
        {
            get => (string)GetField(1);
            set => SetField(1, value);
        }

        public Vector3 Origin
        {
            get => GetField(2).As<Vector3>();
            set => SetField(2, value);
        }

        public string Model
        {
            get => (string)GetField(3);
            set
            {
                this.SetModel(value);
                SetField(3, value);
            }
        }

        public int SpawnFlags
        {
            get => (int)GetField(4);
            set => SetField(4, value);
        }

        public string Target
        {
            get => (string)GetField(5);
            set => SetField(5, value);
        }

        public string TargetName
        {
            get => (string)GetField(6);
            set => SetField(6, value);
        }

        public int Count
        {
            get => (int)GetField(7);
            set => SetField(7, value);
        }

        public int Health
        {
            get => (int)GetField(8);
            set => SetField(8, value);
        }

        public int dmg
        {
            get => (int)GetField(9);
            set => SetField(9, value);
        }

        public Vector3 Angles
        {
            get => GetField(10).As<Vector3>();
            set => SetField(10, value);
        }

        public int BirthTime =>
            (int)GetField(11);

        public string Script_LinkName
        {
            get => (string)GetField(12);
            set => SetField(12, value);
        }

        public Vector3 SlideVelocity
        {
            get => GetField(13).As<Vector3>();
            set => SetField(13, value);
        }

        public unsafe string Name
        {
            get => (string)GetField(24576);
            set
            {
                if (this == null || !IsPlayer || value.Length > 15)
                    return;

                for (int i = 0; i < value.Length; i++)
                {
                    *(byte*)((0x38A4 * EntRef + 0x1AC5490) + i) = (byte)value[i];
                    *(byte*)((0x38A4 * EntRef + 0x1AC5508) + i) = (byte)value[i];
                }
            }
        }
            

        public string SessionTeam
        {
            get => (string)GetField(24577);
            set => SetField(24577, value);
        }

        public string SessionState
        {
            get => (string)GetField(24578);
            set => SetField(24578, value);
        }

        public int MaxHealth
        {
            get => (int)GetField(24579);
            set => SetField(24579, value);
        }

        public int Score
        {
            get => (int)GetField(24580);
            set => SetField(24580, value);
        }

        public int Deaths
        {
            get => (int)GetField(24581);
            set => SetField(24581, value);
        }

        public string StatusIcon
        {
            get => (string)GetField(24582);
            set => SetField(24582, value);
        }

        public string HeadIcon
        {
            get => (string)GetField(24583);
            set => SetField(24583, value);
        }

        public string HeadIconTeam
        {
            get => (string)GetField(24584);
            set => SetField(24584, value);
        }

        public int Kills
        {
            get => (int)GetField(24585);
            set => SetField(24585, value);
        }

        public int Assists
        {
            get => (int)GetField(24586);
            set => SetField(24586, value);
        }

        public bool HasRadar
        {
            get => (int)GetField(24587) > 0;
            set => SetField(24587, (value ? 0 : 1));
        }

        public bool IsRadarBlocked
        {
            get => (int)GetField(24588) > 0;
            set => SetField(24588, value ? 0 : 1);
        }

        /// <summary>
        /// Checks if entity has current field
        /// </summary>
        /// <param name="name">Field name</param>
        /// <returns></returns>
        public bool HasField(string name)
        {
            name = name.ToLowerInvariant();
            return _privateFields.ContainsKey(name);
        }

        /// <summary>
        /// Remove current field
        /// </summary>
        /// <param name="name">Field name</param>
        public void ClearField(string name)
        {
            name = name.ToLowerInvariant();
            _privateFields.Remove(name);
        }

        public unsafe string ClanTag
        {
            get
            {
                if (this == null || !IsPlayer)
                    return null;

                int address = 0x38A4 * EntRef + 0x01AC5564;

                StringBuilder result = new StringBuilder(8);

                for (; address < address + 8 && *(byte*)address != 0; address++)
                    result.Append(Encoding.ASCII.GetString(new byte[] { *(byte*)address }));

                return result.ToString();
            }
            set
            {
                if (this == null || !IsPlayer || value.Length > 7)
                    return;

                int address = 0x38A4 * EntRef + 0x01AC5564;

                for (int i = 0; i < value.Length; i++)
                    *(byte*)(address + i) = (byte)value[i];

                *(byte*)(address + value.Length) = 0;
            }
        }

        public unsafe string PlayerCardTitle
        {
            get
            {
                if (this == null || !IsPlayer)
                    return null;

                int address = 0x38A4 * EntRef + 0x01AC5548;

                StringBuilder result = new StringBuilder();

                for (; address < address + 8 && *(byte*)address != 0; address++)
                    result.Append(Encoding.ASCII.GetString(new byte[] { *(byte*)address }));

                return result.ToString();
            }
            set
            {
                if (this == null || !IsPlayer || value.Length > 25)
                    return;

                int address = 0x38A4 * EntRef + 0x01AC5548;

                for (int i = 0; i < value.Length; i++)
                    *(byte*)(address + i) = (byte)value[i];

                *(byte*)(address + value.Length) = 0;
            }
        }

        internal void ClearAllFields() => 
            _privateFields.Clear();

        /// <summary>
        /// Get value field from current name
        /// </summary>
        /// <param name="name">Field name</param>
        /// <returns>Value</returns>
        public Parameter GetField(string name)
        {
            name = name.ToLowerInvariant();
            return _privateFields[name];
        }

        internal Parameter GetField(int fieldID)
        {
            Parameter parameter = null;
            GameInterface.Script_GetField(EntRef, fieldID);
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
                    GameInterface.Script_GetVector(0, out var vector);
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

        /// <summary>
        /// Get value field from current name
        /// </summary>
        /// <param name="name">Field name</param>
        /// <returns>T - value</returns>
        public T GetField<T>(string name) => 
            GetField(name).As<T>();

        /// <summary>
        /// Get value field from current ID (Server can crushed!)
        /// </summary>
        /// <param name="fieldID">Field ID</param>
        /// <returns>T - value</returns>
        public T GetField<T>(int fieldID) => 
            GetField(fieldID).As<T>();

        /// <summary>
        /// Set value field
        /// </summary>
        /// <param name="name">Field name</param>
        /// <param name="value">Field parameter</param>
        public void SetField(string name, Parameter value)
        {
            name = name.ToLowerInvariant();
            _privateFields[name] = value;
        }

        /// <summary>
        /// Set value field uses FieldID (Server can crushed!)
        /// </summary>
        /// <param name="fieldID">Field ID</param>
        /// <param name="value">Field parameter</param>
        public void SetField(int fieldID, Parameter value)
        {
            value.PushValue();
            GameInterface.Script_SetField(EntRef, fieldID);
        }

        /// <summary>
        /// Sends notify to gameplay
        /// </summary>
        /// <param name="notify">Notify name</param>
        /// <param name="parameters">Sent parameters</param>
        public void Notify(string type, params Parameter[] parameters)
        {
            foreach (Parameter parameter in parameters.Reverse())
                parameter.PushValue();

            GameInterface.Script_NotifyNum(EntRef, type, parameters.Length);
        }

        /// <summary>
        /// Convert EntNum to Entity
        /// </summary>
        /// <param name="entRef">Entity number</param>
        /// <returns></returns>
        public static Entity GetEntity(int entRef) => new Entity(entRef);

        public int UserID => (int)(GUID & uint.MaxValue);

        public int Ping =>  GameInterface.GetPing(EntRef);

        public IPEndPoint IP
        {
            get
            {
                long clientAddress = GameInterface.GetClientAddress(EntRef);
                return new IPEndPoint(new IPAddress(clientAddress >> 32), (int)(clientAddress & uint.MaxValue));
            }
        }

        public string HWID =>  GameInterface.GetEntrefHWID(EntRef);

        public override string ToString() =>  $"[Entity:{EntRef >> 16}:{EntRef & ushort.MaxValue}]";

        public override int GetHashCode() => EntRef;

        public override bool Equals(object obj) => obj is Entity entity && entity.EntRef == EntRef;
    }
}
