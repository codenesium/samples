using Codenesium.DataConversionExtensions;
using System;

namespace NebulaNS.Api.Services
{
        public abstract class AbstractBOOrganization : AbstractBusinessObject
        {
                public AbstractBOOrganization()
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
    <Hash>25bac616461fd8e30ee1e9de80ba03cd</Hash>
</Codenesium>*/