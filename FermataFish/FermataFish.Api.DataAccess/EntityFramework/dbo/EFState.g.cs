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
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("id", TypeName="int")]
		public int Id { get; set; }

		[Column("name", TypeName="varchar(2)")]
		public string Name { get; set; }
	}
}

/*<Codenesium>
    <Hash>14553b9ed3767283999bb25208591e54</Hash>
</Codenesium>*/