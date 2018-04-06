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
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("ProductPhotoID", TypeName="int")]
		public int ProductPhotoID {get; set;}
		[Column("ThumbNailPhoto", TypeName="varbinary(-1)")]
		public byte[] ThumbNailPhoto {get; set;}
		[Column("ThumbnailPhotoFileName", TypeName="nvarchar(50)")]
		public string ThumbnailPhotoFileName {get; set;}
		[Column("LargePhoto", TypeName="varbinary(-1)")]
		public byte[] LargePhoto {get; set;}
		[Column("LargePhotoFileName", TypeName="nvarchar(50)")]
		public string LargePhotoFileName {get; set;}
		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate {get; set;}
	}
}

/*<Codenesium>
    <Hash>1879730fde22852f7adacb06e8468e7d</Hash>
</Codenesium>*/