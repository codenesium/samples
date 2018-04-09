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

		public void DeleteMode()
		{}
	}
}

/*<Codenesium>
    <Hash>4639cbc28cbf2e354bf08ce920a9ab0e</Hash>
</Codenesium>*/