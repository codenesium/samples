using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiIllustrationRequestModel : AbstractApiRequestModel
        {
                public ApiIllustrationRequestModel()
                        : base()
                {
                }

                public virtual void SetProperties(
                        string diagram,
                        DateTime modifiedDate)
                {
                        this.Diagram = diagram;
                        this.ModifiedDate = modifiedDate;
                }

                [JsonProperty]
                public string Diagram { get; private set; }

                [Required]
                [JsonProperty]
                public DateTime ModifiedDate { get; private set; }
        }
}

/*<Codenesium>
    <Hash>c30a211f2a7943c7ac0176fbb94e2bab</Hash>
</Codenesium>*/