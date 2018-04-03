using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AdventureWorksNS.Api.Contracts
{
	[Table("ProductPhoto", Schema="Production")]
	public partial class EFProductPhoto
	{
		public EFProductPhoto()
		{}

		[Key]
		public int productPhotoID {get; set;}
		public byte[] thumbNailPhoto {get; set;}
		public string thumbnailPhotoFileName {get; set;}
		public byte[] largePhoto {get; set;}
		public string largePhotoFileName {get; set;}
		public DateTime modifiedDate {get; set;}
	}
}

/*<Codenesium>
    <Hash>b65f60de70e4879b6d967f8fb14fbaf5</Hash>
</Codenesium>*/