using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.Contracts
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
			this.ReviewerName = reviewerName;
			this.ReviewDate = reviewDate.ToDateTime();
			this.EmailAddress = emailAddress;
			this.Rating = rating.ToInt();
			this.Comments = comments;
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
    <Hash>bbe6a1689d549f38cdc0b216d885beaa</Hash>
</Codenesium>*/