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
    <Hash>6d1db9fa7b37c8eabeccc3db5920c748</Hash>
</Codenesium>*/