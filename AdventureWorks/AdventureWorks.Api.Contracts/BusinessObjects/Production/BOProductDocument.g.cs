using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class BOProductDocument: AbstractBusinessObject
	{
		public BOProductDocument() : base()
		{}

		public void SetProperties(int productID,
		                          Guid documentNode,
		                          DateTime modifiedDate)
		{
			this.DocumentNode = documentNode.ToGuid();
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.ProductID = productID.ToInt();
		}

		public Guid DocumentNode { get; private set; }
		public DateTime ModifiedDate { get; private set; }
		public int ProductID { get; private set; }
	}
}

/*<Codenesium>
    <Hash>050cf9702fa4e0c82c635c8089a8879e</Hash>
</Codenesium>*/