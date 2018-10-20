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
			decimal? @a2002,
			decimal? @a2003,
			decimal? @a2004,
			string fullName,
			string jobTitle,
			int? salesPersonID,
			string salesTerritory)
		{
			this.@A2002 = @a2002;
			this.@A2003 = @a2003;
			this.@A2004 = @a2004;
			this.FullName = fullName;
			this.JobTitle = jobTitle;
			this.SalesPersonID = salesPersonID;
			this.SalesTerritory = salesTerritory;
		}

		[Column("2002")]
		public decimal? @A2002 { get; private set; }

		[Column("2003")]
		public decimal? @A2003 { get; private set; }

		[Column("2004")]
		public decimal? @A2004 { get; private set; }

		[MaxLength(152)]
		[Column("FullName")]
		public string FullName { get; private set; }

		[MaxLength(50)]
		[Column("JobTitle")]
		public string JobTitle { get; private set; }

		[Column("SalesPersonID")]
		public int? SalesPersonID { get; private set; }

		[MaxLength(50)]
		[Column("SalesTerritory")]
		public string SalesTerritory { get; private set; }
	}
}

/*<Codenesium>
    <Hash>7c0aae742c9caf5c0d9467170548abc6</Hash>
</Codenesium>*/