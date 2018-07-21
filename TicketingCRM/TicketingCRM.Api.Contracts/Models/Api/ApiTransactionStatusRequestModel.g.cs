using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace TicketingCRMNS.Api.Contracts
{
        public partial class ApiTransactionStatusRequestModel : AbstractApiRequestModel
        {
                public ApiTransactionStatusRequestModel()
                        : base()
                {
                }

                public virtual void SetProperties(
                        string name)
                {
                        this.Name = name;
                }

                [JsonProperty]
                public string Name { get; private set; }
        }
}

/*<Codenesium>
    <Hash>56e5630e624255ae1fbec385c6c70ab5</Hash>
</Codenesium>*/