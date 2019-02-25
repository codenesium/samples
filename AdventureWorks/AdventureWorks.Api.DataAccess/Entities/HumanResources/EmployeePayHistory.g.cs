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

		[ForeignKey("BusinessEntityID")]
		public virtual Employee BusinessEntityIDNavigation { get; private set; }

		public void SetBusinessEntityIDNavigation(Employee item)
		{
			this.BusinessEntityIDNavigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>9bec72b3ee13edbd95ccf79327729149</Hash>
</Codenesium>*/