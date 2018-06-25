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

                public virtual void SetProperties(
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
    <Hash>f9de46f0330e5446bda29033d00525f6</Hash>
</Codenesium>*/