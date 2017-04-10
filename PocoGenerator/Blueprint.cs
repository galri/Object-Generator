using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PocoGenerator
{
    public class Blueprint : IBlueprint
    {
        Dictionary<string,object> fixedValues = new Dictionary<string, object>();
        Dictionary<string,object[]> possible = new Dictionary<string, object[]>();
        Dictionary<string, MinMax> betweem = new Dictionary<string, MinMax>();
        private IRandome _randome;

        public Blueprint(IRandome randome)
        {
            _randome = randome;
        }

        public void Apply(object o)
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

            foreach (var item in betweem)
            {
                var prop = o.GetType().GetRuntimeProperty(item.Key);
                var value = _randome.get((int)item.Value.Min, (int)item.Value.Max);
                prop.SetMethod.Invoke(o, new object[] { value });
            }
        }

        public void Between(string v, double p0,double p1)
        {
            betweem.Add(v, new MinMax() { Min = p0, Max = p1 });
        }

        public void Fixed(string name, object value)
        {
            fixedValues[name] = value;
        }

        public void Possible(string name, IEnumerable<object> v)
        {
            possible[name] = v.ToArray();
        }

        private class MinMax
        {
            public double Min { get; set; }
            public double Max { get; set; }
        }
    }
}
