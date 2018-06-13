using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

namespace ESPIOTNS.Api.Contracts
{
        public abstract class AbstractApiDeviceResponseModel: AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int id,
                        string name,
                        Guid publicId)
                {
                        this.Id = id;
                        this.Name = name;
                        this.PublicId = publicId;
                }

                public int Id { get; private set; }

                public string Name { get; private set; }

                public Guid PublicId { get; private set; }

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
                public bool ShouldSerializePublicIdValue { get; set; } = true;

                public bool ShouldSerializePublicId()
                {
                        return this.ShouldSerializePublicIdValue;
                }

                public virtual void DisableAllFields()
                {
                        this.ShouldSerializeIdValue = false;
                        this.ShouldSerializeNameValue = false;
                        this.ShouldSerializePublicIdValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>5554a4a77473efceddd635ea14c5529e</Hash>
</Codenesium>*/