using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Services
{
        public partial class BOShift: AbstractBusinessObject
        {
                public BOShift() : base()
                {
                }

                public void SetProperties(int shiftID,
                                          TimeSpan endTime,
                                          DateTime modifiedDate,
                                          string name,
                                          TimeSpan startTime)
                {
                        this.EndTime = endTime;
                        this.ModifiedDate = modifiedDate;
                        this.Name = name;
                        this.ShiftID = shiftID;
                        this.StartTime = startTime;
                }

                public TimeSpan EndTime { get; private set; }

                public DateTime ModifiedDate { get; private set; }

                public string Name { get; private set; }

                public int ShiftID { get; private set; }

                public TimeSpan StartTime { get; private set; }
        }
}

/*<Codenesium>
    <Hash>10690b4b9cb74208e08dafc8bcb6d9cb</Hash>
</Codenesium>*/