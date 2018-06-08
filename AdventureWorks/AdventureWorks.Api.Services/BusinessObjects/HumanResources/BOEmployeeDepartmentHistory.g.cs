using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Services
{
        public partial class BOEmployeeDepartmentHistory: AbstractBusinessObject
        {
                public BOEmployeeDepartmentHistory() : base()
                {
                }

                public void SetProperties(int businessEntityID,
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
        }
}

/*<Codenesium>
    <Hash>68edb101a0989d0fc0dad47bca436d4c</Hash>
</Codenesium>*/