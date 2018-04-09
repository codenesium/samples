using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;
namespace ESPIOTNS.Api.Contracts
{
	[Table("DeviceAction", Schema="dbo")]
	public partial class EFDeviceAction
	{
		public EFDeviceAction()
		{}

		public void SetProperties(int id,
		                          int deviceId,
		                          string name,
		                          string @value)
		{
			this.Id = id.ToInt();
			this.DeviceId = deviceId.ToInt();
			this.Name = name;
			this.@Value = @value;
		}

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

		public virtual EFDevice Device { get; set; }
	}
}

/*<Codenesium>
    <Hash>f2f1c2175644533be4d14e5d4f5b6039</Hash>
</Codenesium>*/