using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service
{
	public class SpecialOfferProductModelValidator: AbstractSpecialOfferProductModelValidator,ISpecialOfferProductModelValidator
	{
		public SpecialOfferProductModelValidator()
		{   }

		public void CreateMode()
		{
			this.ProductIDRules();
			this.RowguidRules();
			this.ModifiedDateRules();
		}

		public void UpdateMode()
		{
			this.ProductIDRules();
			this.RowguidRules();
			this.ModifiedDateRules();
		}

		public void DeleteMode()
		{}
	}
}

/*<Codenesium>
    <Hash>dd8f0a33d45b3d70376a614f2fd5f00b</Hash>
</Codenesium>*/