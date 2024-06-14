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

        public Vector Add(Vector _vAdd = v2)
        {
            float xResult = x + _vAdd.x;
            float yResult = y + _vAdd.y;
            float zResult = z + _vAdd.z;
            Vector vResult = new Vector(xResult, yResult, zResult);
            return vResult;
        }

        public Vector Subtract(Vector _vSub = v2)
        {
            float xResult = x + _vSub.x;
            float yResult = y + _vSub.y;
            float zResult = z + _vSub.z;
            Vector vResult = new Vector(xResult, yResult, zResult);
            return vResult;
        }
    }
}
