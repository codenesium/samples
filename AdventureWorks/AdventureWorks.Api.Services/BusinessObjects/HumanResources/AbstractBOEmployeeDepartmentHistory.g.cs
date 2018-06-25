using Codenesium.DataConversionExtensions;
using System;

namespace AdventureWorksNS.Api.Services
{
        public abstract class AbstractBOEmployeeDepartmentHistory : AbstractBusinessObject
        {
                public AbstractBOEmployeeDepartmentHistory()
                        : base()
                {
                }

                public virtual void SetProperties(int businessEntityID,
                                                  short departmentID,
                                                  DateTime? endDate,
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

                public DateTime? EndDate { get; private set; }

                public DateTime ModifiedDate { get; private set; }

                public int ShiftID { get; private set; }

                public DateTime StartDate { get; private set; }
        }
}

/*<Codenesium>
    <Hash>c1950b41b1ebe9652601e19c2a6fda0c</Hash>
</Codenesium>*/