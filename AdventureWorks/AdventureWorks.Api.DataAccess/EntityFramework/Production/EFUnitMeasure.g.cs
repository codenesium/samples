using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("UnitMeasure", Schema="Production")]
	public partial class EFUnitMeasure: AbstractEntityFrameworkPOCO
	{
		public EFUnitMeasure()
		{}

		public void SetProperties(
			string unitMeasureCode,
			string name,
			DateTime modifiedDate)
		{
			this.UnitMeasureCode = unitMeasureCode.ToString();
			this.Name = name.ToString();
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		[Key]
		[Column("UnitMeasureCode", TypeName="nchar(3)")]
		public string UnitMeasureCode { get; set; }

		[Column("Name", TypeName="nvarchar(50)")]
		public string Name { get; set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; set; }
	}
}

/*<Codenesium>
    <Hash>17b0443eafaa9ff40df68967891428e7</Hash>
</Codenesium>*/