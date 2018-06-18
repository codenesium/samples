using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Services
{
        public abstract class AbstractBODepartment: AbstractBusinessObject
        {
                public AbstractBODepartment() : base()
                {
                }

                public virtual void SetProperties(short departmentID,
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
    <Hash>3c7c3fdb2ceedb14727d27502159fb4b</Hash>
</Codenesium>*/