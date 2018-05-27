using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace FermataFishNS.Api.Contracts
{
	public partial class DTOSpace: AbstractDTO
	{
		public DTOSpace() : base()
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

		public string Description { get; set; }
		public int Id { get; set; }
		public string Name { get; set; }
		public int StudioId { get; set; }
	}
}

/*<Codenesium>
    <Hash>9b70cba09562931796c451dd417f51ed</Hash>
</Codenesium>*/