using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace PetStoreNS.Api.Services
{
	public partial class BOBreed: AbstractBusinessObject
	{
		public BOBreed() : base()
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
    <Hash>cb1961df119e351a90313f2f4023dd5a</Hash>
</Codenesium>*/