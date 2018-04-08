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

		[ForeignKey("ProductID")]
		public virtual EFProduct Product { get; set; }
		[ForeignKey("ProductPhotoID")]
		public virtual EFProductPhoto ProductPhoto { get; set; }
	}
}

/*<Codenesium>
    <Hash>977c69a99d7657a0c121f9681ac4d16d</Hash>
</Codenesium>*/