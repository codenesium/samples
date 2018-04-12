using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Service
{
	public class SpecialOfferProductModelValidator: AbstractSpecialOfferProductModelValidator, ISpecialOfferProductModelValidator
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
    <Hash>3f49b24df06537a20709b3406d7a6e50</Hash>
</Codenesium>*/