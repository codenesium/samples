using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AdventureWorksNS.Api.Contracts
{
	[Table("ProductDescription", Schema="Production")]
	public partial class EFProductDescription
	{
		public EFProductDescription()
		{}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("ProductDescriptionID", TypeName="int")]
		public int ProductDescriptionID {get; set;}

		[Column("Description", TypeName="nvarchar(400)")]
		public string Description {get; set;}

		[Column("rowguid", TypeName="uniqueidentifier")]
		public Guid Rowguid {get; set;}

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate {get; set;}
	}
}

/*<Codenesium>
    <Hash>557b733bb09c21949a0f71f366e610b8</Hash>
</Codenesium>*/