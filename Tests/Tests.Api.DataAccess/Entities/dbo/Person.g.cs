using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace TestsNS.Api.DataAccess
{
	[Table("PERSON", Schema="dbo")]
	public partial class Person : AbstractEntity
	{
		public Person()
		{
		}

		public virtual void SetProperties(
			int personId,
			string personName)
		{
			this.PersonId = personId;
			this.PersonName = personName;
		}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("PERSON_ID")]
		public int PersonId { get; private set; }

		[MaxLength(50)]
		[Column("PERSON_NAME")]
		public string PersonName { get; private set; }
	}
}

/*<Codenesium>
    <Hash>8ae78805c73a115dd6ac66e4c25bb6d4</Hash>
</Codenesium>*/