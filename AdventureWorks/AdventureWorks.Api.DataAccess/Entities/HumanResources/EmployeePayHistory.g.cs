using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("EmployeePayHistory", Schema="HumanResources")]
	public partial class EmployeePayHistory : AbstractEntity
	{
		public EmployeePayHistory()
		{
		}

		public virtual void SetProperties(
			int businessEntityID,
			DateTime modifiedDate,
			int payFrequency,
			decimal rate,
			DateTime rateChangeDate)
		{
			this.BusinessEntityID = businessEntityID;
			this.ModifiedDate = modifiedDate;
			this.PayFrequency = payFrequency;
			this.Rate = rate;
			this.RateChangeDate = rateChangeDate;
		}

		[Key]
		[Column("BusinessEntityID")]
		public virtual int BusinessEntityID { get; private set; }

		[Column("ModifiedDate")]
		public virtual DateTime ModifiedDate { get; private set; }

		[Column("PayFrequency")]
		public virtual int PayFrequency { get; private set; }

		[Column("Rate")]
		public virtual decimal Rate { get; private set; }

		[Key]
		[Column("RateChangeDate")]
		public virtual DateTime RateChangeDate { get; private set; }
	}
}

/*<Codenesium>
    <Hash>96c978bfbfe2cd0b614b53097ed655e2</Hash>
</Codenesium>*/