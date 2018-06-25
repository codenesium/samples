using Codenesium.DataConversionExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiShiftRequestModel : AbstractApiRequestModel
        {
                public ApiShiftRequestModel()
                        : base()
                {
                }

                public virtual void SetProperties(
                        TimeSpan endTime,
                        DateTime modifiedDate,
                        string name,
                        TimeSpan startTime)
                {
                        this.EndTime = endTime;
                        this.ModifiedDate = modifiedDate;
                        this.Name = name;
                        this.StartTime = startTime;
                }

                private TimeSpan endTime;

                [Required]
                public TimeSpan EndTime
                {
                        get
                        {
                                return this.endTime;
                        }

                        set
                        {
                                this.endTime = value;
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

                private TimeSpan startTime;

                [Required]
                public TimeSpan StartTime
                {
                        get
                        {
                                return this.startTime;
                        }

                        set
                        {
                                this.startTime = value;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>2de2c5828d176d7e2c26000e72f56f4c</Hash>
</Codenesium>*/