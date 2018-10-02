using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace TestsNS.Api.DataAccess
{
	[Table("vPerson", Schema="dbo")]
	public partial class VPerson : AbstractEntity
	{
		public VPerson()
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
    <Hash>c5d577834edc4f219464e982a3d902e4</Hash>
</Codenesium>*/