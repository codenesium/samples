using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
        public partial class ApiProjectTriggerRequestModel : AbstractApiRequestModel
        {
                public ApiProjectTriggerRequestModel()
                        : base()
                {
                }

                public virtual void SetProperties(
                        bool isDisabled,
                        string jSON,
                        string name,
                        string projectId,
                        string triggerType)
                {
                        this.IsDisabled = isDisabled;
                        this.JSON = jSON;
                        this.Name = name;
                        this.ProjectId = projectId;
                        this.TriggerType = triggerType;
                }

                private bool isDisabled;

                [Required]
                public bool IsDisabled
                {
                        get
                        {
                                return this.isDisabled;
                        }

                        set
                        {
                                this.isDisabled = value;
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

                private string projectId;

                [Required]
                public string ProjectId
                {
                        get
                        {
                                return this.projectId;
                        }

                        set
                        {
                                this.projectId = value;
                        }
                }

                private string triggerType;

                public string TriggerType
                {
                        get
                        {
                                return this.triggerType;
                        }

                        set
                        {
                                this.triggerType = value;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>4114020dfd37a59b276b1d6771c9e073</Hash>
</Codenesium>*/