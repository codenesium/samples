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
		public int id {get; set;}
		public Guid publicId {get; set;}
		public string name {get; set;}
	}
}

/*<Codenesium>
    <Hash>3e71786a06b7186f5e019db62f1f6364</Hash>
</Codenesium>*/