using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace FermataFishNS.Api.Contracts
{
        public class ApiSpaceResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        string description,
                        int id,
                        string name,
                        int studioId)
                {
                        this.Description = description;
                        this.Id = id;
                        this.Name = name;
                        this.StudioId = studioId;

                        this.StudioIdEntity = nameof(ApiResponse.Studios);
                }

                public string Description { get; private set; }

                public int Id { get; private set; }

                public string Name { get; private set; }

                public int StudioId { get; private set; }

                public string StudioIdEntity { get; set; }

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
                public bool ShouldSerializeNameValue { get; set; } = true;

                public bool ShouldSerializeName()
                {
                        return this.ShouldSerializeNameValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeStudioIdValue { get; set; } = true;

                public bool ShouldSerializeStudioId()
                {
                        return this.ShouldSerializeStudioIdValue;
                }

                public virtual void DisableAllFields()
                {
                        this.ShouldSerializeDescriptionValue = false;
                        this.ShouldSerializeIdValue = false;
                        this.ShouldSerializeNameValue = false;
                        this.ShouldSerializeStudioIdValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>df0c8e2bc35b165697be087c466b0b7f</Hash>
</Codenesium>*/