using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ESPIOTNS.Api.Contracts
{
	[Table("DeviceAction", Schema="dbo")]
	public partial class EFDeviceAction
	{
		public EFDeviceAction()
		{}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("id", TypeName="int")]
		public int Id {get; set;}

		[Column("deviceId", TypeName="int")]
		public int DeviceId {get; set;}

		[Column("name", TypeName="varchar(90)")]
		public string Name {get; set;}

		[Column("value", TypeName="varchar(4000)")]
		public string @Value {get; set;}

		[ForeignKey("deviceId")]
		public virtual EFDevice Device { get; set; }
	}
}

/*<Codenesium>
    <Hash>2d14e7fc1bb2ae88a72f3bf56a569a3d</Hash>
</Codenesium>*/