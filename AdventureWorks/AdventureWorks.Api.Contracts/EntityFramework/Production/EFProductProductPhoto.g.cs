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
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("ProductID", TypeName="int")]
		public int ProductID {get; set;}

		[Column("ProductPhotoID", TypeName="int")]
		public int ProductPhotoID {get; set;}

		[Column("Primary", TypeName="bit")]
		public bool Primary {get; set;}

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate {get; set;}

		public virtual EFProduct Product { get; set; }

		public virtual EFProductPhoto ProductPhoto { get; set; }
	}
}

/*<Codenesium>
    <Hash>37cf518e18334d00a7eff768848d7caf</Hash>
</Codenesium>*/