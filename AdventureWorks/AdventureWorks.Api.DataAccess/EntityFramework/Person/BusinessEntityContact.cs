using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("BusinessEntityContact", Schema="Person")]
	public partial class BusinessEntityContact: AbstractEntityFrameworkDTO
	{
		public BusinessEntityContact()
		{}

		public void SetProperties(
			int businessEntityID,
			int contactTypeID,
			DateTime modifiedDate,
			int personID,
			Guid rowguid)
		{
			this.BusinessEntityID = businessEntityID.ToInt();
			this.ContactTypeID = contactTypeID.ToInt();
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.PersonID = personID.ToInt();
			this.Rowguid = rowguid.ToGuid();
		}

		[Key]
		[Column("BusinessEntityID", TypeName="int")]
		public int BusinessEntityID { get; set; }

		[Column("ContactTypeID", TypeName="int")]
		public int ContactTypeID { get; set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; set; }

		[Column("PersonID", TypeName="int")]
		public int PersonID { get; set; }

		[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
		[Column("rowguid", TypeName="uniqueidentifier")]
		public Guid Rowguid { get; set; }
	}
}

/*<Codenesium>
    <Hash>955cc432d1f54668be4566a3388578de</Hash>
</Codenesium>*/