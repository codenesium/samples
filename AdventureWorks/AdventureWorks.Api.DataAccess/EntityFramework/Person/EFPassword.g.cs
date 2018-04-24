using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("Password", Schema="Person")]
	public partial class EFPassword: AbstractEntityFrameworkPOCO
	{
		public EFPassword()
		{}

		public void SetProperties(
			int businessEntityID,
			string passwordHash,
			string passwordSalt,
			Guid rowguid,
			DateTime modifiedDate)
		{
			this.BusinessEntityID = businessEntityID.ToInt();
			this.PasswordHash = passwordHash.ToString();
			this.PasswordSalt = passwordSalt.ToString();
			this.Rowguid = rowguid.ToGuid();
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		[Key]
		[Column("BusinessEntityID", TypeName="int")]
		public int BusinessEntityID { get; set; }

		[Column("PasswordHash", TypeName="varchar(128)")]
		public string PasswordHash { get; set; }

		[Column("PasswordSalt", TypeName="varchar(10)")]
		public string PasswordSalt { get; set; }

		[Column("rowguid", TypeName="uniqueidentifier")]
		public Guid Rowguid { get; set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; set; }

		[ForeignKey("BusinessEntityID")]
		public virtual EFPerson Person { get; set; }
	}
}

/*<Codenesium>
    <Hash>d0ff03f529ff450323c310a5b543f35d</Hash>
</Codenesium>*/