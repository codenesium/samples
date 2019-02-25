using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("BusinessEntityContact", Schema="Person")]
	public partial class BusinessEntityContact : AbstractEntity
	{
		public BusinessEntityContact()
		{
		}

		public virtual void SetProperties(
			int businessEntityID,
			int contactTypeID,
			DateTime modifiedDate,
			int personID,
			Guid rowguid)
		{
			this.BusinessEntityID = businessEntityID;
			this.ContactTypeID = contactTypeID;
			this.ModifiedDate = modifiedDate;
			this.PersonID = personID;
			this.Rowguid = rowguid;
		}

		[Key]
		[Column("BusinessEntityID")]
		public virtual int BusinessEntityID { get; private set; }

		[Key]
		[Column("ContactTypeID")]
		public virtual int ContactTypeID { get; private set; }

		[Column("ModifiedDate")]
		public virtual DateTime ModifiedDate { get; private set; }

		[Key]
		[Column("PersonID")]
		public virtual int PersonID { get; private set; }

		[Column("rowguid")]
		public virtual Guid Rowguid { get; private set; }

		[ForeignKey("BusinessEntityID")]
		public virtual BusinessEntity BusinessEntityIDNavigation { get; private set; }

		public void SetBusinessEntityIDNavigation(BusinessEntity item)
		{
			this.BusinessEntityIDNavigation = item;
		}

		[ForeignKey("ContactTypeID")]
		public virtual ContactType ContactTypeIDNavigation { get; private set; }

		public void SetContactTypeIDNavigation(ContactType item)
		{
			this.ContactTypeIDNavigation = item;
		}

		[ForeignKey("PersonID")]
		public virtual Person PersonIDNavigation { get; private set; }

		public void SetPersonIDNavigation(Person item)
		{
			this.PersonIDNavigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>c291ab78f5926ce33384930390d2bd47</Hash>
</Codenesium>*/