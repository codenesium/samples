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
		public virtual int Id { get; private set; }

		[Column("personAId")]
		public virtual int PersonAId { get; private set; }

		[Column("personBId")]
		public virtual int PersonBId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>ed8130c5f6858615c9bc835f9f8169e6</Hash>
</Codenesium>*/