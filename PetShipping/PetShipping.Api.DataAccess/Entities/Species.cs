using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace PetShippingNS.Api.DataAccess
{
	[Table("Species", Schema="dbo")]
	public partial class Species: AbstractEntity
	{
		public Species()
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
    <Hash>180531cd4b3cda6434c1e1136305eb0f</Hash>
</Codenesium>*/