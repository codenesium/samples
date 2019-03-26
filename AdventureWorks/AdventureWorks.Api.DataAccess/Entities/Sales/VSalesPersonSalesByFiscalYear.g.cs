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
			decimal? reserved2002,
			decimal? reserved2003,
			decimal? reserved2004,
			int? salesPersonID,
			string salesTerritory)
		{
			this.FullName = fullName;
			this.JobTitle = jobTitle;
			this.Reserved2002 = reserved2002;
			this.Reserved2003 = reserved2003;
			this.Reserved2004 = reserved2004;
			this.SalesPersonID = salesPersonID;
			this.SalesTerritory = salesTerritory;
		}

		[Column("2002")]
		public virtual decimal? Reserved2002 { get; private set; }

		[Column("2003")]
		public virtual decimal? Reserved2003 { get; private set; }

		[Column("2004")]
		public virtual decimal? Reserved2004 { get; private set; }

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
    <Hash>df10d665beeef31d80aa88dc22d70716</Hash>
</Codenesium>*/