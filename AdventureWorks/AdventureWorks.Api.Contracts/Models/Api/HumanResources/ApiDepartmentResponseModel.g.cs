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

                [JsonProperty]
                public short DepartmentID { get; private set; }

                [JsonProperty]
                public string GroupName { get; private set; }

                [JsonProperty]
                public DateTime ModifiedDate { get; private set; }

                [JsonProperty]
                public string Name { get; private set; }
        }
}

/*<Codenesium>
    <Hash>1adf34d28a9acb3b4c9b3579f170ac41</Hash>
</Codenesium>*/