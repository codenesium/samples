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

		[ForeignKey("Person")]
		public virtual Person PersonNavigation { get; private set; }

		public void SetPersonNavigation(Person item)
		{
			this.PersonNavigation = item;
		}

		[ForeignKey("PersonId")]
		public virtual Person Person1Navigation { get; private set; }

		public void SetPerson1Navigation(Person item)
		{
			this.Person1Navigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>9f0a1e6deae7fd140a7f80ed22ee6c33</Hash>
</Codenesium>*/