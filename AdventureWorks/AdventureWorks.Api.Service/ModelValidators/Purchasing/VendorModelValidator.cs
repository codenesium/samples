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

		public void PatchMode()
		{
			this.AccountNumberRules();
			this.NameRules();
			this.CreditRatingRules();
			this.PreferredVendorStatusRules();
			this.ActiveFlagRules();
			this.PurchasingWebServiceURLRules();
			this.ModifiedDateRules();
		}
	}
}

/*<Codenesium>
    <Hash>206e218c002da83da464fc866cf53434</Hash>
</Codenesium>*/