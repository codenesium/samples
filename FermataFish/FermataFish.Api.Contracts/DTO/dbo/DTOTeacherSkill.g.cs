using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace FermataFishNS.Api.Contracts
{
	public partial class DTOTeacherSkill: AbstractDTO
	{
		public DTOTeacherSkill() : base()
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
    <Hash>90f0cce9d5c0b254343be3370d36888b</Hash>
</Codenesium>*/