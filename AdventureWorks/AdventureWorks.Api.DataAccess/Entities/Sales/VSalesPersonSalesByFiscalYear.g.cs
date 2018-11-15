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
		public virtual decimal? @A2002 { get; private set; }

		[Column("2003")]
		public virtual decimal? @A2003 { get; private set; }

		[Column("2004")]
		public virtual decimal? @A2004 { get; private set; }

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
    <Hash>62aecaab47bc3ae5052796d570acdcb0</Hash>
</Codenesium>*/