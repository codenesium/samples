using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AdventureWorksNS.Api.Contracts
{
	[Table("ProductProductPhoto", Schema="Production")]
	public partial class EFProductProductPhoto
	{
		public EFProductProductPhoto()
		{}

		[Key]
		public int ProductID {get; set;}
		public int ProductPhotoID {get; set;}
		public bool Primary {get; set;}
		public DateTime ModifiedDate {get; set;}

		[ForeignKey("ProductID")]
		public virtual EFProduct ProductRef { get; set; }
		[ForeignKey("ProductPhotoID")]
		public virtual EFProductPhoto ProductPhotoRef { get; set; }
	}
}

/*<Codenesium>
    <Hash>b13f40a051d5d451d9e2002e644e2cec</Hash>
</Codenesium>*/