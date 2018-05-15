using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace FermataFishNS.Api.DataAccess
{
	[Table("State", Schema="dbo")]
	public partial class State:AbstractEntityFrameworkPOCO
	{
		public State()
		{}

		public void SetProperties(
			int id,
			string name)
		{
			this.Id = id.ToInt();
			this.Name = name;
		}

		[Key]
		[Column("id", TypeName="int")]
		public int Id { get; set; }

		[Column("name", TypeName="varchar(2)")]
		public string Name { get; set; }
	}
}

/*<Codenesium>
    <Hash>2855ed9515bcc09bb90fee5c7e240eee</Hash>
</Codenesium>*/