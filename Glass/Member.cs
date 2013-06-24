using System;
using System.Reflection;

namespace Glass
{
    public class Member
    {
        private readonly MemberInfo memberInfo;

        public Member(MemberInfo memberInfo)
        {
            this.memberInfo = memberInfo;
        }

        public string Name
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public MemberType MemberType
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override string ToString()
        {
            string typeName = memberInfo.DeclaringType != null ? memberInfo.DeclaringType.Name : "<no-Type>";
            return typeName + "." + memberInfo.Name + "(" + memberInfo.MemberType + ")";
        }
    }
}
