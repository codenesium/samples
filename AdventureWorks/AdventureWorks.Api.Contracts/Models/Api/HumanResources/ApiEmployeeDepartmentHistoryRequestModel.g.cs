using Codenesium.DataConversionExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiEmployeeDepartmentHistoryRequestModel : AbstractApiRequestModel
        {
                public ApiEmployeeDepartmentHistoryRequestModel()
                        : base()
                {
                }

                public void SetProperties(
                        short departmentID,
                        Nullable<DateTime> endDate,
                        DateTime modifiedDate,
                        int shiftID,
                        DateTime startDate)
                {
                        this.DepartmentID = departmentID;
                        this.EndDate = endDate;
                        this.ModifiedDate = modifiedDate;
                        this.ShiftID = shiftID;
                        this.StartDate = startDate;
                }

                private short departmentID;

                [Required]
                public short DepartmentID
                {
                        get
                        {
                                return this.departmentID;
                        }

                        set
                        {
                                this.departmentID = value;
                        }
                }

                private Nullable<DateTime> endDate;

                public Nullable<DateTime> EndDate
                {
                        get
                        {
                                return this.endDate.IsEmptyOrZeroOrNull() ? null : this.endDate;
                        }

                        set
                        {
                                this.endDate = value;
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

                private int shiftID;

                [Required]
                public int ShiftID
                {
                        get
                        {
                                return this.shiftID;
                        }

                        set
                        {
                                this.shiftID = value;
                        }
                }

                private DateTime startDate;

                [Required]
                public DateTime StartDate
                {
                        get
                        {
                                return this.startDate;
                        }

                        set
                        {
                                this.startDate = value;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>c5b442e36612bb4878ce5848784aa889</Hash>
</Codenesium>*/