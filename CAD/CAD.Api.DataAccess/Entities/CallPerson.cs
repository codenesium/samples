using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace CADNS.Api.DataAccess
{
	[Table("CallPerson", Schema="dbo")]
	public partial class CallPerson : AbstractEntity
	{
		public CallPerson()
		{
		}

		public virtual void SetProperties(
			int id,
			string note,
			int personId,
			int personTypeId)
		{
			this.Id = id;
			this.Note = note;
			this.PersonId = personId;
			this.PersonTypeId = personTypeId;
		}

		[Key]
		[Column("id")]
		public virtual int Id { get; private set; }

		[MaxLength(8000)]
		[Column("note")]
		public virtual string Note { get; private set; }

		[Column("personId")]
		public virtual int PersonId { get; private set; }

		[Column("personTypeId")]
		public virtual int PersonTypeId { get; private set; }

		[ForeignKey("PersonId")]
		public virtual Person PersonIdNavigation { get; private set; }

		public void SetPersonIdNavigation(Person item)
		{
			this.PersonIdNavigation = item;
		}

		[ForeignKey("PersonTypeId")]
		public virtual PersonType PersonTypeIdNavigation { get; private set; }

		public void SetPersonTypeIdNavigation(PersonType item)
		{
			this.PersonTypeIdNavigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>f71bd4e831836a3190eae6ac0a2c93c5</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/