using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AdventureWorksNS.Api.Contracts
{
	[Table("Password", Schema="Person")]
	public partial class EFPassword
	{
		public EFPassword()
		{}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("BusinessEntityID", TypeName="int")]
		public int BusinessEntityID {get; set;}
		[Column("PasswordHash", TypeName="varchar(128)")]
		public string PasswordHash {get; set;}
		[Column("PasswordSalt", TypeName="varchar(10)")]
		public string PasswordSalt {get; set;}
		[Column("rowguid", TypeName="uniqueidentifier")]
		public Guid Rowguid {get; set;}
		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate {get; set;}

		[ForeignKey("BusinessEntityID")]
		public virtual EFPerson PersonRef { get; set; }
	}
}

/*<Codenesium>
    <Hash>14c882a2b8c2c2c3211c6eb3d7d9fba0</Hash>
</Codenesium>*/