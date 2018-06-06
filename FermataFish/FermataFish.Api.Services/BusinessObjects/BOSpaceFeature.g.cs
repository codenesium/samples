using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace FermataFishNS.Api.Services
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
    <Hash>8b2e32ce8e176b1fac8f57ce9b090b00</Hash>
</Codenesium>*/