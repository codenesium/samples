using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Services
{
	public partial class ApiProductReviewServerRequestModel : AbstractApiServerRequestModel
	{
		public ApiProductReviewServerRequestModel()
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
		public string Comment { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public string EmailAddress { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public DateTime ModifiedDate { get; private set; } = SqlDateTime.MinValue.Value;

		[Required]
		[JsonProperty]
		public int ProductID { get; private set; }

		[Required]
		[JsonProperty]
		public int Rating { get; private set; } = default(int);

		[Required]
		[JsonProperty]
		public DateTime ReviewDate { get; private set; } = SqlDateTime.MinValue.Value;

		[Required]
		[JsonProperty]
		public string ReviewerName { get; private set; } = default(string);
	}
}

/*<Codenesium>
    <Hash>df29008c55057b2234f05da52e4c56c6</Hash>
</Codenesium>*/