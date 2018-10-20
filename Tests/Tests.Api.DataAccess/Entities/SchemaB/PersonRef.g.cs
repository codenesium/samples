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
		[Column("id")]
		public int Id { get; private set; }

		[Column("personAId")]
		public int PersonAId { get; private set; }

		[Column("personBId")]
		public int PersonBId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>dfe717d040b0394c5923029b6163e60f</Hash>
</Codenesium>*/