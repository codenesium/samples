using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

namespace NebulaNS.Api.Contracts
{
        public partial class ApiMachineResponseModel: AbstractApiResponseModel
        {
                public ApiMachineResponseModel() : base()
                {
                }

                public void SetProperties(
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

                public void DisableAllFields()
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
    <Hash>5baf7c641eab25cbb8bc412b63fb2179</Hash>
</Codenesium>*/