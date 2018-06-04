using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("BusinessEntityContact", Schema="Person")]
	public partial class BusinessEntityContact: AbstractEntity
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
		public int BusinessEntityID { get; private set; }

		[Column("ContactTypeID", TypeName="int")]
		public int ContactTypeID { get; private set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; private set; }

		[Column("PersonID", TypeName="int")]
		public int PersonID { get; private set; }

		[Column("rowguid", TypeName="uniqueidentifier")]
		public Guid Rowguid { get; private set; }
	}
}

/*<Codenesium>
    <Hash>c2c4ed04edfdc2c75b326d1cf724c91e</Hash>
</Codenesium>*/