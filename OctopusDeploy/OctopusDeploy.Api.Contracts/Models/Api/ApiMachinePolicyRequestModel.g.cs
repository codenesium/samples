using Codenesium.DataConversionExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
        public partial class ApiMachinePolicyRequestModel : AbstractApiRequestModel
        {
                public ApiMachinePolicyRequestModel()
                        : base()
                {
                }

                public virtual void SetProperties(
                        bool isDefault,
                        string jSON,
                        string name)
                {
                        this.IsDefault = isDefault;
                        this.JSON = jSON;
                        this.Name = name;
                }

                private bool isDefault;

                [Required]
                public bool IsDefault
                {
                        get
                        {
                                return this.isDefault;
                        }

                        set
                        {
                                this.isDefault = value;
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
    <Hash>828a1f647e18ee49f8fcd9c2d8ee753c</Hash>
</Codenesium>*/