using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace FileServiceNS.Api.Services
{
        public partial class BOBucket: AbstractBusinessObject
        {
                public BOBucket() : base()
                {
                }

                public void SetProperties(int id,
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
    <Hash>e84c383df530b9a0fb9017b25e021b48</Hash>
</Codenesium>*/