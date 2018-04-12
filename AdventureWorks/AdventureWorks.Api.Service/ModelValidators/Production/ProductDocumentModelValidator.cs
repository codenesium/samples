using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Service
{
	public class ProductDocumentModelValidator: AbstractProductDocumentModelValidator, IProductDocumentModelValidator
	{
		public ProductDocumentModelValidator()
		{   }

		public void CreateMode()
		{
			this.DocumentNodeRules();
			this.ModifiedDateRules();
		}

		public void UpdateMode()
		{
			this.DocumentNodeRules();
			this.ModifiedDateRules();
		}

		public void DeleteMode()
		{}
	}
}

/*<Codenesium>
    <Hash>824e3f32d9dd05819db00edeeca451b4</Hash>
</Codenesium>*/