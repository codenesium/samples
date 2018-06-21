using Codenesium.DataConversionExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
        public partial class ApiMutexRequestModel : AbstractApiRequestModel
        {
                public ApiMutexRequestModel()
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
    <Hash>9859871dc624bace6c98af9e5d4820e1</Hash>
</Codenesium>*/