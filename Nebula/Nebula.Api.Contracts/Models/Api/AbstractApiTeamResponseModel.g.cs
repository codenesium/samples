using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

namespace NebulaNS.Api.Contracts
{
        public abstract class AbstractApiTeamResponseModel: AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int id,
                        string name,
                        int organizationId)
                {
                        this.Id = id;
                        this.Name = name;
                        this.OrganizationId = organizationId;

                        this.OrganizationIdEntity = nameof(ApiResponse.Organizations);
                }

                public int Id { get; private set; }

                public string Name { get; private set; }

                public int OrganizationId { get; private set; }

                public string OrganizationIdEntity { get; set; }

                [JsonIgnore]
                public bool ShouldSerializeIdValue { get; set; } = true;

                public bool ShouldSerializeId()
                {
                        return this.ShouldSerializeIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeNameValue { get; set; } = true;

                public bool ShouldSerializeName()
                {
                        return this.ShouldSerializeNameValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeOrganizationIdValue { get; set; } = true;

                public bool ShouldSerializeOrganizationId()
                {
                        return this.ShouldSerializeOrganizationIdValue;
                }

                public virtual void DisableAllFields()
                {
                        this.ShouldSerializeIdValue = false;
                        this.ShouldSerializeNameValue = false;
                        this.ShouldSerializeOrganizationIdValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>9d5fb9d594db21218b9040cf16ba730c</Hash>
</Codenesium>*/