using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace CADNS.Api.DataAccess
{
	[Table("VehicleCapabilities", Schema="dbo")]
	public partial class VehicleCapabilities : AbstractEntity
	{
		public VehicleCapabilities()
		{
		}

		public virtual void SetProperties(
			int id,
			int vehicleCapabilityId,
			int vehicleId)
		{
			this.Id = id;
			this.VehicleCapabilityId = vehicleCapabilityId;
			this.VehicleId = vehicleId;
		}

		[Key]
		[Column("id")]
		public virtual int Id { get; private set; }

		[Column("vehicleCapabilityId")]
		public virtual int VehicleCapabilityId { get; private set; }

		[Column("vehicleId")]
		public virtual int VehicleId { get; private set; }

		[ForeignKey("VehicleCapabilityId")]
		public virtual VehCapability VehicleCapabilityIdNavigation { get; private set; }

		public void SetVehicleCapabilityIdNavigation(VehCapability item)
		{
			this.VehicleCapabilityIdNavigation = item;
		}

		[ForeignKey("VehicleId")]
		public virtual Vehicle VehicleIdNavigation { get; private set; }

		public void SetVehicleIdNavigation(Vehicle item)
		{
			this.VehicleIdNavigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>53911b0ee6d54ee678ca840d97955bb3</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/