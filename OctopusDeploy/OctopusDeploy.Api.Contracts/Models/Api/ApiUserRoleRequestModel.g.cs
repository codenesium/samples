using Codenesium.DataConversionExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
        public partial class ApiUserRoleRequestModel : AbstractApiRequestModel
        {
                public ApiUserRoleRequestModel()
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
    <Hash>dbd41a3a27b513734e5693bc6bd06b9f</Hash>
</Codenesium>*/