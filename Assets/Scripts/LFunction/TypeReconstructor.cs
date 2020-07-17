﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class TypeReconstructor
{
    public Type GetImplementingClass(Type type, Type interfaceType)
    {
        Type baseType = null;

        // if type has a BaseType, then check base first
        if (type.BaseType != null)
            baseType = GetImplementingClass(type.BaseType, interfaceType);

        // if type
        if (baseType == null)
        {
            if (interfaceType.IsAssignableFrom(type))
                return type;
        }

        return baseType;
    }
}
    

