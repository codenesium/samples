using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace FileServiceNS.Api.Contracts
{
        public partial class ApiVersionInfoResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        long version,
                        DateTime? appliedOn,
                        string description)
                {
                        this.Version = version;
                        this.AppliedOn = appliedOn;
                        this.Description = description;
                }

                public DateTime? AppliedOn { get; private set; }

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
    <Hash>046726f579bcc92289185acf7811b221</Hash>
</Codenesium>*/