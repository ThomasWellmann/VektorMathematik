using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VektorMathematik
{
    internal struct Vector
    {
        public float x;
        public float y;
        public float z;
        private float xResult;
        private float yResult;
        private float zResult;

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

        public Vector Add(Vector _vAdd)
        {
            xResult = x + _vAdd.x;
            yResult = y + _vAdd.y;
            zResult = z + _vAdd.z;
            Vector vResult = new Vector(xResult, yResult, zResult);
            return vResult;
        }

        public Vector Subtract(Vector _vSubtract)
        {
            xResult = x - _vSubtract.x;
            yResult = y - _vSubtract.y;
            zResult = z - _vSubtract.z;
            Vector vResult = new Vector(xResult, yResult, zResult);
            return vResult;
        }

        public Vector Multiply(float _skalar)
        {
            xResult = x * _skalar;
            yResult = y * _skalar;
            zResult = z * _skalar;
            Vector vResult = new Vector(xResult, yResult, zResult);
            return vResult;
        }

        public float ScalarProduct(Vector _vScalar)
        {
            return x * _vScalar.x + y * _vScalar.y + z * _vScalar.z;
        }

        public Vector CrossProduct(Vector _vCross)
        {

            xResult = y * _vCross.z - z * _vCross.y;
            yResult = z * _vCross.x - x * _vCross.z;
            zResult = x * _vCross.y - y * _vCross.z;
            Vector vResult = new Vector(xResult, yResult, zResult);
            return vResult;
        }

        public float GetDistance(Vector _vDistance)
        {
            Vector difference = Subtract(_vDistance);
            return difference.GetLength();
        }

        public static float S_GetDistance(Vector _v0, Vector _v1)
        {
            Vector difference = _v0.Subtract(_v1);
            return difference.GetLength();
        }

        public float GetLength()
        {
            return (float)Math.Sqrt(x * x + y * y + z * z);
        }

        public float GetSquareLength ()
        {
            return ScalarProduct(this);
        }
    }
}
