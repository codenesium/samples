using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;
namespace AdventureWorksNS.Api.Contracts
{
	[Table("UnitMeasure", Schema="Production")]
	public partial class EFUnitMeasure
	{
		public EFUnitMeasure()
		{}

		public void SetProperties(string unitMeasureCode,
		                          string name,
		                          DateTime modifiedDate)
		{
			this.UnitMeasureCode = unitMeasureCode;
			this.Name = name;
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("UnitMeasureCode", TypeName="nchar(3)")]
		public string UnitMeasureCode {get; set;}

		[Column("Name", TypeName="nvarchar(50)")]
		public string Name {get; set;}

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate {get; set;}
	}
}

/*<Codenesium>
    <Hash>38024c5a1503c135ef8224e7bd28f60e</Hash>
</Codenesium>*/