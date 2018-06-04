using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace FermataFishNS.Api.Contracts
{
	public partial class BOSpaceFeature: AbstractBusinessObject
	{
		public BOSpaceFeature() : base()
		{}

		public void SetProperties(int id,
		                          string name,
		                          int studioId)
		{
			this.Id = id.ToInt();
			this.Name = name;
			this.StudioId = studioId.ToInt();
		}

		public int Id { get; private set; }
		public string Name { get; private set; }
		public int StudioId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>32baa2129d1e625183d32d84aa8d0187</Hash>
</Codenesium>*/