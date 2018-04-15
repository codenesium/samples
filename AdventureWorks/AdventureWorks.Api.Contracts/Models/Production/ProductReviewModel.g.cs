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

		public ProductReviewModel(
			int productID,
			string reviewerName,
			DateTime reviewDate,
			string emailAddress,
			int rating,
			string comments,
			DateTime modifiedDate)
		{
			this.ProductID = productID.ToInt();
			this.ReviewerName = reviewerName.ToString();
			this.ReviewDate = reviewDate.ToDateTime();
			this.EmailAddress = emailAddress.ToString();
			this.Rating = rating.ToInt();
			this.Comments = comments.ToString();
			this.ModifiedDate = modifiedDate.ToDateTime();
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
	}
}

/*<Codenesium>
    <Hash>1b7c3642ae786b07149f1f9bb023655d</Hash>
</Codenesium>*/