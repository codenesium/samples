using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace FermataFishNS.Api.Contracts
{
	public partial class BOSpace: AbstractBusinessObject
	{
		public BOSpace() : base()
		{}

		public void SetProperties(int id,
		                          string description,
		                          string name,
		                          int studioId)
		{
			this.Description = description;
			this.Id = id.ToInt();
			this.Name = name;
			this.StudioId = studioId.ToInt();
		}

		public string Description { get; private set; }
		public int Id { get; private set; }
		public string Name { get; private set; }
		public int StudioId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>655b1e21fcef36c2c22f083ddc3da322</Hash>
</Codenesium>*/