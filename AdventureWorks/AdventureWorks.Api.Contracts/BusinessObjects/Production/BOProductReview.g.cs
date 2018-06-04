using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class BOProductReview: AbstractBusinessObject
	{
		public BOProductReview() : base()
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

		public string Comments { get; private set; }
		public string EmailAddress { get; private set; }
		public DateTime ModifiedDate { get; private set; }
		public int ProductID { get; private set; }
		public int ProductReviewID { get; private set; }
		public int Rating { get; private set; }
		public DateTime ReviewDate { get; private set; }
		public string ReviewerName { get; private set; }
	}
}

/*<Codenesium>
    <Hash>7c9457872f619d1a148c9888d582d00c</Hash>
</Codenesium>*/