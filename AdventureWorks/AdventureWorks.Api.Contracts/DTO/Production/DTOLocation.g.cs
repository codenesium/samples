using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class DTOLocation: AbstractDTO
	{
		public DTOLocation() : base()
		{}

		public void SetProperties(short locationID,
		                          decimal availability,
		                          decimal costRate,
		                          DateTime modifiedDate,
		                          string name)
		{
			this.Availability = availability.ToDecimal();
			this.CostRate = costRate.ToDecimal();
			this.LocationID = locationID;
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.Name = name;
		}

		public decimal Availability { get; set; }
		public decimal CostRate { get; set; }
		public short LocationID { get; set; }
		public DateTime ModifiedDate { get; set; }
		public string Name { get; set; }
	}
}

/*<Codenesium>
    <Hash>b2180cc396a00eb4bcfb4cc83120375c</Hash>
</Codenesium>*/