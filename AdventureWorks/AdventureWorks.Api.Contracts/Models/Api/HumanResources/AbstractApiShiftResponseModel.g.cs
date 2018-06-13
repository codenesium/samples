using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

namespace AdventureWorksNS.Api.Contracts
{
        public abstract class AbstractApiShiftResponseModel: AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        TimeSpan endTime,
                        DateTime modifiedDate,
                        string name,
                        int shiftID,
                        TimeSpan startTime)
                {
                        this.EndTime = endTime;
                        this.ModifiedDate = modifiedDate;
                        this.Name = name;
                        this.ShiftID = shiftID;
                        this.StartTime = startTime;
                }

                public TimeSpan EndTime { get; private set; }

                public DateTime ModifiedDate { get; private set; }

                public string Name { get; private set; }

                public int ShiftID { get; private set; }

                public TimeSpan StartTime { get; private set; }

                [JsonIgnore]
                public bool ShouldSerializeEndTimeValue { get; set; } = true;

                public bool ShouldSerializeEndTime()
                {
                        return this.ShouldSerializeEndTimeValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeModifiedDateValue { get; set; } = true;

                public bool ShouldSerializeModifiedDate()
                {
                        return this.ShouldSerializeModifiedDateValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeNameValue { get; set; } = true;

                public bool ShouldSerializeName()
                {
                        return this.ShouldSerializeNameValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeShiftIDValue { get; set; } = true;

                public bool ShouldSerializeShiftID()
                {
                        return this.ShouldSerializeShiftIDValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeStartTimeValue { get; set; } = true;

                public bool ShouldSerializeStartTime()
                {
                        return this.ShouldSerializeStartTimeValue;
                }

                public virtual void DisableAllFields()
                {
                        this.ShouldSerializeEndTimeValue = false;
                        this.ShouldSerializeModifiedDateValue = false;
                        this.ShouldSerializeNameValue = false;
                        this.ShouldSerializeShiftIDValue = false;
                        this.ShouldSerializeStartTimeValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>22e9fa0ca800931e2ec3909e131cc555</Hash>
</Codenesium>*/