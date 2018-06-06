using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace FermataFishNS.Api.Services
{
	public partial class BOTeacherSkill: AbstractBusinessObject
	{
		public BOTeacherSkill() : base()
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
    <Hash>6237d2ef80db7613e63bc5aaa4332776</Hash>
</Codenesium>*/