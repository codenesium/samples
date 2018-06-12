using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

namespace OctopusDeployNS.Api.Contracts
{
        public partial class ApiConfigurationRequestModel: AbstractApiRequestModel
        {
                public ApiConfigurationRequestModel() : base()
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
    <Hash>a281d59a2d2335cd579f201dc784ac96</Hash>
</Codenesium>*/