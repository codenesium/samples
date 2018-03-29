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

		public void PatchMode()
		{
			this.DocumentNodeRules();
			this.ModifiedDateRules();
		}
	}
}

/*<Codenesium>
    <Hash>a7de4ec57fcad73dfac5d0f1311a54bb</Hash>
</Codenesium>*/