using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service
{
	public class ProductReviewModelValidator: AbstractProductReviewModelValidator,IProductReviewModelValidator
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

		public void PatchMode()
		{
			this.ProductIDRules();
			this.ReviewerNameRules();
			this.ReviewDateRules();
			this.EmailAddressRules();
			this.RatingRules();
			this.CommentsRules();
			this.ModifiedDateRules();
		}
	}
}

/*<Codenesium>
    <Hash>63e984d5377f46eaf3b260d622f2c7fb</Hash>
</Codenesium>*/