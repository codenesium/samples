using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;
namespace NebulaNS.Api.Contracts
{
	[Table("Organization", Schema="dbo")]
	public partial class EFOrganization
	{
		public EFOrganization()
		{}

		public void SetProperties(int id,
		                          string name)
		{
			this.Id = id.ToInt();
			this.Name = name;
		}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("id", TypeName="int")]
		public int Id {get; set;}

		[Column("name", TypeName="varchar(128)")]
		public string Name {get; set;}
	}
}

/*<Codenesium>
    <Hash>7081401e05846a94871193f710a6ce52</Hash>
</Codenesium>*/