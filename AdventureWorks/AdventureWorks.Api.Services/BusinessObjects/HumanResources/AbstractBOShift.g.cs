using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Services
{
        public abstract class AbstractBOShift : AbstractBusinessObject
        {
                public AbstractBOShift()
                        : base()
                {
                }

                public virtual void SetProperties(int shiftID,
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
    <Hash>6f2ba9a6c0827e53a517be004efac38a</Hash>
</Codenesium>*/