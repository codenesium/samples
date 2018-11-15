using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("EmailAddress", Schema="Person")]
	public partial class EmailAddress : AbstractEntity
	{
		public EmailAddress()
		{
		}

		public virtual void SetProperties(
			int businessEntityID,
			string emailAddress1,
			int emailAddressID,
			DateTime modifiedDate,
			Guid rowguid)
		{
			this.BusinessEntityID = businessEntityID;
			this.EmailAddress1 = emailAddress1;
			this.EmailAddressID = emailAddressID;
			this.ModifiedDate = modifiedDate;
			this.Rowguid = rowguid;
		}

		[Key]
		[Column("BusinessEntityID")]
		public virtual int BusinessEntityID { get; private set; }

		[MaxLength(50)]
		[Column("EmailAddress")]
		public virtual string EmailAddress1 { get; private set; }

		[Key]
		[Column("EmailAddressID")]
		public virtual int EmailAddressID { get; private set; }

		[Column("ModifiedDate")]
		public virtual DateTime ModifiedDate { get; private set; }

		[Column("rowguid")]
		public virtual Guid Rowguid { get; private set; }
	}
}

/*<Codenesium>
    <Hash>f13844793ddb51550f91a11ae0fa7d8e</Hash>
</Codenesium>*/