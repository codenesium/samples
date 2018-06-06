using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Services
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
    <Hash>ed0c0d4fa2ef2092578d2c06d1dea07b</Hash>
</Codenesium>*/