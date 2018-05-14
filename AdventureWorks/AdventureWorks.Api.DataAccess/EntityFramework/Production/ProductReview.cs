using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("ProductReview", Schema="Production")]
	public partial class ProductReview: AbstractEntityFrameworkPOCO
	{
		public ProductReview()
		{}

		public void SetProperties(
			int productReviewID,
			string comments,
			string emailAddress,
			DateTime modifiedDate,
			int productID,
			int rating,
			DateTime reviewDate,
			string reviewerName)
		{
			this.Comments = comments.ToString();
			this.EmailAddress = emailAddress.ToString();
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.ProductID = productID.ToInt();
			this.ProductReviewID = productReviewID.ToInt();
			this.Rating = rating.ToInt();
			this.ReviewDate = reviewDate.ToDateTime();
			this.ReviewerName = reviewerName.ToString();
		}

		[Column("Comments", TypeName="nvarchar(3850)")]
		public string Comments { get; set; }

		[Column("EmailAddress", TypeName="nvarchar(50)")]
		public string EmailAddress { get; set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; set; }

		[Column("ProductID", TypeName="int")]
		public int ProductID { get; set; }

		[Key]
		[Column("ProductReviewID", TypeName="int")]
		public int ProductReviewID { get; set; }

		[Column("Rating", TypeName="int")]
		public int Rating { get; set; }

		[Column("ReviewDate", TypeName="datetime")]
		public DateTime ReviewDate { get; set; }

		[Column("ReviewerName", TypeName="nvarchar(50)")]
		public string ReviewerName { get; set; }
	}
}

/*<Codenesium>
    <Hash>805fae744744b88037ffee5f8f2e3aa7</Hash>
</Codenesium>*/