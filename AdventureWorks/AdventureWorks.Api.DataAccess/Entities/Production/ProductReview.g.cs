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
		public virtual string Comment { get; private set; }

		[MaxLength(50)]
		[Column("EmailAddress")]
		public virtual string EmailAddress { get; private set; }

		[Column("ModifiedDate")]
		public virtual DateTime ModifiedDate { get; private set; }

		[Column("ProductID")]
		public virtual int ProductID { get; private set; }

		[Key]
		[Column("ProductReviewID")]
		public virtual int ProductReviewID { get; private set; }

		[Column("Rating")]
		public virtual int Rating { get; private set; }

		[Column("ReviewDate")]
		public virtual DateTime ReviewDate { get; private set; }

		[MaxLength(50)]
		[Column("ReviewerName")]
		public virtual string ReviewerName { get; private set; }
	}
}

/*<Codenesium>
    <Hash>4d3e73a340d8e84bbd5020e3adb8d0a4</Hash>
</Codenesium>*/