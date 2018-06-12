using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

namespace OctopusDeployNS.Api.Contracts
{
        public partial class ApiProxyRequestModel: AbstractApiRequestModel
        {
                public ApiProxyRequestModel() : base()
                {
                }

                public void SetProperties(
                        string jSON,
                        string name)
                {
                        this.JSON = jSON;
                        this.Name = name;
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
    <Hash>bd447959e9b7e1d9fd79a054cfa70c7b</Hash>
</Codenesium>*/