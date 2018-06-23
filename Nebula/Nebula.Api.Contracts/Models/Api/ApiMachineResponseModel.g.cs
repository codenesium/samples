using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace NebulaNS.Api.Contracts
{
        public class ApiMachineResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        string description,
                        int id,
                        string jwtKey,
                        string lastIpAddress,
                        Guid machineGuid,
                        string name)
                {
                        this.Description = description;
                        this.Id = id;
                        this.JwtKey = jwtKey;
                        this.LastIpAddress = lastIpAddress;
                        this.MachineGuid = machineGuid;
                        this.Name = name;
                }

                public string Description { get; private set; }

                public int Id { get; private set; }

                public string JwtKey { get; private set; }

                public string LastIpAddress { get; private set; }

                public Guid MachineGuid { get; private set; }

                public string Name { get; private set; }

                [JsonIgnore]
                public bool ShouldSerializeDescriptionValue { get; set; } = true;

                public bool ShouldSerializeDescription()
                {
                        return this.ShouldSerializeDescriptionValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeIdValue { get; set; } = true;

                public bool ShouldSerializeId()
                {
                        return this.ShouldSerializeIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeJwtKeyValue { get; set; } = true;

                public bool ShouldSerializeJwtKey()
                {
                        return this.ShouldSerializeJwtKeyValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeLastIpAddressValue { get; set; } = true;

                public bool ShouldSerializeLastIpAddress()
                {
                        return this.ShouldSerializeLastIpAddressValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeMachineGuidValue { get; set; } = true;

                public bool ShouldSerializeMachineGuid()
                {
                        return this.ShouldSerializeMachineGuidValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeNameValue { get; set; } = true;

                public bool ShouldSerializeName()
                {
                        return this.ShouldSerializeNameValue;
                }

                public virtual void DisableAllFields()
                {
                        this.ShouldSerializeDescriptionValue = false;
                        this.ShouldSerializeIdValue = false;
                        this.ShouldSerializeJwtKeyValue = false;
                        this.ShouldSerializeLastIpAddressValue = false;
                        this.ShouldSerializeMachineGuidValue = false;
                        this.ShouldSerializeNameValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>a7987f320e9708b4eaa9f9f0e2dde0d2</Hash>
</Codenesium>*/