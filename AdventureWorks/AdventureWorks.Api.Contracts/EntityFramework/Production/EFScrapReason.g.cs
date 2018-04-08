using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AdventureWorksNS.Api.Contracts
{
	[Table("ScrapReason", Schema="Production")]
	public partial class EFScrapReason
	{
		public EFScrapReason()
		{}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("ScrapReasonID", TypeName="smallint")]
		public short ScrapReasonID {get; set;}

		[Column("Name", TypeName="nvarchar(50)")]
		public string Name {get; set;}

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate {get; set;}
	}
}

/*<Codenesium>
    <Hash>e15d1e6a7dab38679d7091312d77b0a3</Hash>
</Codenesium>*/