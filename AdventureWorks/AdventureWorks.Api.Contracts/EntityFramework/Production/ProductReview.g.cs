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
		public int productReviewID {get; set;}
		public int productID {get; set;}
		public string reviewerName {get; set;}
		public DateTime reviewDate {get; set;}
		public string emailAddress {get; set;}
		public int rating {get; set;}
		public string comments {get; set;}
		public DateTime modifiedDate {get; set;}
	}
}

/*<Codenesium>
    <Hash>33e96b14a7d469a880135e7eae30faac</Hash>
</Codenesium>*/