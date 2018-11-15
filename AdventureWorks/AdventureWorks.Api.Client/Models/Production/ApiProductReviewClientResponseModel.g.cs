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
    <Hash>137ba36d22d3eb03f087f0ce45ea344d</Hash>
</Codenesium>*/