using Codenesium.DataConversionExtensions;
using System;

namespace TicketingCRMNS.Api.Services
{
	public abstract class AbstractBOProvince : AbstractBusinessObject
	{
		public AbstractBOProvince()
			: base()
		{
		}

		public virtual void SetProperties(int id,
		                                  int countryId,
		                                  string name)
		{
			this.CountryId = countryId;
			this.Id = id;
			this.Name = name;
		}

		public int CountryId { get; private set; }

		public int Id { get; private set; }

		public string Name { get; private set; }
	}
}

/*<Codenesium>
    <Hash>15d9a297367f0b260cb9cc55c367ebd0</Hash>
</Codenesium>*/