using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("Location", Schema="Production")]
	public partial class Location: AbstractEntityFrameworkDTO
	{
		public Location()
		{}

		public void SetProperties(
			short locationID,
			decimal availability,
			decimal costRate,
			DateTime modifiedDate,
			string name)
		{
			this.Availability = availability.ToDecimal();
			this.CostRate = costRate.ToDecimal();
			this.LocationID = locationID;
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.Name = name;
		}

		[Column("Availability", TypeName="decimal")]
		public decimal Availability { get; set; }

		[Column("CostRate", TypeName="smallmoney")]
		public decimal CostRate { get; set; }

		[Key]
		[Column("LocationID", TypeName="smallint")]
		public short LocationID { get; set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; set; }

		[Column("Name", TypeName="nvarchar(50)")]
		public string Name { get; set; }
	}
}

/*<Codenesium>
    <Hash>a80519c79aaad636405c2de45faa013b</Hash>
</Codenesium>*/