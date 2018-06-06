using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Services
{
	public partial class BOLocation: AbstractBusinessObject
	{
		public BOLocation() : base()
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

		public decimal Availability { get; private set; }
		public decimal CostRate { get; private set; }
		public short LocationID { get; private set; }
		public DateTime ModifiedDate { get; private set; }
		public string Name { get; private set; }
	}
}

/*<Codenesium>
    <Hash>a62584c0c9fc4d2e6e012425e897266b</Hash>
</Codenesium>*/