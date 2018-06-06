using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Services
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
    <Hash>bfe6a1e7791463a95694b3625a1d58a0</Hash>
</Codenesium>*/