using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace FileServiceNS.Api.Contracts
{
        public partial class ApiBucketRequestModel : AbstractApiRequestModel
        {
                public ApiBucketRequestModel()
                        : base()
                {
                }

                public void SetProperties(
                        Guid externalId,
                        string name)
                {
                        this.ExternalId = externalId;
                        this.Name = name;
                }

                private Guid externalId;

                [Required]
                public Guid ExternalId
                {
                        get
                        {
                                return this.externalId;
                        }

                        set
                        {
                                this.externalId = value;
                        }
                }

                private string name;

                [Required]
                public string Name
                {
                        get
                        {
                                return this.name;
                        }

                        set
                        {
                                this.name = value;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>dd8a9bef8e5c54ebae4a071211a2cf03</Hash>
</Codenesium>*/