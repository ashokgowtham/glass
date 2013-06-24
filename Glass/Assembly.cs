using System.Collections.Generic;
using System.Linq;

namespace Glass
{
    public class Assembly
    {
        private readonly System.Reflection.Assembly assembly;

        public Assembly(System.Reflection.Assembly assembly)
        {
            this.assembly = assembly;
        }

        public IEnumerable<Type> Types
        {
            get
            {
                return assembly.GetTypes().Select(type => new Type(type));
            }
        }

        public override string ToString()
        {
            return assembly.FullName;
        }

        protected bool Equals(Assembly other)
        {
            return Equals(assembly, other.assembly);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            if (obj.GetType() != this.GetType())
                return false;
            return Equals((Assembly) obj);
        }

        public override int GetHashCode()
        {
            return (assembly != null ? assembly.GetHashCode() : 0);
        }

        public static bool operator ==(Assembly left, Assembly right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Assembly left, Assembly right)
        {
            return !Equals(left, right);
        }
    }
}
