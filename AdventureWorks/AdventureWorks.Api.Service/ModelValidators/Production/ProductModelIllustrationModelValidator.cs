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

		public void PatchMode()
		{
			this.IllustrationIDRules();
			this.ModifiedDateRules();
		}
	}
}

/*<Codenesium>
    <Hash>16f4fc0b4d1a60bb02be06dd35e9455d</Hash>
</Codenesium>*/