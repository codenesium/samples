using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AdventureWorksNS.Api.Contracts
{
	[Table("BusinessEntityContact", Schema="Person")]
	public partial class EFBusinessEntityContact
	{
		public EFBusinessEntityContact()
		{}

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

		[ForeignKey("BusinessEntityID")]
		public virtual EFBusinessEntity BusinessEntityRef { get; set; }
		[ForeignKey("PersonID")]
		public virtual EFPerson PersonRef { get; set; }
		[ForeignKey("ContactTypeID")]
		public virtual EFContactType ContactTypeRef { get; set; }
	}
}

/*<Codenesium>
    <Hash>577d73b9df5b2995eeacf5cfd9289138</Hash>
</Codenesium>*/