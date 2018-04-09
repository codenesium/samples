using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AdventureWorksNS.Api.Contracts
{
	[Table("ProductReview", Schema="Production")]
	public partial class EFProductReview
	{
		public EFProductReview()
		{}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("ProductReviewID", TypeName="int")]
		public int ProductReviewID {get; set;}

		[Column("ProductID", TypeName="int")]
		public int ProductID {get; set;}

		[Column("ReviewerName", TypeName="nvarchar(50)")]
		public string ReviewerName {get; set;}

		[Column("ReviewDate", TypeName="datetime")]
		public DateTime ReviewDate {get; set;}

		[Column("EmailAddress", TypeName="nvarchar(50)")]
		public string EmailAddress {get; set;}

		[Column("Rating", TypeName="int")]
		public int Rating {get; set;}

		[Column("Comments", TypeName="nvarchar(3850)")]
		public string Comments {get; set;}

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate {get; set;}

		public virtual EFProduct Product { get; set; }
	}
}

/*<Codenesium>
    <Hash>c3e0c87fd4f1f7c9a0c8a2df2ca0b1ba</Hash>
</Codenesium>*/