using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace PetStoreNS.Api.Contracts
{
	public partial class BOBreed: AbstractBusinessObject
	{
		public BOBreed() : base()
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
    <Hash>7d315f5e03b9c05ff977cbff4e372f98</Hash>
</Codenesium>*/