using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("EmailAddress", Schema="Person")]
	public partial class EFEmailAddress: AbstractEntityFrameworkPOCO
	{
		public EFEmailAddress()
		{}

		public void SetProperties(
			int businessEntityID,
			string emailAddress1,
			int emailAddressID,
			DateTime modifiedDate,
			Guid rowguid)
		{
			this.BusinessEntityID = businessEntityID.ToInt();
			this.EmailAddress1 = emailAddress1.ToString();
			this.EmailAddressID = emailAddressID.ToInt();
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.Rowguid = rowguid.ToGuid();
		}

		[Key]
		[Column("BusinessEntityID", TypeName="int")]
		public int BusinessEntityID { get; set; }

		[Column("EmailAddress", TypeName="nvarchar(50)")]
		public string EmailAddress1 { get; set; }

		[Column("EmailAddressID", TypeName="int")]
		public int EmailAddressID { get; set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; set; }

		[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
		[Column("rowguid", TypeName="uniqueidentifier")]
		public Guid Rowguid { get; set; }

		[ForeignKey("BusinessEntityID")]
		public virtual EFPerson Person { get; set; }
	}
}

/*<Codenesium>
    <Hash>a7be6d114ca9ee9df5b31e6ca904ab3e</Hash>
</Codenesium>*/