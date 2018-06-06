using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace PetStoreNS.Api.Services
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
    <Hash>49c969a2ea281f2eede9f39b4f2c4372</Hash>
</Codenesium>*/