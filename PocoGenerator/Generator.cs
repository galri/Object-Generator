using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace PocoGenerator
{
	public class Generator<T>
        where T : class, new()
	{
        Dictionary<Type,IBlueprint> _bluePrints = new Dictionary<Type, IBlueprint>();
        private IRandome _randome;

        public Generator() : this(new RandomeGenerator())
        {

        }

        public Generator(IRandome randome)
        {
            _randome = randome;
        }

        public IEnumerable<T> Generate(int amount)
		{
            var result = new T[amount];

            if (!_bluePrints.ContainsKey(typeof(T)))
            {
                var nb = new Blueprint(_randome);
                _bluePrints.Add(typeof(T), nb);
            }

            var topB = _bluePrints[typeof(T)];
            for (int i = 0; i < amount; i++)
            {
                result[i] = new T();
                topB.Apply(result[i]);
            }
            
            return result;
		}

        public IBlueprint Bt<T1>()
        {
            if (!_bluePrints.ContainsKey(typeof(T1)))
            {
                var nb = new Blueprint(_randome);
                _bluePrints.Add(typeof(T1),nb);
            }

            return _bluePrints[typeof(T1)];
        }
    }
}
