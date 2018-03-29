using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class ProductReviewModel
	{
		public ProductReviewModel()
		{}

		public ProductReviewModel(int productID,
		                          string reviewerName,
		                          DateTime reviewDate,
		                          string emailAddress,
		                          int rating,
		                          string comments,
		                          DateTime modifiedDate)
		{
			this.ProductID = productID.ToInt();
			this.ReviewerName = reviewerName;
			this.ReviewDate = reviewDate.ToDateTime();
			this.EmailAddress = emailAddress;
			this.Rating = rating.ToInt();
			this.Comments = comments;
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		public ProductReviewModel(POCOProductReview poco)
		{
			this.ReviewerName = poco.ReviewerName;
			this.ReviewDate = poco.ReviewDate.ToDateTime();
			this.EmailAddress = poco.EmailAddress;
			this.Rating = poco.Rating.ToInt();
			this.Comments = poco.Comments;
			this.ModifiedDate = poco.ModifiedDate.ToDateTime();

			this.ProductID = poco.ProductID.Value.ToInt();
		}

		private int _productID;
		[Required]
		public int ProductID
		{
			get
			{
				return _productID;
			}
			set
			{
				this._productID = value;
			}
		}

		private string _reviewerName;
		[Required]
		public string ReviewerName
		{
			get
			{
				return _reviewerName;
			}
			set
			{
				this._reviewerName = value;
			}
		}

		private DateTime _reviewDate;
		[Required]
		public DateTime ReviewDate
		{
			get
			{
				return _reviewDate;
			}
			set
			{
				this._reviewDate = value;
			}
		}

		private string _emailAddress;
		[Required]
		public string EmailAddress
		{
			get
			{
				return _emailAddress;
			}
			set
			{
				this._emailAddress = value;
			}
		}

		private int _rating;
		[Required]
		public int Rating
		{
			get
			{
				return _rating;
			}
			set
			{
				this._rating = value;
			}
		}

		private string _comments;
		public string Comments
		{
			get
			{
				return _comments.IsEmptyOrZeroOrNull() ? null : _comments;
			}
			set
			{
				this._comments = value;
			}
		}

		private DateTime _modifiedDate;
		[Required]
		public DateTime ModifiedDate
		{
			get
			{
				return _modifiedDate;
			}
			set
			{
				this._modifiedDate = value;
			}
		}
	}
}

/*<Codenesium>
    <Hash>e65b623a0d7712420e444e3f85f54dd5</Hash>
</Codenesium>*/