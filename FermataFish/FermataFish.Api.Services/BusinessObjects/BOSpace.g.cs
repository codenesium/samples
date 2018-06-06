using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace FermataFishNS.Api.Services
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
    <Hash>5d02c437015ef93737b67c0ad110fdf5</Hash>
</Codenesium>*/