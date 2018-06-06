using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace PetStoreNS.Api.Services
{
	public partial class BOPen:AbstractBusinessObject
	{
		public BOPen() : base()
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
    <Hash>1bb65f932100583a5dfa863184e9ce67</Hash>
</Codenesium>*/