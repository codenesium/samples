using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

namespace OctopusDeployNS.Api.Contracts
{
        public partial class ApiCommunityActionTemplateRequestModel: AbstractApiRequestModel
        {
                public ApiCommunityActionTemplateRequestModel() : base()
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
    <Hash>946067baf903d24b315ec8118e3e30fe</Hash>
</Codenesium>*/