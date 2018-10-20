using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("ProductReview", Schema="Production")]
	public partial class ProductReview : AbstractEntity
	{
		public ProductReview()
		{
		}

		public virtual void SetProperties(
			string comment,
			string emailAddress,
			DateTime modifiedDate,
			int productID,
			int productReviewID,
			int rating,
			DateTime reviewDate,
			string reviewerName)
		{
			this.Comment = comment;
			this.EmailAddress = emailAddress;
			this.ModifiedDate = modifiedDate;
			this.ProductID = productID;
			this.ProductReviewID = productReviewID;
			this.Rating = rating;
			this.ReviewDate = reviewDate;
			this.ReviewerName = reviewerName;
		}

		[MaxLength(3850)]
		[Column("Comments")]
		public string Comment { get; private set; }

		[MaxLength(50)]
		[Column("EmailAddress")]
		public string EmailAddress { get; private set; }

		[Column("ModifiedDate")]
		public DateTime ModifiedDate { get; private set; }

		[Column("ProductID")]
		public int ProductID { get; private set; }

		[Key]
		[Column("ProductReviewID")]
		public int ProductReviewID { get; private set; }

		[Column("Rating")]
		public int Rating { get; private set; }

		[Column("ReviewDate")]
		public DateTime ReviewDate { get; private set; }

		[MaxLength(50)]
		[Column("ReviewerName")]
		public string ReviewerName { get; private set; }
	}
}

/*<Codenesium>
    <Hash>cd9a116da82c83b21d471436d5907562</Hash>
</Codenesium>*/