using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace FermataFishNS.Api.Contracts
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
    <Hash>2b45a843c6e64783f9cfabd090ba43da</Hash>
</Codenesium>*/