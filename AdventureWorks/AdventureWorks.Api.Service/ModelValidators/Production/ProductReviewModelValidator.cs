using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Service
{
	public class ProductReviewModelValidator: AbstractProductReviewModelValidator, IProductReviewModelValidator
	{
		public ProductReviewModelValidator()
		{   }

		public void CreateMode()
		{
			this.ProductIDRules();
			this.ReviewerNameRules();
			this.ReviewDateRules();
			this.EmailAddressRules();
			this.RatingRules();
			this.CommentsRules();
			this.ModifiedDateRules();
		}

		public void UpdateMode()
		{
			this.ProductIDRules();
			this.ReviewerNameRules();
			this.ReviewDateRules();
			this.EmailAddressRules();
			this.RatingRules();
			this.CommentsRules();
			this.ModifiedDateRules();
		}

		public void DeleteMode()
		{}
	}
}

/*<Codenesium>
    <Hash>29fd53a7f135794fc393a3be1ab481be</Hash>
</Codenesium>*/