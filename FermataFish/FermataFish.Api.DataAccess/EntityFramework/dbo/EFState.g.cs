using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace FermataFishNS.Api.DataAccess
{
	[Table("State", Schema="dbo")]
	public partial class EFState: AbstractEntityFrameworkPOCO
	{
		public EFState()
		{}

		public void SetProperties(
			int id,
			string name)
		{
			this.Id = id.ToInt();
			this.Name = name.ToString();
		}

		[Key]
		[Column("id", TypeName="int")]
		public int Id { get; set; }

		[Column("name", TypeName="varchar(2)")]
		public string Name { get; set; }
	}
}

/*<Codenesium>
    <Hash>d0f9a176da77a1da2c4f4e5b6e3dfccd</Hash>
</Codenesium>*/