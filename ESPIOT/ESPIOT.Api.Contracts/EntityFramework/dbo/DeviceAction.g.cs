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
		public int id {get; set;}
		public int deviceId {get; set;}
		public string name {get; set;}
		public string @value {get; set;}

		[ForeignKey("deviceId")]
		public virtual EFDevice DeviceRef { get; set; }
	}
}

/*<Codenesium>
    <Hash>a2918fe65356954c15aa3437e8c12ec4</Hash>
</Codenesium>*/