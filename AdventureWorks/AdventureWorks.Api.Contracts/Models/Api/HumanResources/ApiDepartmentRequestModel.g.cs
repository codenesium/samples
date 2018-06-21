using Codenesium.DataConversionExtensions;
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

                public void SetProperties(
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
    <Hash>62d019785e78dabf33fbac4194d4e925</Hash>
</Codenesium>*/