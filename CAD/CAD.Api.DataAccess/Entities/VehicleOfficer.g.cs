using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace CADNS.Api.DataAccess
{
	[Table("VehicleOfficer", Schema="dbo")]
	public partial class VehicleOfficer : AbstractEntity
	{
		public VehicleOfficer()
		{
		}

		public virtual void SetProperties(
			int id,
			int officerId,
			int vehicleId)
		{
			this.Id = id;
			this.OfficerId = officerId;
			this.VehicleId = vehicleId;
		}

		[Key]
		[Column("id")]
		public virtual int Id { get; private set; }

		[Column("officerId")]
		public virtual int OfficerId { get; private set; }

		[Column("vehicleId")]
		public virtual int VehicleId { get; private set; }

		[ForeignKey("OfficerId")]
		public virtual Officer OfficerIdNavigation { get; private set; }

		public void SetOfficerIdNavigation(Officer item)
		{
			this.OfficerIdNavigation = item;
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
    <Hash>f696aa7e359832e235ba5b81c138c79e</Hash>
</Codenesium>*/