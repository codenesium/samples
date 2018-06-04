using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("Location", Schema="Production")]
	public partial class Location: AbstractEntity
	{
		public Location()
		{}

		public void SetProperties(
			decimal availability,
			decimal costRate,
			short locationID,
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
		public decimal Availability { get; private set; }

		[Column("CostRate", TypeName="smallmoney")]
		public decimal CostRate { get; private set; }

		[Key]
		[Column("LocationID", TypeName="smallint")]
		public short LocationID { get; private set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; private set; }

		[Column("Name", TypeName="nvarchar(50)")]
		public string Name { get; private set; }
	}
}

/*<Codenesium>
    <Hash>5b6bf71bd41eb7fc360a0cbc08169295</Hash>
</Codenesium>*/