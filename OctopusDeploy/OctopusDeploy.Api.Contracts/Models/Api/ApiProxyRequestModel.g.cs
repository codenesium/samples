using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
        public partial class ApiProxyRequestModel : AbstractApiRequestModel
        {
                public ApiProxyRequestModel()
                        : base()
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
    <Hash>5f16d9f01cf2e7d27d666c88a2748a1e</Hash>
</Codenesium>*/