using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace VektorMathematik
{
    internal struct Vector
    {
        public float x;
        public float y;
        public float z;

        public Vector()
        {
            x = 0f;
            y = 0f;
            z = 0f;
        }
        public Vector(float _x, float _y, float _z)
        {
            x = _x; 
            y = _y; 
            z = _z;
        }

        public override string ToString() 
        {
            return $"[ {x} | {y} | {z} ]";
        }

        public static Vector operator +(Vector _v0, Vector _v1)
        {
            float xResult = _v0.x + _v1.x;
            float yResult = _v0.y + _v1.y;
            float zResult = _v0.z + _v1.z;
            Vector vResult = new Vector(xResult, yResult, zResult);
            return vResult;
        }

        public static Vector operator -(Vector _v0, Vector _v1)
        {
            float xResult = _v0.x - _v1.x;
            float yResult = _v0.y - _v1.y;
            float zResult = _v0.z - _v1.z;
            Vector vResult = new Vector(xResult, yResult, zResult);
            return vResult;
        }

        public static Vector operator *(Vector _v, float _skalar)
        {
            float xResult = _v.x * _skalar;
            float yResult = _v.y * _skalar;
            float zResult = _v.z * _skalar;
            Vector vResult = new Vector(xResult, yResult, zResult);
            return vResult;
        }

        public float ScalarProduct(Vector _vScalar)
        {
            return x * _vScalar.x + y * _vScalar.y + z * _vScalar.z;
        }

        public Vector CrossProduct(Vector _vCross)
        {
            float xResult = y * _vCross.z - z * _vCross.y;
            float yResult = z * _vCross.x - x * _vCross.z;
            float zResult = x * _vCross.y - y * _vCross.z;
            Vector vResult = new Vector(xResult, yResult, zResult);
            return vResult;
        }

        public float GetDistance(Vector _vDistance)
        {
            Vector difference = this - _vDistance;
            return difference.GetLength();
        }

        public static float GetDistance(Vector _v0, Vector _v1)
        {
            Vector difference = _v0 - _v1;
            return difference.GetLength();
        }

        public float GetLength()
        {
            return (float)Math.Sqrt(ScalarProduct(this));
        }

        public float GetSquareLength ()
        {
            return ScalarProduct(this);
        }
    }
}
