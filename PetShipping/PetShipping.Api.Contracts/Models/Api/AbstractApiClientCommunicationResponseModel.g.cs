using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Contracts
{
        public abstract class AbstractApiClientCommunicationResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
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

                public virtual void DisableAllFields()
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
    <Hash>646ba239f619fd9fb4aab7165f2256b5</Hash>
</Codenesium>*/