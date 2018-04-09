using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;
namespace AdventureWorksNS.Api.Contracts
{
	[Table("EmailAddress", Schema="Person")]
	public partial class EFEmailAddress
	{
		public EFEmailAddress()
		{}

		public void SetProperties(int businessEntityID,
		                          int emailAddressID,
		                          string emailAddress1,
		                          Guid rowguid,
		                          DateTime modifiedDate)
		{
			this.BusinessEntityID = businessEntityID.ToInt();
			this.EmailAddressID = emailAddressID.ToInt();
			this.EmailAddress1 = emailAddress1;
			this.Rowguid = rowguid;
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("BusinessEntityID", TypeName="int")]
		public int BusinessEntityID {get; set;}

		[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
		[Column("EmailAddressID", TypeName="int")]
		public int EmailAddressID {get; set;}

		[Column("EmailAddress", TypeName="nvarchar(50)")]
		public string EmailAddress1 {get; set;}

		[Column("rowguid", TypeName="uniqueidentifier")]
		public Guid Rowguid {get; set;}

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate {get; set;}

		public virtual EFPerson Person { get; set; }
	}
}

/*<Codenesium>
    <Hash>471a9b8a7046de85b8491def84dedb04</Hash>
</Codenesium>*/