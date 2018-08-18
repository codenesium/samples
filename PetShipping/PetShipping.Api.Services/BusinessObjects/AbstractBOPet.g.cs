using Codenesium.DataConversionExtensions;
using System;

namespace PetShippingNS.Api.Services
{
	public abstract class AbstractBOPet : AbstractBusinessObject
	{
		public AbstractBOPet()
			: base()
		{
		}

		public virtual void SetProperties(int id,
		                                  int breedId,
		                                  int clientId,
		                                  string name,
		                                  int weight)
		{
			this.BreedId = breedId;
			this.ClientId = clientId;
			this.Id = id;
			this.Name = name;
			this.Weight = weight;
		}

		public int BreedId { get; private set; }

		public int ClientId { get; private set; }

		public int Id { get; private set; }

		public string Name { get; private set; }

		public int Weight { get; private set; }
	}
}

/*<Codenesium>
    <Hash>6b177fb61a2c18fa0dd79916cbdcd8dc</Hash>
</Codenesium>*/