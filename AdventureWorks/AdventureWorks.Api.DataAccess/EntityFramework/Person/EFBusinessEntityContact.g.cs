using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("BusinessEntityContact", Schema="Person")]
	public partial class EFBusinessEntityContact
	{
		public EFBusinessEntityContact()
		{}

		public void SetProperties(
			int businessEntityID,
			int personID,
			int contactTypeID,
			Guid rowguid,
			DateTime modifiedDate)
		{
			this.BusinessEntityID = businessEntityID.ToInt();
			this.PersonID = personID.ToInt();
			this.ContactTypeID = contactTypeID.ToInt();
			this.Rowguid = rowguid.ToGuid();
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		[Key]
		[Column("BusinessEntityID", TypeName="int")]
		public int BusinessEntityID { get; set; }

		[Column("PersonID", TypeName="int")]
		public int PersonID { get; set; }

		[Column("ContactTypeID", TypeName="int")]
		public int ContactTypeID { get; set; }

		[Column("rowguid", TypeName="uniqueidentifier")]
		public Guid Rowguid { get; set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; set; }

		[ForeignKey("BusinessEntityID")]
		public virtual EFBusinessEntity BusinessEntity { get; set; }

		[ForeignKey("PersonID")]
		public virtual EFPerson Person { get; set; }

		[ForeignKey("ContactTypeID")]
		public virtual EFContactType ContactType { get; set; }
	}
}

/*<Codenesium>
    <Hash>82d0ee567c21718936f454ad000ec6a9</Hash>
</Codenesium>*/