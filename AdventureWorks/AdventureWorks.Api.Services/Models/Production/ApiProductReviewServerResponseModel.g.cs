using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Services
{
	public partial class ApiProductReviewServerResponseModel : AbstractApiServerResponseModel
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

		[Required]
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
    <Hash>1bd92a664c3623cef71cd15ebfae2a99</Hash>
</Codenesium>*/