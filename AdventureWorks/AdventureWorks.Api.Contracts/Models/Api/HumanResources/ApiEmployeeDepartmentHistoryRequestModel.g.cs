using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
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

                public virtual void SetProperties(
                        short departmentID,
                        DateTime? endDate,
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

                private DateTime? endDate;

                public DateTime? EndDate
                {
                        get
                        {
                                return this.endDate;
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
    <Hash>ccafca7ec285529fd8d3227e8500b072</Hash>
</Codenesium>*/