using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class DTOUnitMeasure: AbstractDTO
	{
		public DTOUnitMeasure() : base()
		{}

		public void SetProperties(string unitMeasureCode,
		                          DateTime modifiedDate,
		                          string name)
		{
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.Name = name;
			this.UnitMeasureCode = unitMeasureCode;
		}

		public DateTime ModifiedDate { get; set; }
		public string Name { get; set; }
		public string UnitMeasureCode { get; set; }
	}
}

/*<Codenesium>
    <Hash>f80d2a78d600ced1bbf528b53be1a18a</Hash>
</Codenesium>*/