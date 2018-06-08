using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

namespace PetShippingNS.Api.Contracts
{
        public partial class ApiClientCommunicationResponseModel: AbstractApiResponseModel
        {
                public ApiClientCommunicationResponseModel() : base()
                {
                }

                public void SetProperties(
                        int clientId,
                        DateTime dateCreated,
                        int employeeId,
                        int id,
                        string notes)
                {
                        this.ClientId = clientId;
                        this.DateCreated = dateCreated;
                        this.EmployeeId = employeeId;
                        this.Id = id;
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

                [JsonIgnore]
                public bool ShouldSerializeClientIdValue { get; set; } = true;

                public bool ShouldSerializeClientId()
                {
                        return this.ShouldSerializeClientIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeDateCreatedValue { get; set; } = true;

                public bool ShouldSerializeDateCreated()
                {
                        return this.ShouldSerializeDateCreatedValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeEmployeeIdValue { get; set; } = true;

                public bool ShouldSerializeEmployeeId()
                {
                        return this.ShouldSerializeEmployeeIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeIdValue { get; set; } = true;

                public bool ShouldSerializeId()
                {
                        return this.ShouldSerializeIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeNotesValue { get; set; } = true;

                public bool ShouldSerializeNotes()
                {
                        return this.ShouldSerializeNotesValue;
                }

                public void DisableAllFields()
                {
                        this.ShouldSerializeClientIdValue = false;
                        this.ShouldSerializeDateCreatedValue = false;
                        this.ShouldSerializeEmployeeIdValue = false;
                        this.ShouldSerializeIdValue = false;
                        this.ShouldSerializeNotesValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>c203aa5aab8929edb7cac1797fa72704</Hash>
</Codenesium>*/