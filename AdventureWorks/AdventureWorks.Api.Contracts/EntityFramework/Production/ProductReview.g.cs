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
		public int ProductReviewID {get; set;}
		public int ProductID {get; set;}
		public string ReviewerName {get; set;}
		public DateTime ReviewDate {get; set;}
		public string EmailAddress {get; set;}
		public int Rating {get; set;}
		public string Comments {get; set;}
		public DateTime ModifiedDate {get; set;}

		[ForeignKey("ProductID")]
		public virtual EFProduct ProductRef { get; set; }
	}
}

/*<Codenesium>
    <Hash>7de26995737b40aefc52229b4458aa00</Hash>
</Codenesium>*/