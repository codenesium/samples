using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("ProductReview", Schema="Production")]
	public partial class EFProductReview
	{
		public EFProductReview()
		{}

		public void SetProperties(
			int productReviewID,
			int productID,
			string reviewerName,
			DateTime reviewDate,
			string emailAddress,
			int rating,
			string comments,
			DateTime modifiedDate)
		{
			this.ProductReviewID = productReviewID.ToInt();
			this.ProductID = productID.ToInt();
			this.ReviewerName = reviewerName.ToString();
			this.ReviewDate = reviewDate.ToDateTime();
			this.EmailAddress = emailAddress.ToString();
			this.Rating = rating.ToInt();
			this.Comments = comments.ToString();
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("ProductReviewID", TypeName="int")]
		public int ProductReviewID { get; set; }

		[Column("ProductID", TypeName="int")]
		public int ProductID { get; set; }

		[Column("ReviewerName", TypeName="nvarchar(50)")]
		public string ReviewerName { get; set; }

		[Column("ReviewDate", TypeName="datetime")]
		public DateTime ReviewDate { get; set; }

		[Column("EmailAddress", TypeName="nvarchar(50)")]
		public string EmailAddress { get; set; }

		[Column("Rating", TypeName="int")]
		public int Rating { get; set; }

		[Column("Comments", TypeName="nvarchar(3850)")]
		public string Comments { get; set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; set; }

		[ForeignKey("ProductID")]
		public virtual EFProduct Product { get; set; }
	}
}

/*<Codenesium>
    <Hash>25e884fab8cac2ec12b31ccc6e8d6467</Hash>
</Codenesium>*/