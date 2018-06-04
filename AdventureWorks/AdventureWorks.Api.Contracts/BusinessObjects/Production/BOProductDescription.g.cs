using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class BOProductDescription: AbstractBusinessObject
	{
		public BOProductDescription() : base()
		{}

		public void SetProperties(int productDescriptionID,
		                          string description,
		                          DateTime modifiedDate,
		                          Guid rowguid)
		{
			this.Description = description;
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.ProductDescriptionID = productDescriptionID.ToInt();
			this.Rowguid = rowguid.ToGuid();
		}

		public string Description { get; private set; }
		public DateTime ModifiedDate { get; private set; }
		public int ProductDescriptionID { get; private set; }
		public Guid Rowguid { get; private set; }
	}
}

/*<Codenesium>
    <Hash>0724a1c4896a044fd84c7f77ad031960</Hash>
</Codenesium>*/