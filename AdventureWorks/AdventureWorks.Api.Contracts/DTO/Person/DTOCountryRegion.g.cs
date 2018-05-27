using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class DTOCountryRegion: AbstractDTO
	{
		public DTOCountryRegion() : base()
		{}

		public void SetProperties(string countryRegionCode,
		                          DateTime modifiedDate,
		                          string name)
		{
			this.CountryRegionCode = countryRegionCode;
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.Name = name;
		}

		public string CountryRegionCode { get; set; }
		public DateTime ModifiedDate { get; set; }
		public string Name { get; set; }
	}
}

/*<Codenesium>
    <Hash>5291b99d90a58e7f80684a5c948c20f0</Hash>
</Codenesium>*/