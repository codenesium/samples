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

		public void PatchMode()
		{
			this.ProductIDRules();
			this.RowguidRules();
			this.ModifiedDateRules();
		}
	}
}

/*<Codenesium>
    <Hash>f0878f379d6901009d388daebc43c442</Hash>
</Codenesium>*/