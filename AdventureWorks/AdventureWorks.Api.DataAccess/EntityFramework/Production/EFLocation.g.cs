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
			decimal availability,
			decimal costRate,
			DateTime modifiedDate,
			string name)
		{
			this.Availability = availability.ToDecimal();
			this.CostRate = costRate.ToDecimal();
			this.LocationID = locationID;
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.Name = name.ToString();
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
    <Hash>1308a899056ed7f44aa9ad4bb4f58805</Hash>
</Codenesium>*/