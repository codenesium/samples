using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace FermataFishNS.Api.Services
{
	public partial class BOFamily: AbstractBusinessObject
	{
		public BOFamily() : base()
		{}

		public void SetProperties(int id,
		                          string notes,
		                          string pcEmail,
		                          string pcFirstName,
		                          string pcLastName,
		                          string pcPhone,
		                          int studioId)
		{
			this.Id = id.ToInt();
			this.Notes = notes;
			this.PcEmail = pcEmail;
			this.PcFirstName = pcFirstName;
			this.PcLastName = pcLastName;
			this.PcPhone = pcPhone;
			this.StudioId = studioId.ToInt();
		}

		public int Id { get; private set; }
		public string Notes { get; private set; }
		public string PcEmail { get; private set; }
		public string PcFirstName { get; private set; }
		public string PcLastName { get; private set; }
		public string PcPhone { get; private set; }
		public int StudioId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>e62170702908b8a69d5dc76516186c23</Hash>
</Codenesium>*/