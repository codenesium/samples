using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace PetStoreNS.Api.Contracts
{
	public partial class DTOBreed: AbstractDTO
	{
		public DTOBreed() : base()
		{}

		public void SetProperties(int id,
		                          string name)
		{
			this.Id = id.ToInt();
			this.Name = name;
		}

		public int Id { get; set; }
		public string Name { get; set; }
	}
}

/*<Codenesium>
    <Hash>e272774efc5bf69f02f4b4fa107e7754</Hash>
</Codenesium>*/