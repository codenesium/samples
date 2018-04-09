using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service
{
	public class ProductDocumentModelValidator: AbstractProductDocumentModelValidator,IProductDocumentModelValidator
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
    <Hash>56f64ee83ce68b71e2638eb40c1d81b1</Hash>
</Codenesium>*/