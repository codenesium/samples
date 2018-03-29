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
		public int ProductPhotoID {get; set;}
		public byte[] ThumbNailPhoto {get; set;}
		public string ThumbnailPhotoFileName {get; set;}
		public byte[] LargePhoto {get; set;}
		public string LargePhotoFileName {get; set;}
		public DateTime ModifiedDate {get; set;}
	}
}

/*<Codenesium>
    <Hash>7b55ad029ea5dd6957ed6894f7223703</Hash>
</Codenesium>*/