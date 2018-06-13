using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

namespace AdventureWorksNS.Api.Contracts
{
        public abstract class AbstractApiEmployeeDepartmentHistoryResponseModel: AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int businessEntityID,
                        short departmentID,
                        Nullable<DateTime> endDate,
                        DateTime modifiedDate,
                        int shiftID,
                        DateTime startDate)
                {
                        this.BusinessEntityID = businessEntityID;
                        this.DepartmentID = departmentID;
                        this.EndDate = endDate;
                        this.ModifiedDate = modifiedDate;
                        this.ShiftID = shiftID;
                        this.StartDate = startDate;
                }

                public int BusinessEntityID { get; private set; }

                public short DepartmentID { get; private set; }

                public Nullable<DateTime> EndDate { get; private set; }

                public DateTime ModifiedDate { get; private set; }

                public int ShiftID { get; private set; }

                public DateTime StartDate { get; private set; }

                [JsonIgnore]
                public bool ShouldSerializeBusinessEntityIDValue { get; set; } = true;

                public bool ShouldSerializeBusinessEntityID()
                {
                        return this.ShouldSerializeBusinessEntityIDValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeDepartmentIDValue { get; set; } = true;

                public bool ShouldSerializeDepartmentID()
                {
                        return this.ShouldSerializeDepartmentIDValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeEndDateValue { get; set; } = true;

                public bool ShouldSerializeEndDate()
                {
                        return this.ShouldSerializeEndDateValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeModifiedDateValue { get; set; } = true;

                public bool ShouldSerializeModifiedDate()
                {
                        return this.ShouldSerializeModifiedDateValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeShiftIDValue { get; set; } = true;

                public bool ShouldSerializeShiftID()
                {
                        return this.ShouldSerializeShiftIDValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeStartDateValue { get; set; } = true;

                public bool ShouldSerializeStartDate()
                {
                        return this.ShouldSerializeStartDateValue;
                }

                public virtual void DisableAllFields()
                {
                        this.ShouldSerializeBusinessEntityIDValue = false;
                        this.ShouldSerializeDepartmentIDValue = false;
                        this.ShouldSerializeEndDateValue = false;
                        this.ShouldSerializeModifiedDateValue = false;
                        this.ShouldSerializeShiftIDValue = false;
                        this.ShouldSerializeStartDateValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>7bc606129fee2260e494a954e6dfc4d4</Hash>
</Codenesium>*/