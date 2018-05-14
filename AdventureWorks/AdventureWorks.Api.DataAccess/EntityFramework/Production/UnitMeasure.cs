using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("UnitMeasure", Schema="Production")]
	public partial class UnitMeasure: AbstractEntityFrameworkPOCO
	{
		public UnitMeasure()
		{}

		public void SetProperties(
			string unitMeasureCode,
			DateTime modifiedDate,
			string name)
		{
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.Name = name.ToString();
			this.UnitMeasureCode = unitMeasureCode.ToString();
		}

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; set; }

		[Column("Name", TypeName="nvarchar(50)")]
		public string Name { get; set; }

		[Key]
		[Column("UnitMeasureCode", TypeName="nchar(3)")]
		public string UnitMeasureCode { get; set; }
	}
}

/*<Codenesium>
    <Hash>37964b402ec6b73bac4916ba788080e4</Hash>
</Codenesium>*/