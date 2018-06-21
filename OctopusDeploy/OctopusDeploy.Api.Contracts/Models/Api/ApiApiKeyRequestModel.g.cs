using Codenesium.DataConversionExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
        public partial class ApiApiKeyRequestModel : AbstractApiRequestModel
        {
                public ApiApiKeyRequestModel()
                        : base()
                {
                }

                public void SetProperties(
                        string apiKeyHashed,
                        DateTimeOffset created,
                        string jSON,
                        string userId)
                {
                        this.ApiKeyHashed = apiKeyHashed;
                        this.Created = created;
                        this.JSON = jSON;
                        this.UserId = userId;
                }

                private string apiKeyHashed;

                [Required]
                public string ApiKeyHashed
                {
                        get
                        {
                                return this.apiKeyHashed;
                        }

                        set
                        {
                                this.apiKeyHashed = value;
                        }
                }

                private DateTimeOffset created;

                [Required]
                public DateTimeOffset Created
                {
                        get
                        {
                                return this.created;
                        }

                        set
                        {
                                this.created = value;
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

                private string userId;

                [Required]
                public string UserId
                {
                        get
                        {
                                return this.userId;
                        }

                        set
                        {
                                this.userId = value;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>be966e17af6fef7cd571e07000aa0a0e</Hash>
</Codenesium>*/