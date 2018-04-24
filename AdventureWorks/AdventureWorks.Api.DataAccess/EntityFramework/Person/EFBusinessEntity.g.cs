using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("BusinessEntity", Schema="Person")]
	public partial class EFBusinessEntity: AbstractEntityFrameworkPOCO
	{
		public EFBusinessEntity()
		{}

		public void SetProperties(
			int businessEntityID,
			Guid rowguid,
			DateTime modifiedDate)
		{
			this.BusinessEntityID = businessEntityID.ToInt();
			this.Rowguid = rowguid.ToGuid();
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("BusinessEntityID", TypeName="int")]
		public int BusinessEntityID { get; set; }

		[Column("rowguid", TypeName="uniqueidentifier")]
		public Guid Rowguid { get; set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; set; }
	}
}

/*<Codenesium>
    <Hash>4847bcd43a2b29e92b968bdbe8dd75b7</Hash>
</Codenesium>*/