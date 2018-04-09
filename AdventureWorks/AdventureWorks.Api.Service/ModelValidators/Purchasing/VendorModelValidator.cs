using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service
{
	public class VendorModelValidator: AbstractVendorModelValidator,IVendorModelValidator
	{
		public VendorModelValidator()
		{   }

		public void CreateMode()
		{
			this.AccountNumberRules();
			this.NameRules();
			this.CreditRatingRules();
			this.PreferredVendorStatusRules();
			this.ActiveFlagRules();
			this.PurchasingWebServiceURLRules();
			this.ModifiedDateRules();
		}

		public void UpdateMode()
		{
			this.AccountNumberRules();
			this.NameRules();
			this.CreditRatingRules();
			this.PreferredVendorStatusRules();
			this.ActiveFlagRules();
			this.PurchasingWebServiceURLRules();
			this.ModifiedDateRules();
		}

		public void DeleteMode()
		{}
	}
}

/*<Codenesium>
    <Hash>e84eabf079f81aa1eed95cbb390c06f5</Hash>
</Codenesium>*/