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
		public virtual Person PersonIdNavigation { get; private set; }

		public void SetPersonIdNavigation(Person item)
		{
			this.PersonIdNavigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>8c596be0e8b5a98fad3bc1adfe3c4edb</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/