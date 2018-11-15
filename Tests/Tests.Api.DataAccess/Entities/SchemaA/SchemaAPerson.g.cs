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
		[Column("id")]
		public virtual int Id { get; private set; }

		[MaxLength(50)]
		[Column("name")]
		public virtual string Name { get; private set; }
	}
}

/*<Codenesium>
    <Hash>11619b33d5de98a24a73ebf7ca3f36e0</Hash>
</Codenesium>*/