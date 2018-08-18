using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiProductReviewRequestModel : AbstractApiRequestModel
	{
		public ApiProductReviewRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
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
			this.Rating = rating;
			this.ReviewDate = reviewDate;
			this.ReviewerName = reviewerName;
		}

		[JsonProperty]
		public string Comment { get; private set; }

		[Required]
		[JsonProperty]
		public string EmailAddress { get; private set; }

		[Required]
		[JsonProperty]
		public DateTime ModifiedDate { get; private set; }

		[Required]
		[JsonProperty]
		public int ProductID { get; private set; }

		[Required]
		[JsonProperty]
		public int Rating { get; private set; }

		[Required]
		[JsonProperty]
		public DateTime ReviewDate { get; private set; }

		[Required]
		[JsonProperty]
		public string ReviewerName { get; private set; }
	}
}

/*<Codenesium>
    <Hash>682272dc229735d641459ad55203ee66</Hash>
</Codenesium>*/