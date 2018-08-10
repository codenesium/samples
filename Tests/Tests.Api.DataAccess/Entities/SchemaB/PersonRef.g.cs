using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace TestsNS.Api.DataAccess
{
	[Table("PersonRef", Schema="SchemaB")]
	public partial class PersonRef : AbstractEntity
	{
		public PersonRef()
		{
		}

		public virtual void SetProperties(
			int id,
			int personAId,
			int personBId)
		{
			this.Id = id;
			this.PersonAId = personAId;
			this.PersonBId = personBId;
		}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("id")]
		public int Id { get; private set; }

		[Column("personAId")]
		public int PersonAId { get; private set; }

		[Column("personBId")]
		public int PersonBId { get; private set; }

		[ForeignKey("PersonBId")]
		public virtual SchemaBPerson SchemaBPersonNavigation { get; private set; }
	}
}

/*<Codenesium>
    <Hash>f20534f8701f98dd991fefe8be9136e2</Hash>
</Codenesium>*/