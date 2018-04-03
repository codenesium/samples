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
		public int productID {get; set;}
		public int productPhotoID {get; set;}
		public bool primary {get; set;}
		public DateTime modifiedDate {get; set;}
	}
}

/*<Codenesium>
    <Hash>72257345edb4a1b43b3599d3f149b769</Hash>
</Codenesium>*/