using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AdventureWorksNS.Api.Contracts
{
	[Table("EmailAddress", Schema="Person")]
	public partial class EFEmailAddress
	{
		public EFEmailAddress()
		{}

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
    <Hash>5618b01353337aeb86092fbfb3d1e34e</Hash>
</Codenesium>*/