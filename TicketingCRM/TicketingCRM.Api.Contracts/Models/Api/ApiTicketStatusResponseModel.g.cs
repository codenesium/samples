using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace TicketingCRMNS.Api.Contracts
{
        public partial class ApiTicketStatusResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int id,
                        string name)
                {
                        this.Id = id;
                        this.Name = name;
                }

                [Required]
                [JsonProperty]
                public int Id { get; private set; }

                [Required]
                [JsonProperty]
                public string Name { get; private set; }
        }
}

/*<Codenesium>
    <Hash>e89fa64ba6192c0e8a113906efb73b90</Hash>
</Codenesium>*/