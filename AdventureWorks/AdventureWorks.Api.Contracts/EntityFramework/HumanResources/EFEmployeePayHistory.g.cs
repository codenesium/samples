using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;
namespace AdventureWorksNS.Api.Contracts
{
	[Table("EmployeePayHistory", Schema="HumanResources")]
	public partial class EFEmployeePayHistory
	{
		public EFEmployeePayHistory()
		{}

		public void SetProperties(int businessEntityID,
		                          DateTime rateChangeDate,
		                          decimal rate,
		                          int payFrequency,
		                          DateTime modifiedDate)
		{
			this.BusinessEntityID = businessEntityID.ToInt();
			this.RateChangeDate = rateChangeDate.ToDateTime();
			this.Rate = rate;
			this.PayFrequency = payFrequency;
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("BusinessEntityID", TypeName="int")]
		public int BusinessEntityID {get; set;}

		[Column("RateChangeDate", TypeName="datetime")]
		public DateTime RateChangeDate {get; set;}

		[Column("Rate", TypeName="money")]
		public decimal Rate {get; set;}

		[Column("PayFrequency", TypeName="tinyint")]
		public int PayFrequency {get; set;}

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate {get; set;}

		public virtual EFEmployee Employee { get; set; }
	}
}

/*<Codenesium>
    <Hash>cbccd95227ce89c463393ff4d84ba7b9</Hash>
</Codenesium>*/