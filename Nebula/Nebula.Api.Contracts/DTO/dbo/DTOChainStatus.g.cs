using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace NebulaNS.Api.Contracts
{
	public partial class DTOChainStatus: AbstractDTO
	{
		public DTOChainStatus() : base()
		{}

		public void SetProperties(int id,
		                          string name)
		{
			this.Id = id.ToInt();
			this.Name = name;
		}

		public int Id { get; set; }
		public string Name { get; set; }
	}
}

/*<Codenesium>
    <Hash>e9751d0da584c13bc94f288c2f70feb3</Hash>
</Codenesium>*/