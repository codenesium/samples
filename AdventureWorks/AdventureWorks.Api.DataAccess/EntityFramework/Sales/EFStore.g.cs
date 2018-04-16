using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("Store", Schema="Sales")]
	public partial class EFStore
	{
		public EFStore()
		{}

		public void SetProperties(
			int businessEntityID,
			string name,
			Nullable<int> salesPersonID,
			string demographics,
			Guid rowguid,
			DateTime modifiedDate)
		{
			this.BusinessEntityID = businessEntityID.ToInt();
			this.Name = name.ToString();
			this.SalesPersonID = salesPersonID.ToNullableInt();
			this.Demographics = demographics;
			this.Rowguid = rowguid.ToGuid();
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		[Key]
		[Column("BusinessEntityID", TypeName="int")]
		public int BusinessEntityID { get; set; }

		[Column("Name", TypeName="nvarchar(50)")]
		public string Name { get; set; }

		[Column("SalesPersonID", TypeName="int")]
		public Nullable<int> SalesPersonID { get; set; }

		[Column("Demographics", TypeName="xml(-1)")]
		public string Demographics { get; set; }

		[Column("rowguid", TypeName="uniqueidentifier")]
		public Guid Rowguid { get; set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; set; }

		[ForeignKey("BusinessEntityID")]
		public virtual EFBusinessEntity BusinessEntity { get; set; }

		[ForeignKey("SalesPersonID")]
		public virtual EFSalesPerson SalesPerson { get; set; }
	}
}

/*<Codenesium>
    <Hash>45d9b020d61af3343660bbb9ab382e01</Hash>
</Codenesium>*/