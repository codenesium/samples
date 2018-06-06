using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace PetShippingNS.Api.Services
{
	public partial class BOPipelineStepStatus: AbstractBusinessObject
	{
		public BOPipelineStepStatus() : base()
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
    <Hash>47122d17bf94009fa72d52cd98f741c1</Hash>
</Codenesium>*/