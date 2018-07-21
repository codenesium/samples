using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Contracts
{
        public partial class ApiClientCommunicationResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int id,
                        int clientId,
                        DateTime dateCreated,
                        int employeeId,
                        string notes)
                {
                        this.Id = id;
                        this.ClientId = clientId;
                        this.DateCreated = dateCreated;
                        this.EmployeeId = employeeId;
                        this.Notes = notes;

                        this.ClientIdEntity = nameof(ApiResponse.Clients);
                        this.EmployeeIdEntity = nameof(ApiResponse.Employees);
                }

                [Required]
                [JsonProperty]
                public int ClientId { get; private set; }

                [JsonProperty]
                public string ClientIdEntity { get; set; }

                [Required]
                [JsonProperty]
                public DateTime DateCreated { get; private set; }

                [Required]
                [JsonProperty]
                public int EmployeeId { get; private set; }

                [JsonProperty]
                public string EmployeeIdEntity { get; set; }

                [Required]
                [JsonProperty]
                public int Id { get; private set; }

                [Required]
                [JsonProperty]
                public string Notes { get; private set; }
        }
}

/*<Codenesium>
    <Hash>35a93d89f42ba1a58f02eb5b94ed922d</Hash>
</Codenesium>*/