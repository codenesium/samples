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

                private string groupName;

                [Required]
                public string GroupName
                {
                        get
                        {
                                return this.groupName;
                        }

                        set
                        {
                                this.groupName = value;
                        }
                }

                private DateTime modifiedDate;

                [Required]
                public DateTime ModifiedDate
                {
                        get
                        {
                                return this.modifiedDate;
                        }

                        set
                        {
                                this.modifiedDate = value;
                        }
                }

                private string name;

                [Required]
                public string Name
                {
                        get
                        {
                                return this.name;
                        }

                        set
                        {
                                this.name = value;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>b9a1ffdc1701b7a0db97877c64018746</Hash>
</Codenesium>*/