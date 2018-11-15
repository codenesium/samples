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
		public virtual int Id { get; private set; }

		[Column("Person")]
		public virtual int Person { get; private set; }

		[Column("PersonId")]
		public virtual int PersonId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>4d1f6a79c49e85874adcdad619571460</Hash>
</Codenesium>*/