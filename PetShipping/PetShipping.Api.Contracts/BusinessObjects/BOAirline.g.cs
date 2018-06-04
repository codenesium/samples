using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace PetShippingNS.Api.Contracts
{
	public partial class BOAirline: AbstractBusinessObject
	{
		public BOAirline() : base()
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
    <Hash>0b90e38b870881ab1fd0d8474c3435c9</Hash>
</Codenesium>*/