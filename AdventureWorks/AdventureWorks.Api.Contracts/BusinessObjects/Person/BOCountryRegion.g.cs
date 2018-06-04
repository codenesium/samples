using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class BOCountryRegion: AbstractBusinessObject
	{
		public BOCountryRegion() : base()
		{}

		public void SetProperties(string countryRegionCode,
		                          DateTime modifiedDate,
		                          string name)
		{
			this.CountryRegionCode = countryRegionCode;
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.Name = name;
		}

		public string CountryRegionCode { get; private set; }
		public DateTime ModifiedDate { get; private set; }
		public string Name { get; private set; }
	}
}

/*<Codenesium>
    <Hash>6ce2dfdac47d6b2f6ef27c93c9a25eeb</Hash>
</Codenesium>*/