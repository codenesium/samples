using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace TestsNS.Api.DataAccess
{
	[Table("Person", Schema="SchemaB")]
	public partial class SchemaBPerson : AbstractEntity
	{
		public SchemaBPerson()
		{
		}

		public virtual void SetProperties(
			int id,
			string name)
		{
			this.Id = id;
			this.Name = name;
		}

		[Key]
		[Column("id")]
		public int Id { get; private set; }

		[MaxLength(50)]
		[Column("name")]
		public string Name { get; private set; }
	}
}

/*<Codenesium>
    <Hash>d4956033a7b3050c5009c3661088920d</Hash>
</Codenesium>*/