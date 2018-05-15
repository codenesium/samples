using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiProductReviewModel
	{
		public ApiProductReviewModel()
		{}

		public ApiProductReviewModel(
			string comments,
			string emailAddress,
			DateTime modifiedDate,
			int productID,
			int rating,
			DateTime reviewDate,
			string reviewerName)
		{
			this.Comments = comments;
			this.EmailAddress = emailAddress;
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.ProductID = productID.ToInt();
			this.Rating = rating.ToInt();
			this.ReviewDate = reviewDate.ToDateTime();
			this.ReviewerName = reviewerName;
		}

		private string comments;

		public string Comments
		{
			get
			{
				return this.comments.IsEmptyOrZeroOrNull() ? null : this.comments;
			}

			set
			{
				this.comments = value;
			}
		}

		private string emailAddress;

		[Required]
		public string EmailAddress
		{
			get
			{
				return this.emailAddress;
			}

			set
			{
				this.emailAddress = value;
			}
		}

		private DateTime modifiedDate;

		[Required]
		public DateTime ModifiedDate
		{
			get
			{
				return this.modifiedDate;
			}

			set
			{
				this.modifiedDate = value;
			}
		}

		private int productID;

		[Required]
		public int ProductID
		{
			get
			{
				return this.productID;
			}

			set
			{
				this.productID = value;
			}
		}

		private int rating;

		[Required]
		public int Rating
		{
			get
			{
				return this.rating;
			}

			set
			{
				this.rating = value;
			}
		}

		private DateTime reviewDate;

		[Required]
		public DateTime ReviewDate
		{
			get
			{
				return this.reviewDate;
			}

			set
			{
				this.reviewDate = value;
			}
		}

		private string reviewerName;

		[Required]
		public string ReviewerName
		{
			get
			{
				return this.reviewerName;
			}

			set
			{
				this.reviewerName = value;
			}
		}
	}
}

/*<Codenesium>
    <Hash>4422eeb8b085ba69d21c8d4b9d3b2817</Hash>
</Codenesium>*/