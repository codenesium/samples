using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

namespace FileServiceNS.Api.Contracts
{
        public abstract class AbstractApiVersionInfoResponseModel: AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        Nullable<DateTime> appliedOn,
                        string description,
                        long version)
                {
                        this.AppliedOn = appliedOn;
                        this.Description = description;
                        this.Version = version;
                }

                public Nullable<DateTime> AppliedOn { get; private set; }

                public string Description { get; private set; }

                public long Version { get; private set; }

                [JsonIgnore]
                public bool ShouldSerializeAppliedOnValue { get; set; } = false;

                public bool ShouldSerializeAppliedOn()
                {
                        return this.ShouldSerializeAppliedOnValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeDescriptionValue { get; set; } = false;

                public bool ShouldSerializeDescription()
                {
                        return this.ShouldSerializeDescriptionValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeVersionValue { get; set; } = false;

                public bool ShouldSerializeVersion()
                {
                        return this.ShouldSerializeVersionValue;
                }

                public virtual void DisableAllFields()
                {
                        this.ShouldSerializeAppliedOnValue = false;
                        this.ShouldSerializeDescriptionValue = false;
                        this.ShouldSerializeVersionValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>e8649f9985777a60165ac622315b8535</Hash>
</Codenesium>*/