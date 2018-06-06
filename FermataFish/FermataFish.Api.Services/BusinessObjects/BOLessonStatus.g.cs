using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace FermataFishNS.Api.Services
{
	public partial class BOLessonStatus: AbstractBusinessObject
	{
		public BOLessonStatus() : base()
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
    <Hash>f6c9af100fe036cec7bfc71941551f96</Hash>
</Codenesium>*/