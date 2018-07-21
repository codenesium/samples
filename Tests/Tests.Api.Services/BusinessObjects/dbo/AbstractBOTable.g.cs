using Codenesium.DataConversionExtensions;
using System;

namespace TestsNS.Api.Services
{
        public abstract class AbstractBOTable : AbstractBusinessObject
        {
                public AbstractBOTable()
                        : base()
                {
                }

                public virtual void SetProperties(int id,
                                                  string name)
                {
                        this.Id = id;
                        this.Name = name;
                }

                public int Id { get; private set; }

                public string Name { get; private set; }
        }
}

/*<Codenesium>
    <Hash>43d7f2e21fae3f4fad2f31e1022ce891</Hash>
</Codenesium>*/