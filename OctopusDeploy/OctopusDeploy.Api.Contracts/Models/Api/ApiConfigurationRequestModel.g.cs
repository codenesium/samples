using Codenesium.DataConversionExtensions.AspNetCore;
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

                public void SetProperties(
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
    <Hash>b7b5180191e57a456f5372ee9f9d96da</Hash>
</Codenesium>*/