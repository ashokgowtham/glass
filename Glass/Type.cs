using System.Collections.Generic;
using System.Linq;

namespace Glass
{
    public class Type
    {
        private readonly System.Type type;

        public Type(System.Type type)
        {
            this.type = type;
        }

        public IEnumerable<Member> Members
        {
            get
            {
                return type.GetMembers().Select(info => new Member(info));
            }
        }

        public string Name
        {
            get
            {
                return type.Name;
            }
        }

        public bool IsStatic
        {
            get
            {
                return type.IsAbstract && type.IsSealed;
            }
        }

        public override string ToString()
        {
            return type.FullName;
        }

        protected bool Equals(Type other)
        {
            return type == other.type;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            if (obj.GetType() != GetType())
                return false;
            return Equals((Type) obj);
        }

        public override int GetHashCode()
        {
            return (type != null ? type.GetHashCode() : 0);
        }

        public static bool operator ==(Type left, Type right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Type left, Type right)
        {
            return !Equals(left, right);
        }
    }

    public enum Kind
    {
        Class,
        Interface,
        Struct,
        Enum
    }
}
