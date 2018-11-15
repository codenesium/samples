using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace ESPIOTNS.Api.DataAccess
{
	[Table("DeviceAction", Schema="dbo")]
	public partial class DeviceAction : AbstractEntity
	{
		public DeviceAction()
		{
		}

		public virtual void SetProperties(
			string @value,
			int deviceId,
			int id,
			string name)
		{
			this.@Value = @value;
			this.DeviceId = deviceId;
			this.Id = id;
			this.Name = name;
		}

		[Column("deviceId")]
		public virtual int DeviceId { get; private set; }

		[Key]
		[Column("id")]
		public virtual int Id { get; private set; }

		[MaxLength(90)]
		[Column("name")]
		public virtual string Name { get; private set; }

		[MaxLength(4000)]
		[Column("value")]
		public virtual string @Value { get; private set; }

		[ForeignKey("DeviceId")]
		public virtual Device DeviceNavigation { get; private set; }

		public void SetDeviceNavigation(Device item)
		{
			this.DeviceNavigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>abdbae40e0db1fa68c1da911460c1a4d</Hash>
</Codenesium>*/