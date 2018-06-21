using Codenesium.DataConversionExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
        public partial class ApiCommunityActionTemplateRequestModel : AbstractApiRequestModel
        {
                public ApiCommunityActionTemplateRequestModel()
                        : base()
                {
                }

                public void SetProperties(
                        Guid externalId,
                        string jSON,
                        string name)
                {
                        this.ExternalId = externalId;
                        this.JSON = jSON;
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

                private string jSON;

                [Required]
                public string JSON
                {
                        get
                        {
                                return this.jSON;
                        }

                        set
                        {
                                this.jSON = value;
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
    <Hash>2ba91ff62b811ff88f15c39b7ef63a25</Hash>
</Codenesium>*/