using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
        public partial class ApiActionTemplateRequestModel : AbstractApiRequestModel
        {
                public ApiActionTemplateRequestModel()
                        : base()
                {
                }

                public void SetProperties(
                        string actionType,
                        string communityActionTemplateId,
                        string jSON,
                        string name,
                        int version)
                {
                        this.ActionType = actionType;
                        this.CommunityActionTemplateId = communityActionTemplateId;
                        this.JSON = jSON;
                        this.Name = name;
                        this.Version = version;
                }

                private string actionType;

                [Required]
                public string ActionType
                {
                        get
                        {
                                return this.actionType;
                        }

                        set
                        {
                                this.actionType = value;
                        }
                }

                private string communityActionTemplateId;

                public string CommunityActionTemplateId
                {
                        get
                        {
                                return this.communityActionTemplateId.IsEmptyOrZeroOrNull() ? null : this.communityActionTemplateId;
                        }

                        set
                        {
                                this.communityActionTemplateId = value;
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

                private int version;

                [Required]
                public int Version
                {
                        get
                        {
                                return this.version;
                        }

                        set
                        {
                                this.version = value;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>610f1a0eb1285366eb97e0582d44c06b</Hash>
</Codenesium>*/