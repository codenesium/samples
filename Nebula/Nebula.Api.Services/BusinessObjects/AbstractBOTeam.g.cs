using Codenesium.DataConversionExtensions;
using System;

namespace NebulaNS.Api.Services
{
        public abstract class AbstractBOTeam : AbstractBusinessObject
        {
                public AbstractBOTeam()
                        : base()
                {
                }

                public virtual void SetProperties(int id,
                                                  string name,
                                                  int organizationId)
                {
                        this.Id = id;
                        this.Name = name;
                        this.OrganizationId = organizationId;
                }

                public int Id { get; private set; }

                public string Name { get; private set; }

                public int OrganizationId { get; private set; }
        }
}

/*<Codenesium>
    <Hash>e709172743a8f0ca0f31676e659a71b9</Hash>
</Codenesium>*/