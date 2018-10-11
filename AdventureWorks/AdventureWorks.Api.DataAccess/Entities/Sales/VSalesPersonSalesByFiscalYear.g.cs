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
			decimal? @_2002,
			decimal? @_2003,
			decimal? @_2004,
			string fullName,
			string jobTitle,
			int? salesPersonID,
			string salesTerritory)
		{
			this.@_2002 = @_2002;
			this.@_2003 = @_2003;
			this.@_2004 = @_2004;
			this.FullName = fullName;
			this.JobTitle = jobTitle;
			this.SalesPersonID = salesPersonID;
			this.SalesTerritory = salesTerritory;
		}

		[Column("2002")]
		public decimal? @_2002 { get; private set; }

		[Column("2003")]
		public decimal? @_2003 { get; private set; }

		[Column("2004")]
		public decimal? @_2004 { get; private set; }

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
    <Hash>8ceff0dc92c93886a8e5affd77611f26</Hash>
</Codenesium>*/