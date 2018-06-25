using Codenesium.DataConversionExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
        public partial class ApiConfigurationRequestModel : AbstractApiRequestModel
        {
                public ApiConfigurationRequestModel()
                        : base()
                {
                }

                public virtual void SetProperties(
                        string jSON)
                {
                        this.JSON = jSON;
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
        }
}

/*<Codenesium>
    <Hash>928ed0a4767371098ab47807ddd9a16c</Hash>
</Codenesium>*/