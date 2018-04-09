using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service
{
	public class ProductModelIllustrationModelValidator: AbstractProductModelIllustrationModelValidator,IProductModelIllustrationModelValidator
	{
		public ProductModelIllustrationModelValidator()
		{   }

		public void CreateMode()
		{
			this.IllustrationIDRules();
			this.ModifiedDateRules();
		}

		public void UpdateMode()
		{
			this.IllustrationIDRules();
			this.ModifiedDateRules();
		}

		public void DeleteMode()
		{}
	}
}

/*<Codenesium>
    <Hash>5912acfba850e3e9e98845a24b07d530</Hash>
</Codenesium>*/