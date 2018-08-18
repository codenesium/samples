using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace TestsNS.Api.DataAccess
{
	[Table("Person", Schema="SchemaA")]
	public partial class SchemaAPerson : AbstractEntity
	{
		public SchemaAPerson()
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
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("id")]
		public int Id { get; private set; }

		[MaxLength(50)]
		[Column("name")]
		public string Name { get; private set; }
	}
}

/*<Codenesium>
    <Hash>88bcffd8cfaa03b0d4a56a1c3bf4ba04</Hash>
</Codenesium>*/