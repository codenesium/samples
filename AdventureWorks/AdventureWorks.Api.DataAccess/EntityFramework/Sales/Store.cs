using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("Store", Schema="Sales")]
	public partial class Store:AbstractEntityFrameworkDTO
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
		public int BusinessEntityID { get; set; }

		[Column("Demographics", TypeName="xml(-1)")]
		public string Demographics { get; set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; set; }

		[Column("Name", TypeName="nvarchar(50)")]
		public string Name { get; set; }

		[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
		[Column("rowguid", TypeName="uniqueidentifier")]
		public Guid Rowguid { get; set; }

		[Column("SalesPersonID", TypeName="int")]
		public Nullable<int> SalesPersonID { get; set; }

		[ForeignKey("SalesPersonID")]
		public virtual SalesPerson SalesPerson { get; set; }
	}
}

/*<Codenesium>
    <Hash>548b7e709fa2e7502a2b58889679d104</Hash>
</Codenesium>*/