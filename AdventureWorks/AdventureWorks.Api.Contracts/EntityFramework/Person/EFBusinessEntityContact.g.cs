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

		public virtual EFBusinessEntity BusinessEntity { get; set; }

		public virtual EFPerson Person { get; set; }

		public virtual EFContactType ContactType { get; set; }
	}
}

/*<Codenesium>
    <Hash>4c2c2fc2108a7af70bb3b16187037a23</Hash>
</Codenesium>*/