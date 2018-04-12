using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.Contracts
{
	[Table("Location", Schema="Production")]
	public partial class EFLocation
	{
		public EFLocation()
		{}

		public void SetProperties(
			short locationID,
			string name,
			decimal costRate,
			decimal availability,
			DateTime modifiedDate)
		{
			this.LocationID = locationID;
			this.Name = name;
			this.CostRate = costRate;
			this.Availability = availability.ToDecimal();
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("LocationID", TypeName="smallint")]
		public short LocationID { get; set; }

		[Column("Name", TypeName="nvarchar(50)")]
		public string Name { get; set; }

		[Column("CostRate", TypeName="smallmoney")]
		public decimal CostRate { get; set; }

		[Column("Availability", TypeName="decimal")]
		public decimal Availability { get; set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; set; }
	}
}

/*<Codenesium>
    <Hash>3a031160c6e95ed9c39a2e2274b4e1d9</Hash>
</Codenesium>*/