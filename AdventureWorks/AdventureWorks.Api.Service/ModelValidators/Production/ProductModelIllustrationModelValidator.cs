using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Service
{
	public class ProductModelIllustrationModelValidator: AbstractProductModelIllustrationModelValidator, IProductModelIllustrationModelValidator
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
    <Hash>42b2021b3d7a9432808f748e6e54fc20</Hash>
</Codenesium>*/