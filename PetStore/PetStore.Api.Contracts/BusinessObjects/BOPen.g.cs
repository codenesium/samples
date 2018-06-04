using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace PetStoreNS.Api.Contracts
{
	public partial class BOPen:AbstractBusinessObject
	{
		public BOPen() : base()
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
    <Hash>117123761c29ccc214128ff401c342b9</Hash>
</Codenesium>*/