using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Client
{
	public partial class ApiProductReviewClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiProductReviewClientRequestModel()
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

		[JsonProperty]
		public string EmailAddress { get; private set; } = default(string);

		[JsonProperty]
		public DateTime ModifiedDate { get; private set; } = SqlDateTime.MinValue.Value;

		[JsonProperty]
		public int ProductID { get; private set; } = default(int);

		[JsonProperty]
		public int Rating { get; private set; } = default(int);

		[JsonProperty]
		public DateTime ReviewDate { get; private set; } = SqlDateTime.MinValue.Value;

		[JsonProperty]
		public string ReviewerName { get; private set; } = default(string);
	}
}

/*<Codenesium>
    <Hash>9c3398f3e447ab72397e0d759c6b2aed</Hash>
</Codenesium>*/