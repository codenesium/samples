using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiDepartmentResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        short departmentID,
                        string groupName,
                        DateTime modifiedDate,
                        string name)
                {
                        this.DepartmentID = departmentID;
                        this.GroupName = groupName;
                        this.ModifiedDate = modifiedDate;
                        this.Name = name;
                }

                public short DepartmentID { get; private set; }

                public string GroupName { get; private set; }

                public DateTime ModifiedDate { get; private set; }

                public string Name { get; private set; }

                [JsonIgnore]
                public bool ShouldSerializeDepartmentIDValue { get; set; } = true;

                public bool ShouldSerializeDepartmentID()
                {
                        return this.ShouldSerializeDepartmentIDValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeGroupNameValue { get; set; } = true;

                public bool ShouldSerializeGroupName()
                {
                        return this.ShouldSerializeGroupNameValue;
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

                public virtual void DisableAllFields()
                {
                        this.ShouldSerializeDepartmentIDValue = false;
                        this.ShouldSerializeGroupNameValue = false;
                        this.ShouldSerializeModifiedDateValue = false;
                        this.ShouldSerializeNameValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>2aa157a096b7ca232abf50b483f4385f</Hash>
</Codenesium>*/