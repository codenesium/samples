using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace NebulaNS.Api.Contracts
{
        public abstract class AbstractApiVersionInfoResponseModel : AbstractApiResponseModel
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
                public bool ShouldSerializeAppliedOnValue { get; set; } = true;

                public bool ShouldSerializeAppliedOn()
                {
                        return this.ShouldSerializeAppliedOnValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeDescriptionValue { get; set; } = true;

                public bool ShouldSerializeDescription()
                {
                        return this.ShouldSerializeDescriptionValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeVersionValue { get; set; } = true;

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
    <Hash>117a953f5348220927c161f394fe4cec</Hash>
</Codenesium>*/