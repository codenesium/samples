using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Services
{
        public partial class BODepartment: AbstractBusinessObject
        {
                public BODepartment() : base()
                {
                }

                public void SetProperties(short departmentID,
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
        }
}

/*<Codenesium>
    <Hash>5cddf55e273aeaf3d3567790da5d5998</Hash>
</Codenesium>*/