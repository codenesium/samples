using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace FileServiceNS.Api.Services
{
        public abstract class AbstractBOBucket: AbstractBusinessObject
        {
                public AbstractBOBucket() : base()
                {
                }

                public virtual void SetProperties(int id,
                                                  Guid externalId,
                                                  string name)
                {
                        this.ExternalId = externalId;
                        this.Id = id;
                        this.Name = name;
                }

                public Guid ExternalId { get; private set; }

                public int Id { get; private set; }

                public string Name { get; private set; }
        }
}

/*<Codenesium>
    <Hash>7ce675dce4e26a16d9557fca63e16cae</Hash>
</Codenesium>*/