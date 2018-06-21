using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Services
{
        public abstract class AbstractBOUnitMeasure : AbstractBusinessObject
        {
                public AbstractBOUnitMeasure()
                        : base()
                {
                }

                public virtual void SetProperties(string unitMeasureCode,
                                                  DateTime modifiedDate,
                                                  string name)
                {
                        this.ModifiedDate = modifiedDate;
                        this.Name = name;
                        this.UnitMeasureCode = unitMeasureCode;
                }

                public DateTime ModifiedDate { get; private set; }

                public string Name { get; private set; }

                public string UnitMeasureCode { get; private set; }
        }
}

/*<Codenesium>
    <Hash>34b48a0a26328341e6b261f6c07ad15b</Hash>
</Codenesium>*/