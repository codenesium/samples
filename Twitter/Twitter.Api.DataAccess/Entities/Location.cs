using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace TwitterNS.Api.DataAccess
{
	[Table("Location", Schema="dbo")]
	public partial class Location : AbstractEntity
	{
		public Location()
		{
		}

		public virtual void SetProperties(
			int locationId,
			int gpsLat,
			int gpsLong,
			string locationName)
		{
			this.LocationId = locationId;
			this.GpsLat = gpsLat;
			this.GpsLong = gpsLong;
			this.LocationName = locationName;
		}

		[Column("gps_lat")]
		public virtual int GpsLat { get; private set; }

		[Column("gps_long")]
		public virtual int GpsLong { get; private set; }

		[Key]
		[Column("location_id")]
		public virtual int LocationId { get; private set; }

		[MaxLength(64)]
		[Column("location_name")]
		public virtual string LocationName { get; private set; }
	}
}

/*<Codenesium>
    <Hash>7b4e1190fc29c91ae03da4f3fbecbe6d</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/