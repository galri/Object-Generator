using System;
using System.Collections;
using System.Collections.Generic;

namespace PocoGenerator
{
    /// <summary>
    /// meant to be set for a property on a class
    /// </summary>
    /// <typeparam name="T">Value type blueprint for, string, list, object etc</typeparam>
	public interface IBlueprint<GenereatedMemberType>
	{
        void ApplyBlueprint(object o);

        void SetFixedValue(string memberName , GenereatedMemberType value);

        void SetRandomeValue(string memberName, IList<GenereatedMemberType> values);
	}

    public interface IBlueprint
    {
        void Apply(object t);
        void Fixed(string name, object value);
        void Possible(string name,IEnumerable<object> v);
        void Between(string v, double p0, double p1);
    }
}
