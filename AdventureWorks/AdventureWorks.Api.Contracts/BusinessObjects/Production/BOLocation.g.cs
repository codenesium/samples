using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Contracts
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
    <Hash>32e3f73ed1b83ded35a5c75458fcf988</Hash>
</Codenesium>*/