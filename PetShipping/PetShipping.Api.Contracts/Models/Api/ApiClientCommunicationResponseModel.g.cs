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

                public int ClientId { get; private set; }

                public string ClientIdEntity { get; set; }

                public DateTime DateCreated { get; private set; }

                public int EmployeeId { get; private set; }

                public string EmployeeIdEntity { get; set; }

                public int Id { get; private set; }

                public string Notes { get; private set; }
        }
}

/*<Codenesium>
    <Hash>d63b81d4df5fc4df12f542ca9d7fa660</Hash>
</Codenesium>*/