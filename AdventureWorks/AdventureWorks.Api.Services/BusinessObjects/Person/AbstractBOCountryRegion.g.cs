using Codenesium.DataConversionExtensions;
using System;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractBOCountryRegion : AbstractBusinessObject
	{
		public AbstractBOCountryRegion()
			: base()
		{
		}

		public virtual void SetProperties(string countryRegionCode,
		                                  DateTime modifiedDate,
		                                  string name)
		{
			this.CountryRegionCode = countryRegionCode;
			this.ModifiedDate = modifiedDate;
			this.Name = name;
		}

		public string CountryRegionCode { get; private set; }

		public DateTime ModifiedDate { get; private set; }

		public string Name { get; private set; }
	}
}

/*<Codenesium>
    <Hash>275f27251a35ff82d1da9b7dc2df31b1</Hash>
</Codenesium>*/