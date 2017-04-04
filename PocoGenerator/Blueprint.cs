using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PocoGenerator
{
    public class Blueprint<T> : IBlueprint
    {
        Dictionary<string,string> fixedValues = new Dictionary<string, string>();
        Dictionary<string,object[]> possible = new Dictionary<string, object[]>();
        private IRandome _randome;

        public Blueprint(IRandome randome)
        {
            _randome = randome;
        }

        public void Apply<T1>(T1 o) where T1 : class, new()
        {
            foreach (var item in fixedValues)
            {
                var prop = o.GetType().GetRuntimeProperty(item.Key);
                prop.SetMethod.Invoke(o, new object[] { item.Value });
            }

            foreach (var item in possible)
            {
                var prop = o.GetType().GetRuntimeProperty(item.Key);
                var index = _randome.get(0, item.Value.Length);
                prop.SetMethod.Invoke(o, new object[] { item.Value[index] });
            }
        }

        public void Fixed(string name, string value)
        {
            fixedValues[name] = value;
        }

        public void Possible(string name, IEnumerable<object> v)
        {
            possible[name] = v.ToArray();
        }
    }
}
