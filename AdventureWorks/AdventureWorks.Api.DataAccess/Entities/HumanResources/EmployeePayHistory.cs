using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("EmployeePayHistory", Schema="HumanResources")]
	public partial class EmployeePayHistory: AbstractEntity
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
		public int BusinessEntityID { get; private set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; private set; }

		[Column("PayFrequency", TypeName="tinyint")]
		public int PayFrequency { get; private set; }

		[Column("Rate", TypeName="money")]
		public decimal Rate { get; private set; }

		[Column("RateChangeDate", TypeName="datetime")]
		public DateTime RateChangeDate { get; private set; }
	}
}

/*<Codenesium>
    <Hash>b8fb17ae00d0c1421cdbaf16a23f665e</Hash>
</Codenesium>*/