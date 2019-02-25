using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Client
{
	public partial class ApiProductReviewClientResponseModel : AbstractApiClientResponseModel
	{
		public virtual void SetProperties(
			int productReviewID,
			string comment,
			string emailAddress,
			DateTime modifiedDate,
			int productID,
			int rating,
			DateTime reviewDate,
			string reviewerName)
		{
			this.ProductReviewID = productReviewID;
			this.Comment = comment;
			this.EmailAddress = emailAddress;
			this.ModifiedDate = modifiedDate;
			this.ProductID = productID;
			this.Rating = rating;
			this.ReviewDate = reviewDate;
			this.ReviewerName = reviewerName;

			this.ProductIDEntity = nameof(ApiResponse.Products);
		}

		[JsonProperty]
		public ApiProductClientResponseModel ProductIDNavigation { get; private set; }

		public void SetProductIDNavigation(ApiProductClientResponseModel value)
		{
			this.ProductIDNavigation = value;
		}

		[JsonProperty]
		public string Comment { get; private set; }

		[JsonProperty]
		public string EmailAddress { get; private set; }

		[JsonProperty]
		public DateTime ModifiedDate { get; private set; }

		[JsonProperty]
		public int ProductID { get; private set; }

		[JsonProperty]
		public string ProductIDEntity { get; set; }

		[JsonProperty]
		public int ProductReviewID { get; private set; }

		[JsonProperty]
		public int Rating { get; private set; }

		[JsonProperty]
		public DateTime ReviewDate { get; private set; }

		[JsonProperty]
		public string ReviewerName { get; private set; }
	}
}

/*<Codenesium>
    <Hash>04fda79cf41d5ce87c92914f1afa27ad</Hash>
</Codenesium>*/