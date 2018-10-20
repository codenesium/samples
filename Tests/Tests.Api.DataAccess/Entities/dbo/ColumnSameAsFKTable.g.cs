using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace TestsNS.Api.DataAccess
{
	[Table("ColumnSameAsFKTable", Schema="dbo")]
	public partial class ColumnSameAsFKTable : AbstractEntity
	{
		public ColumnSameAsFKTable()
		{
		}

		public virtual void SetProperties(
			int id,
			int person,
			int personId)
		{
			this.Id = id;
			this.Person = person;
			this.PersonId = personId;
		}

		[Key]
		[Column("id")]
		public int Id { get; private set; }

		[Column("Person")]
		public int Person { get; private set; }

		[Column("PersonId")]
		public int PersonId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>3fbfb5d34db506cd8ffb030cfee0a6e6</Hash>
</Codenesium>*/