using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiDepartmentRequestModel : AbstractApiRequestModel
        {
                public ApiDepartmentRequestModel()
                        : base()
                {
                }

                public virtual void SetProperties(
                        string groupName,
                        DateTime modifiedDate,
                        string name)
                {
                        this.GroupName = groupName;
                        this.ModifiedDate = modifiedDate;
                        this.Name = name;
                }

                [Required]
                [JsonProperty]
                public string GroupName { get; private set; }

                [Required]
                [JsonProperty]
                public DateTime ModifiedDate { get; private set; }

                [Required]
                [JsonProperty]
                public string Name { get; private set; }
        }
}

/*<Codenesium>
    <Hash>c9bed3bcd2c7fba267ef771e9022d91d</Hash>
</Codenesium>*/