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
		public virtual int Id { get; private set; }

		[MaxLength(50)]
		[Column("name")]
		public virtual string Name { get; private set; }
	}
}

/*<Codenesium>
    <Hash>ae5c24e1456f972f6ec8c932cd63e854</Hash>
</Codenesium>*/