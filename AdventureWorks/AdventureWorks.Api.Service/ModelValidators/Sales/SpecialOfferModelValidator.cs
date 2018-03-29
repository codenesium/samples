using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service
{
	public class SpecialOfferModelValidator: AbstractSpecialOfferModelValidator,ISpecialOfferModelValidator
	{
		public SpecialOfferModelValidator()
		{   }

		public void CreateMode()
		{
			this.DescriptionRules();
			this.DiscountPctRules();
			this.TypeRules();
			this.CategoryRules();
			this.StartDateRules();
			this.EndDateRules();
			this.MinQtyRules();
			this.MaxQtyRules();
			this.RowguidRules();
			this.ModifiedDateRules();
		}

		public void UpdateMode()
		{
			this.DescriptionRules();
			this.DiscountPctRules();
			this.TypeRules();
			this.CategoryRules();
			this.StartDateRules();
			this.EndDateRules();
			this.MinQtyRules();
			this.MaxQtyRules();
			this.RowguidRules();
			this.ModifiedDateRules();
		}

		public void PatchMode()
		{
			this.DescriptionRules();
			this.DiscountPctRules();
			this.TypeRules();
			this.CategoryRules();
			this.StartDateRules();
			this.EndDateRules();
			this.MinQtyRules();
			this.MaxQtyRules();
			this.RowguidRules();
			this.ModifiedDateRules();
		}
	}
}

/*<Codenesium>
    <Hash>71e01c7d37e142990f9216c09113cbe0</Hash>
</Codenesium>*/