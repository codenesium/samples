using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
        public partial class ApiUserRequestModel : AbstractApiRequestModel
        {
                public ApiUserRequestModel()
                        : base()
                {
                }

                public virtual void SetProperties(
                        string displayName,
                        string emailAddress,
                        string externalId,
                        string externalIdentifiers,
                        Guid identificationToken,
                        bool isActive,
                        bool isService,
                        string jSON,
                        string username)
                {
                        this.DisplayName = displayName;
                        this.EmailAddress = emailAddress;
                        this.ExternalId = externalId;
                        this.ExternalIdentifiers = externalIdentifiers;
                        this.IdentificationToken = identificationToken;
                        this.IsActive = isActive;
                        this.IsService = isService;
                        this.JSON = jSON;
                        this.Username = username;
                }

                private string displayName;

                public string DisplayName
                {
                        get
                        {
                                return this.displayName;
                        }

                        set
                        {
                                this.displayName = value;
                        }
                }

                private string emailAddress;

                public string EmailAddress
                {
                        get
                        {
                                return this.emailAddress;
                        }

                        set
                        {
                                this.emailAddress = value;
                        }
                }

                private string externalId;

                public string ExternalId
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

                private string externalIdentifiers;

                public string ExternalIdentifiers
                {
                        get
                        {
                                return this.externalIdentifiers;
                        }

                        set
                        {
                                this.externalIdentifiers = value;
                        }
                }

                private Guid identificationToken;

                [Required]
                public Guid IdentificationToken
                {
                        get
                        {
                                return this.identificationToken;
                        }

                        set
                        {
                                this.identificationToken = value;
                        }
                }

                private bool isActive;

                [Required]
                public bool IsActive
                {
                        get
                        {
                                return this.isActive;
                        }

                        set
                        {
                                this.isActive = value;
                        }
                }

                private bool isService;

                [Required]
                public bool IsService
                {
                        get
                        {
                                return this.isService;
                        }

                        set
                        {
                                this.isService = value;
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

                private string username;

                [Required]
                public string Username
                {
                        get
                        {
                                return this.username;
                        }

                        set
                        {
                                this.username = value;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>0b896ea7726f4b0673ead8a4a708c8c6</Hash>
</Codenesium>*/