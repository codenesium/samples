using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

namespace FermataFishNS.Api.Contracts
{
        public abstract class AbstractApiTeacherSkillResponseModel: AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int id,
                        string name,
                        int studioId)
                {
                        this.Id = id;
                        this.Name = name;
                        this.StudioId = studioId;

                        this.StudioIdEntity = nameof(ApiResponse.Studios);
                }

                public int Id { get; private set; }

                public string Name { get; private set; }

                public int StudioId { get; private set; }

                public string StudioIdEntity { get; set; }

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
                        this.ShouldSerializeIdValue = false;
                        this.ShouldSerializeNameValue = false;
                        this.ShouldSerializeStudioIdValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>001f4dae96cf09a97f86a5799cec0929</Hash>
</Codenesium>*/