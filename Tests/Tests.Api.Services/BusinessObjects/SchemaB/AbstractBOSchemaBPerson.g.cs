using Codenesium.DataConversionExtensions;
using System;

namespace TestsNS.Api.Services
{
        public abstract class AbstractBOSchemaBPerson : AbstractBusinessObject
        {
                public AbstractBOSchemaBPerson()
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
    <Hash>6ae7c5a273103e50ca35e7f7b323a727</Hash>
</Codenesium>*/