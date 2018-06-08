using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

namespace FileServiceNS.Api.Contracts
{
        public partial class ApiBucketRequestModel: AbstractApiRequestModel
        {
                public ApiBucketRequestModel() : base()
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
    <Hash>036ed6bf2f40023e3871a6de6866bd03</Hash>
</Codenesium>*/