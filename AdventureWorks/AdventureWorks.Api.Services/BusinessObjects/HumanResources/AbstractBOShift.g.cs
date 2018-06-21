using Codenesium.DataConversionExtensions;
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
    <Hash>0a1a3de2321968eb9b9ed5313ec18612</Hash>
</Codenesium>*/