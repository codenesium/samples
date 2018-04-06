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
    <Hash>db847373079c94780079de4c853db5f1</Hash>
</Codenesium>*/