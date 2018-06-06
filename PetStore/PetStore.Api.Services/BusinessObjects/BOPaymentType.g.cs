using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace PetStoreNS.Api.Services
{
	public partial class BOPaymentType: AbstractBusinessObject
	{
		public BOPaymentType() : base()
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
    <Hash>0dadbd4d2db42685ad1df608b12b1818</Hash>
</Codenesium>*/