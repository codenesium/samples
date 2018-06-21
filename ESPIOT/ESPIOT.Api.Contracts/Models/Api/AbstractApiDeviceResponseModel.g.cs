using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace ESPIOTNS.Api.Contracts
{
        public abstract class AbstractApiDeviceResponseModel : AbstractApiResponseModel
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
    <Hash>e0cfef1b30cda89aef8c6d65be38ee03</Hash>
</Codenesium>*/