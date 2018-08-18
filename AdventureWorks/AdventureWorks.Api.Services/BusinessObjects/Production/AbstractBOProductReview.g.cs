using Codenesium.DataConversionExtensions;
using System;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractBOProductReview : AbstractBusinessObject
	{
		public AbstractBOProductReview()
			: base()
		{
		}

		public virtual void SetProperties(int productReviewID,
		                                  string comment,
		                                  string emailAddress,
		                                  DateTime modifiedDate,
		                                  int productID,
		                                  int rating,
		                                  DateTime reviewDate,
		                                  string reviewerName)
		{
			this.Comment = comment;
			this.EmailAddress = emailAddress;
			this.ModifiedDate = modifiedDate;
			this.ProductID = productID;
			this.ProductReviewID = productReviewID;
			this.Rating = rating;
			this.ReviewDate = reviewDate;
			this.ReviewerName = reviewerName;
		}

		public string Comment { get; private set; }

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
    <Hash>196678f54f586d6f5fa2c1555681839d</Hash>
</Codenesium>*/