using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("Store", Schema="Sales")]
	public partial class Store : AbstractEntity
	{
		public Store()
		{
		}

		public virtual void SetProperties(
			int businessEntityID,
			string demographic,
			DateTime modifiedDate,
			string name,
			Guid rowguid,
			int? salesPersonID)
		{
			this.BusinessEntityID = businessEntityID;
			this.Demographic = demographic;
			this.ModifiedDate = modifiedDate;
			this.Name = name;
			this.Rowguid = rowguid;
			this.SalesPersonID = salesPersonID;
		}

		[Key]
		[Column("BusinessEntityID")]
		public virtual int BusinessEntityID { get; private set; }

		[Column("Demographics")]
		public virtual string Demographic { get; private set; }

		[Column("ModifiedDate")]
		public virtual DateTime ModifiedDate { get; private set; }

		[MaxLength(50)]
		[Column("Name")]
		public virtual string Name { get; private set; }

		[Column("rowguid")]
		public virtual Guid Rowguid { get; private set; }

		[Column("SalesPersonID")]
		public virtual int? SalesPersonID { get; private set; }

		[ForeignKey("SalesPersonID")]
		public virtual SalesPerson SalesPersonNavigation { get; private set; }

		public void SetSalesPersonNavigation(SalesPerson item)
		{
			this.SalesPersonNavigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>cc1dfed132fe1ce46f95c419c01e410d</Hash>
</Codenesium>*/