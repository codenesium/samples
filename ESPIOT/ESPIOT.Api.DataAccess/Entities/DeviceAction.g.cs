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
			int id,
			string action,
			int deviceId,
			string name)
		{
			this.Id = id;
			this.Action = action;
			this.DeviceId = deviceId;
			this.Name = name;
		}

		[MaxLength(4000)]
		[Column("action")]
		public virtual string Action { get; private set; }

		[Column("deviceId")]
		public virtual int DeviceId { get; private set; }

		[Key]
		[Column("id")]
		public virtual int Id { get; private set; }

		[MaxLength(90)]
		[Column("name")]
		public virtual string Name { get; private set; }

		[ForeignKey("DeviceId")]
		public virtual Device DeviceIdNavigation { get; private set; }

		public void SetDeviceIdNavigation(Device item)
		{
			this.DeviceIdNavigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>54707722a2b7094c69f49b2ca109a349</Hash>
</Codenesium>*/