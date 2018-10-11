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
		public int BusinessEntityID { get; private set; }

		[MaxLength(50)]
		[Column("EmailAddress")]
		public string EmailAddress1 { get; private set; }

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
		[Column("EmailAddressID")]
		public int EmailAddressID { get; private set; }

		[Column("ModifiedDate")]
		public DateTime ModifiedDate { get; private set; }

		[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
		[Column("rowguid")]
		public Guid Rowguid { get; private set; }
	}
}

/*<Codenesium>
    <Hash>db6251114df7da4fea3b22ae71d11e60</Hash>
</Codenesium>*/