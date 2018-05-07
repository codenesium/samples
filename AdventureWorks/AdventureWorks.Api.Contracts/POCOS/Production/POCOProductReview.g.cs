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
			string comments,
			string emailAddress,
			DateTime modifiedDate,
			int productID,
			int productReviewID,
			int rating,
			DateTime reviewDate,
			string reviewerName)
		{
			this.Comments = comments.ToString();
			this.EmailAddress = emailAddress.ToString();
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.ProductID = productID.ToInt();
			this.ProductReviewID = productReviewID.ToInt();
			this.Rating = rating.ToInt();
			this.ReviewDate = reviewDate.ToDateTime();
			this.ReviewerName = reviewerName.ToString();
		}

		public string Comments { get; set; }
		public string EmailAddress { get; set; }
		public DateTime ModifiedDate { get; set; }
		public int ProductID { get; set; }
		public int ProductReviewID { get; set; }
		public int Rating { get; set; }
		public DateTime ReviewDate { get; set; }
		public string ReviewerName { get; set; }

		[JsonIgnore]
		public bool ShouldSerializeCommentsValue { get; set; } = true;

		public bool ShouldSerializeComments()
		{
			return this.ShouldSerializeCommentsValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeEmailAddressValue { get; set; } = true;

		public bool ShouldSerializeEmailAddress()
		{
			return this.ShouldSerializeEmailAddressValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeModifiedDateValue { get; set; } = true;

		public bool ShouldSerializeModifiedDate()
		{
			return this.ShouldSerializeModifiedDateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeProductIDValue { get; set; } = true;

		public bool ShouldSerializeProductID()
		{
			return this.ShouldSerializeProductIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeProductReviewIDValue { get; set; } = true;

		public bool ShouldSerializeProductReviewID()
		{
			return this.ShouldSerializeProductReviewIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeRatingValue { get; set; } = true;

		public bool ShouldSerializeRating()
		{
			return this.ShouldSerializeRatingValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeReviewDateValue { get; set; } = true;

		public bool ShouldSerializeReviewDate()
		{
			return this.ShouldSerializeReviewDateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeReviewerNameValue { get; set; } = true;

		public bool ShouldSerializeReviewerName()
		{
			return this.ShouldSerializeReviewerNameValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeCommentsValue = false;
			this.ShouldSerializeEmailAddressValue = false;
			this.ShouldSerializeModifiedDateValue = false;
			this.ShouldSerializeProductIDValue = false;
			this.ShouldSerializeProductReviewIDValue = false;
			this.ShouldSerializeRatingValue = false;
			this.ShouldSerializeReviewDateValue = false;
			this.ShouldSerializeReviewerNameValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>a1dd8d573013d6a452759e56343301a7</Hash>
</Codenesium>*/