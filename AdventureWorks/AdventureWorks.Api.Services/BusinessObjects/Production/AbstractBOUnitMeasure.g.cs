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
    <Hash>91449577307de7ba9b0e1ecd1dcc42b6</Hash>
</Codenesium>*/