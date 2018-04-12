using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class POCOProductReview
	{
		public POCOProductReview()
		{}

		public POCOProductReview(
			int productReviewID,
			int productID,
			string reviewerName,
			DateTime reviewDate,
			string emailAddress,
			int rating,
			string comments,
			DateTime modifiedDate)
		{
			this.ProductReviewID = productReviewID.ToInt();
			this.ReviewerName = reviewerName;
			this.ReviewDate = reviewDate.ToDateTime();
			this.EmailAddress = emailAddress;
			this.Rating = rating.ToInt();
			this.Comments = comments;
			this.ModifiedDate = modifiedDate.ToDateTime();

			this.ProductID = new ReferenceEntity<int>(productID,
			                                          "Product");
		}

		public int ProductReviewID { get; set; }
		public ReferenceEntity<int> ProductID { get; set; }
		public string ReviewerName { get; set; }
		public DateTime ReviewDate { get; set; }
		public string EmailAddress { get; set; }
		public int Rating { get; set; }
		public string Comments { get; set; }
		public DateTime ModifiedDate { get; set; }

		[JsonIgnore]
		public bool ShouldSerializeProductReviewIDValue { get; set; } = true;

		public bool ShouldSerializeProductReviewID()
		{
			return this.ShouldSerializeProductReviewIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeProductIDValue { get; set; } = true;

		public bool ShouldSerializeProductID()
		{
			return this.ShouldSerializeProductIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeReviewerNameValue { get; set; } = true;

		public bool ShouldSerializeReviewerName()
		{
			return this.ShouldSerializeReviewerNameValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeReviewDateValue { get; set; } = true;

		public bool ShouldSerializeReviewDate()
		{
			return this.ShouldSerializeReviewDateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeEmailAddressValue { get; set; } = true;

		public bool ShouldSerializeEmailAddress()
		{
			return this.ShouldSerializeEmailAddressValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeRatingValue { get; set; } = true;

		public bool ShouldSerializeRating()
		{
			return this.ShouldSerializeRatingValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeCommentsValue { get; set; } = true;

		public bool ShouldSerializeComments()
		{
			return this.ShouldSerializeCommentsValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeModifiedDateValue { get; set; } = true;

		public bool ShouldSerializeModifiedDate()
		{
			return this.ShouldSerializeModifiedDateValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeProductReviewIDValue = false;
			this.ShouldSerializeProductIDValue = false;
			this.ShouldSerializeReviewerNameValue = false;
			this.ShouldSerializeReviewDateValue = false;
			this.ShouldSerializeEmailAddressValue = false;
			this.ShouldSerializeRatingValue = false;
			this.ShouldSerializeCommentsValue = false;
			this.ShouldSerializeModifiedDateValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>5a2e3826e90e8765be5e6081ed0fbb5b</Hash>
</Codenesium>*/