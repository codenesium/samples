using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("BusinessEntity", Schema="Person")]
	public partial class BusinessEntity: AbstractEntity
	{
		public BusinessEntity()
		{}

		public void SetProperties(
			int businessEntityID,
			DateTime modifiedDate,
			Guid rowguid)
		{
			this.BusinessEntityID = businessEntityID.ToInt();
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.Rowguid = rowguid.ToGuid();
		}

		[Key]
		[Column("BusinessEntityID", TypeName="int")]
		public int BusinessEntityID { get; private set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; private set; }

		[Column("rowguid", TypeName="uniqueidentifier")]
		public Guid Rowguid { get; private set; }
	}
}

/*<Codenesium>
    <Hash>fe94c61147b1fed1b0eee4dd403d762f</Hash>
</Codenesium>*/