using Codenesium.DataConversionExtensions.AspNetCore;
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

                public void SetProperties(
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
    <Hash>e7bfa0e070ea861ccb81c5b136392acc</Hash>
</Codenesium>*/