using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ESPIOTNS.Api.Contracts
{
	[Table("Device", Schema="dbo")]
	public partial class EFDevice
	{
		public EFDevice()
		{}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("id", TypeName="int")]
		public int Id {get; set;}

		[Column("publicId", TypeName="uniqueidentifier")]
		public Guid PublicId {get; set;}

		[Column("name", TypeName="varchar(90)")]
		public string Name {get; set;}
	}
}

/*<Codenesium>
    <Hash>ecaeeb8d74865756c212e2edaa7ac489</Hash>
</Codenesium>*/