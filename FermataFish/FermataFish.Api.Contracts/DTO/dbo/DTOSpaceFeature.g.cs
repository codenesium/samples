using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace FermataFishNS.Api.Contracts
{
	public partial class DTOSpaceFeature: AbstractDTO
	{
		public DTOSpaceFeature() : base()
		{}

		public void SetProperties(int id,
		                          string name,
		                          int studioId)
		{
			this.Id = id.ToInt();
			this.Name = name;
			this.StudioId = studioId.ToInt();
		}

		public int Id { get; set; }
		public string Name { get; set; }
		public int StudioId { get; set; }
	}
}

/*<Codenesium>
    <Hash>8175ea39a724723bf9e5e8a415493481</Hash>
</Codenesium>*/