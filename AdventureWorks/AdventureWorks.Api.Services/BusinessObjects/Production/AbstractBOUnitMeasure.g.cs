using Codenesium.DataConversionExtensions;
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
    <Hash>533c86377013e3fffe8b789fe751cfbc</Hash>
</Codenesium>*/