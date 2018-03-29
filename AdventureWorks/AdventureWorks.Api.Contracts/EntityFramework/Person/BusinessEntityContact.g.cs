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
		public int BusinessEntityID {get; set;}
		public int PersonID {get; set;}
		public int ContactTypeID {get; set;}
		public Guid rowguid {get; set;}
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
    <Hash>128987cde2e1e60d64465c5e917957f8</Hash>
</Codenesium>*/