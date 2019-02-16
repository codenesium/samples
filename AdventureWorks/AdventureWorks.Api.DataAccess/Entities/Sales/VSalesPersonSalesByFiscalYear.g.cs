using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("vSalesPersonSalesByFiscalYears", Schema="Sales")]
	public partial class VSalesPersonSalesByFiscalYear : AbstractEntity
	{
		public VSalesPersonSalesByFiscalYear()
		{
		}

		public virtual void SetProperties(
			string fullName,
			string jobTitle,
			int? salesPersonID,
			string salesTerritory)
		{
			this.FullName = fullName;
			this.JobTitle = jobTitle;
			this.SalesPersonID = salesPersonID;
			this.SalesTerritory = salesTerritory;
		}

		[MaxLength(152)]
		[Column("FullName")]
		public virtual string FullName { get; private set; }

		[MaxLength(50)]
		[Column("JobTitle")]
		public virtual string JobTitle { get; private set; }

		[Column("SalesPersonID")]
		public virtual int? SalesPersonID { get; private set; }

		[MaxLength(50)]
		[Column("SalesTerritory")]
		public virtual string SalesTerritory { get; private set; }
	}
}

/*<Codenesium>
    <Hash>c6a72f314f6eef07b332d0985c809e43</Hash>
</Codenesium>*/