using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("Store", Schema="Sales")]
	public partial class Store:AbstractEntity
	{
		public Store()
		{}

		public void SetProperties(
			int businessEntityID,
			string demographics,
			DateTime modifiedDate,
			string name,
			Guid rowguid,
			Nullable<int> salesPersonID)
		{
			this.BusinessEntityID = businessEntityID.ToInt();
			this.Demographics = demographics;
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.Name = name;
			this.Rowguid = rowguid.ToGuid();
			this.SalesPersonID = salesPersonID.ToNullableInt();
		}

		[Key]
		[Column("BusinessEntityID", TypeName="int")]
		public int BusinessEntityID { get; private set; }

		[Column("Demographics", TypeName="xml(-1)")]
		public string Demographics { get; private set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; private set; }

		[Column("Name", TypeName="nvarchar(50)")]
		public string Name { get; private set; }

		[Column("rowguid", TypeName="uniqueidentifier")]
		public Guid Rowguid { get; private set; }

		[Column("SalesPersonID", TypeName="int")]
		public Nullable<int> SalesPersonID { get; private set; }

		[ForeignKey("SalesPersonID")]
		public virtual SalesPerson SalesPerson { get; set; }
	}
}

/*<Codenesium>
    <Hash>5d01e68ad3676b7f939c80b4fc6f6dbe</Hash>
</Codenesium>*/