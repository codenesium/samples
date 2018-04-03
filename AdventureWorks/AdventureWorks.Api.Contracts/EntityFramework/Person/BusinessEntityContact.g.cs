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
		public int businessEntityID {get; set;}
		public int personID {get; set;}
		public int contactTypeID {get; set;}
		public Guid rowguid {get; set;}
		public DateTime modifiedDate {get; set;}
	}
}

/*<Codenesium>
    <Hash>fb33249f66df9700f4d1b34a224499d6</Hash>
</Codenesium>*/