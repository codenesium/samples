using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class DTOProductReview: AbstractDTO
	{
		public DTOProductReview() : base()
		{}

		public void SetProperties(int productReviewID,
		                          string comments,
		                          string emailAddress,
		                          DateTime modifiedDate,
		                          int productID,
		                          int rating,
		                          DateTime reviewDate,
		                          string reviewerName)
		{
			this.Comments = comments;
			this.EmailAddress = emailAddress;
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.ProductID = productID.ToInt();
			this.ProductReviewID = productReviewID.ToInt();
			this.Rating = rating.ToInt();
			this.ReviewDate = reviewDate.ToDateTime();
			this.ReviewerName = reviewerName;
		}

		public string Comments { get; set; }
		public string EmailAddress { get; set; }
		public DateTime ModifiedDate { get; set; }
		public int ProductID { get; set; }
		public int ProductReviewID { get; set; }
		public int Rating { get; set; }
		public DateTime ReviewDate { get; set; }
		public string ReviewerName { get; set; }
	}
}

/*<Codenesium>
    <Hash>a722764f12386bcd5006a6ca23d05115</Hash>
</Codenesium>*/