using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VektorMathematik
{
    internal class Vector
    {
        public float x;
        public float y;
        public float z;

        public Vector(float _x = 0, float _y = 0, float _z = 0)
        {
            x = _x; 
            y = _y; 
            z = _z;
        }

        public override string ToString() 
        {
            return $"[{x}, {y}, {z}]";
        }

        public Vector Add(Vector _vAdd)
        {
            float xResult = x + _vAdd.x;
            float yResult = y + _vAdd.y;
            float zResult = z + _vAdd.z;
            Vector vResult = new Vector(xResult, yResult, zResult);
            return vResult;
        }

        public Vector Subtract(Vector _vSubtract)
        {
            float xResult = x - _vSubtract.x;
            float yResult = y - _vSubtract.y;
            float zResult = z - _vSubtract.z;
            Vector vResult = new Vector(xResult, yResult, zResult);
            return vResult;
        }

        public Vector Multiply(float _skalar)
        {
            float xResult = x * _skalar;
            float yResult = y * _skalar;
            float zResult = z * _skalar;
            Vector vResult = new Vector(xResult, yResult, zResult);
            return vResult;
        }

        //public float GetLength()
        //{
            
        //}
    }
}
