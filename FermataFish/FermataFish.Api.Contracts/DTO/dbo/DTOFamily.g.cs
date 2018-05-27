using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace FermataFishNS.Api.Contracts
{
	public partial class DTOFamily: AbstractDTO
	{
		public DTOFamily() : base()
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

		public int Id { get; set; }
		public string Notes { get; set; }
		public string PcEmail { get; set; }
		public string PcFirstName { get; set; }
		public string PcLastName { get; set; }
		public string PcPhone { get; set; }
		public int StudioId { get; set; }
	}
}

/*<Codenesium>
    <Hash>f360da4815da17c90f6381e81458eca5</Hash>
</Codenesium>*/