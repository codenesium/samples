using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Service
{
	public class VendorModelValidator: AbstractVendorModelValidator, IVendorModelValidator
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
    <Hash>09a0df7df9c8a74ef410ec00acc9adf0</Hash>
</Codenesium>*/