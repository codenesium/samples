using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Contracts
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
    <Hash>cd575ba3f4f2f74d3ba420c07d4389cf</Hash>
</Codenesium>*/