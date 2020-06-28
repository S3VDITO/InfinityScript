﻿using System;

namespace InfinityScript
{
    public struct Vector3
    {
        /// <summary>
        /// Default coordinate (0, 0, 0)
        /// </summary>
        public static Vector3 Zero = new Vector3(0.0f, 0.0f, 0.0f);

        private static Random random = new Random();

        public float X;
        public float Y;
        public float Z;

        public Vector3(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        /// <summary>
        /// Get distance without Z coordinate
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public float DistanceTo2D(Vector3 point)
        {
            Vector3 pointA = this;
            Vector3 pointB = point;
            pointA.Z = 0;
            pointB.Z = 0;
            return pointA.DistanceTo(pointB);
        }

        /// <summary>
        /// Get distance from A to B
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public float DistanceTo(Vector3 other) => 
            (other - this).Length();

        public float Length() => 
            (float)Math.Sqrt(X * X + Y * Y + Z * Z);

        public Vector3 Around(float distance) => 
            this + RandomXY() * distance;

        public static Vector3 RandomXY()
        {
            Vector3 vector3 = new Vector3((float)(random.NextDouble() - 0.5), (float)(random.NextDouble() - 0.5), 0.0f);
            vector3.Normalize();
            return vector3;
        }

        public void Normalize()
        {
            float a = Length();
            if (a <= 0.0)
                return;

            float b = 1f / a;

            X *= b;
            Y *= b;
            Z *= b;
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

        /// <summary>
        /// Convert Vector3 to String value
        /// </summary>
        /// <returns>Vectro3 in string value</returns>
        public override string ToString() =>
            $"({X}, {Y}, {Z})";
    }
}