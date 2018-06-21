using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
        public partial class ApiActionTemplateVersionRequestModel : AbstractApiRequestModel
        {
                public ApiActionTemplateVersionRequestModel()
                        : base()
                {
                }

                public void SetProperties(
                        string actionType,
                        string jSON,
                        string latestActionTemplateId,
                        string name,
                        int version)
                {
                        this.ActionType = actionType;
                        this.JSON = jSON;
                        this.LatestActionTemplateId = latestActionTemplateId;
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

                private string latestActionTemplateId;

                [Required]
                public string LatestActionTemplateId
                {
                        get
                        {
                                return this.latestActionTemplateId;
                        }

                        set
                        {
                                this.latestActionTemplateId = value;
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
    <Hash>6b07ab6dad3f3f80b8525eda979be5c2</Hash>
</Codenesium>*/