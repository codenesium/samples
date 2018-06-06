using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace PetShippingNS.Api.Services
{
	public partial class BOPipelineStatus: AbstractBusinessObject
	{
		public BOPipelineStatus() : base()
		{}

		public void SetProperties(int id,
		                          string name)
		{
			this.Id = id.ToInt();
			this.Name = name;
		}

		public int Id { get; private set; }
		public string Name { get; private set; }
	}
}

/*<Codenesium>
    <Hash>37386f9f5e29a422aaa42f41b92cf3ab</Hash>
</Codenesium>*/