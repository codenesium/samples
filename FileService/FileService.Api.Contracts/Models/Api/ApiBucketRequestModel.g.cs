using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
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

                public virtual void SetProperties(
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
    <Hash>04642a7b540426812918230659d420fd</Hash>
</Codenesium>*/