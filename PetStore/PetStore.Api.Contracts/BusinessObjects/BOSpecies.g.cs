using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace PetStoreNS.Api.Contracts
{
	public partial class BOSpecies: AbstractBusinessObject
	{
		public BOSpecies() : base()
		{}

		public void SetProperties(int id,
		                          string name)
		{
			this.Id = id.ToInt();
			this.Name = name;
		}

		public int Id { get; private set; }
		public string Name { get; private set; }
	}
}

/*<Codenesium>
    <Hash>8b6780cf85b9d4e5c16e97a2e623d09a</Hash>
</Codenesium>*/