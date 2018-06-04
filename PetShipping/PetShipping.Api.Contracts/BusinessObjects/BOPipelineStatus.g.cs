using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace PetShippingNS.Api.Contracts
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
    <Hash>6699bb8b9ff54817a4a429f2e7b574da</Hash>
</Codenesium>*/