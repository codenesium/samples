using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

namespace OctopusDeployNS.Api.Contracts
{
        public partial class ApiMachinePolicyRequestModel: AbstractApiRequestModel
        {
                public ApiMachinePolicyRequestModel() : base()
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
    <Hash>82cd3e9042ba3e7a14d59c4bb40f7722</Hash>
</Codenesium>*/