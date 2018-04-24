using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("Location", Schema="Production")]
	public partial class EFLocation: AbstractEntityFrameworkPOCO
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
			this.Name = name.ToString();
			this.CostRate = costRate.ToDecimal();
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
    <Hash>efd508b6d0e8e0d9bb3957c512fe0d23</Hash>
</Codenesium>*/