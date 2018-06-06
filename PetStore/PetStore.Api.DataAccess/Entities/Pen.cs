using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace PetStoreNS.Api.DataAccess
{
	[Table("Pen", Schema="dbo")]
	public partial class Pen:AbstractEntity
	{
		public Pen()
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
		public int Id { get; private set; }

		[Column("name", TypeName="varchar(128)")]
		public string Name { get; private set; }
	}
}

/*<Codenesium>
    <Hash>22a571a096ad80024af7362f72275184</Hash>
</Codenesium>*/