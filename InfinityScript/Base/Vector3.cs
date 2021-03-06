﻿namespace InfinityScript
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct Vector3
    {
        public static readonly Vector3 Zero = new Vector3(0.0f, 0.0f, 0.0f);

        public float X;
        public float Y;
        public float Z;

        private static Random _random = new Random();

        public Vector3(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public static Vector3 operator -(Vector3 left, Vector3 right) =>
            new Vector3(left.X - right.X, left.Y - right.Y, left.Z - right.Z);

        public static Vector3 operator -(Vector3 left, float right) =>
            new Vector3(left.X - right, left.Y - right, left.Z - right);

        public static Vector3 operator +(Vector3 left, Vector3 right) =>
            new Vector3(left.X + right.X, left.Y + right.Y, left.Z + right.Z);

        public static Vector3 operator +(Vector3 left, float right) =>
            new Vector3(left.X + right, left.Y + right, left.Z + right);

        public static Vector3 operator *(Vector3 left, Vector3 right) =>
            new Vector3(left.X * right.X, left.Y * right.Y, left.Z * right.Z);

        public static Vector3 operator *(Vector3 left, float right) =>
            new Vector3(left.X * right, left.Y * right, left.Z * right);

        public static Vector3 operator /(Vector3 left, Vector3 right) =>
            new Vector3(left.X / right.X, left.Y / right.Y, left.Z / right.Z);

        public static Vector3 operator /(Vector3 left, float right) =>
            new Vector3(left.X / right, left.Y / right, left.Z / right);

        public static bool operator ==(Vector3 left, Vector3 right) =>
            left.Equals(right);

        public static bool operator !=(Vector3 left, Vector3 right) =>
            !left.Equals(right);

        public static Vector3 RandomXY()
        {
            Vector3 vector3 = new Vector3((float)(_random.NextDouble() - 0.5), (float)(_random.NextDouble() - 0.5), 0.0f);
            vector3.Normalize();
            return vector3;
        }

        public float DistanceTo2D(Vector3 point)
        {
            Vector3 pointA = this;
            Vector3 pointB = point;
            pointA.Z = 0;
            pointB.Z = 0;
            return pointA.DistanceTo(pointB);
        }

        public float DistanceTo(Vector3 other) =>
            (other - this).Length();

        public float Length() =>
            (float)Math.Sqrt((X * X) + (Y * Y) + (Z * Z));

        public Vector3 Around(float distance) =>
            this + (RandomXY() * distance);

        public void Normalize()
        {
            float a = Length();
            if (a <= 0.0)
            {
                return;
            }

            float b = 1f / a;

            X *= b;
            Y *= b;
            Z *= b;
        }

        public override bool Equals(object obj) =>
            obj is Vector3 vector && (X == vector.X) && (Y == vector.Y) && (Z == vector.Z);

        public override string ToString() => $"({X}, {Y}, {Z})";

        public override int GetHashCode() => (int)X ^ (int)Y ^ (int)Z;
    }
}
