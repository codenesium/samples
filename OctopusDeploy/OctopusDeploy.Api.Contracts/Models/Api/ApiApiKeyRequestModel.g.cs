using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

namespace OctopusDeployNS.Api.Contracts
{
        public partial class ApiApiKeyRequestModel: AbstractApiRequestModel
        {
                public ApiApiKeyRequestModel() : base()
                {
                }

                public void SetProperties(
                        string apiKeyHashed,
                        DateTime created,
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

                private DateTime created;

                [Required]
                public DateTime Created
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
    <Hash>0907645d70e2fe84da83444b4009fc5e</Hash>
</Codenesium>*/