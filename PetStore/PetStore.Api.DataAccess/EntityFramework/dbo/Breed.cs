using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace PetStoreNS.Api.DataAccess
{
	[Table("Breed", Schema="dbo")]
	public partial class Breed:AbstractEntityFrameworkDTO
	{
		public Breed()
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

		[Column("name", TypeName="varchar(128)")]
		public string Name { get; set; }
	}
}

/*<Codenesium>
    <Hash>6bc82b70b79ca451b443af508882741e</Hash>
</Codenesium>*/