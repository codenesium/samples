using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("EmployeePayHistory", Schema="HumanResources")]
	public partial class EmployeePayHistory: AbstractEntityFrameworkPOCO
	{
		public EmployeePayHistory()
		{}

		public void SetProperties(
			int businessEntityID,
			DateTime modifiedDate,
			int payFrequency,
			decimal rate,
			DateTime rateChangeDate)
		{
			this.BusinessEntityID = businessEntityID.ToInt();
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.PayFrequency = payFrequency.ToInt();
			this.Rate = rate.ToDecimal();
			this.RateChangeDate = rateChangeDate.ToDateTime();
		}

		[Key]
		[Column("BusinessEntityID", TypeName="int")]
		public int BusinessEntityID { get; set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; set; }

		[Column("PayFrequency", TypeName="tinyint")]
		public int PayFrequency { get; set; }

		[Column("Rate", TypeName="money")]
		public decimal Rate { get; set; }

		[Column("RateChangeDate", TypeName="datetime")]
		public DateTime RateChangeDate { get; set; }
	}
}

/*<Codenesium>
    <Hash>efd847a88736a5534223ae3292ea1fb3</Hash>
</Codenesium>*/