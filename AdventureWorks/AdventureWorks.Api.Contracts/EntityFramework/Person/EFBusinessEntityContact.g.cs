using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;
namespace AdventureWorksNS.Api.Contracts
{
	[Table("BusinessEntityContact", Schema="Person")]
	public partial class EFBusinessEntityContact
	{
		public EFBusinessEntityContact()
		{}

		public void SetProperties(int businessEntityID,
		                          int personID,
		                          int contactTypeID,
		                          Guid rowguid,
		                          DateTime modifiedDate)
		{
			this.BusinessEntityID = businessEntityID.ToInt();
			this.PersonID = personID.ToInt();
			this.ContactTypeID = contactTypeID.ToInt();
			this.Rowguid = rowguid;
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("BusinessEntityID", TypeName="int")]
		public int BusinessEntityID {get; set;}

		[Column("PersonID", TypeName="int")]
		public int PersonID {get; set;}

		[Column("ContactTypeID", TypeName="int")]
		public int ContactTypeID {get; set;}

		[Column("rowguid", TypeName="uniqueidentifier")]
		public Guid Rowguid {get; set;}

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate {get; set;}

		public virtual EFBusinessEntity BusinessEntity { get; set; }

		public virtual EFPerson Person { get; set; }

		public virtual EFContactType ContactType { get; set; }
	}
}

/*<Codenesium>
    <Hash>3348ba68707bdfd16777ef6d24b12854</Hash>
</Codenesium>*/