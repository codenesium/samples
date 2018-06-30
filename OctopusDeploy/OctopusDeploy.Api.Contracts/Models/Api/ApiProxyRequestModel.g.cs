using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
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
    <Hash>834f21dfcff4301de20ca55e2766d020</Hash>
</Codenesium>*/