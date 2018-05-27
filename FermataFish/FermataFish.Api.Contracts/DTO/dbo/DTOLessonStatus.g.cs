using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace FermataFishNS.Api.Contracts
{
	public partial class DTOLessonStatus: AbstractDTO
	{
		public DTOLessonStatus() : base()
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
    <Hash>731b25ff26482b3f0a964bb727107426</Hash>
</Codenesium>*/