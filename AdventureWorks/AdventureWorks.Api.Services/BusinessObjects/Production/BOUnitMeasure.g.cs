using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Services
{
	public partial class BOUnitMeasure: AbstractBusinessObject
	{
		public BOUnitMeasure() : base()
		{}

		public void SetProperties(string unitMeasureCode,
		                          DateTime modifiedDate,
		                          string name)
		{
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.Name = name;
			this.UnitMeasureCode = unitMeasureCode;
		}

		public DateTime ModifiedDate { get; private set; }
		public string Name { get; private set; }
		public string UnitMeasureCode { get; private set; }
	}
}

/*<Codenesium>
    <Hash>f6ff3eeacdcd8c613f2a55e102662ccf</Hash>
</Codenesium>*/