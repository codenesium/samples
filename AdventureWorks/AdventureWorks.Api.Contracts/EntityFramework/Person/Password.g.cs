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
		public int businessEntityID {get; set;}
		public string passwordHash {get; set;}
		public string passwordSalt {get; set;}
		public Guid rowguid {get; set;}
		public DateTime modifiedDate {get; set;}
	}
}

/*<Codenesium>
    <Hash>fdf45438a6125495e19ae0015c73cb41</Hash>
</Codenesium>*/