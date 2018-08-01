using Codenesium.DataConversionExtensions;
using System;

namespace FermataFishNS.Api.Services
{
	public abstract class AbstractBOStudio : AbstractBusinessObject
	{
		public AbstractBOStudio()
			: base()
		{
		}

		public virtual void SetProperties(int id,
		                                  string address1,
		                                  string address2,
		                                  string city,
		                                  string name,
		                                  int stateId,
		                                  string website,
		                                  string zip)
		{
			this.Address1 = address1;
			this.Address2 = address2;
			this.City = city;
			this.Id = id;
			this.Name = name;
			this.StateId = stateId;
			this.Website = website;
			this.Zip = zip;
		}

		public string Address1 { get; private set; }

		public string Address2 { get; private set; }

		public string City { get; private set; }

		public int Id { get; private set; }

		public string Name { get; private set; }

		public int StateId { get; private set; }

		public string Website { get; private set; }

		public string Zip { get; private set; }
	}
}

/*<Codenesium>
    <Hash>be5075fc41805f74b66200cde9508a94</Hash>
</Codenesium>*/