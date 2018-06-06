using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Services
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
    <Hash>f6752392e5d262ef1bd87c5a8a30411e</Hash>
</Codenesium>*/