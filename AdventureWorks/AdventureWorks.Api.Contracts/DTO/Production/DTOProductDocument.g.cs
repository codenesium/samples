using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class DTOProductDocument: AbstractDTO
	{
		public DTOProductDocument() : base()
		{}

		public void SetProperties(int productID,
		                          Guid documentNode,
		                          DateTime modifiedDate)
		{
			this.DocumentNode = documentNode.ToGuid();
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.ProductID = productID.ToInt();
		}

		public Guid DocumentNode { get; set; }
		public DateTime ModifiedDate { get; set; }
		public int ProductID { get; set; }
	}
}

/*<Codenesium>
    <Hash>f1ce5c4ea915df00ef489d62a66993e7</Hash>
</Codenesium>*/