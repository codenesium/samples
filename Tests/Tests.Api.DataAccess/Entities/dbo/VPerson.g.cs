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
		[Column("PERSON_ID")]
		public virtual int PersonId { get; private set; }

		[MaxLength(50)]
		[Column("PERSON_NAME")]
		public virtual string PersonName { get; private set; }
	}
}

/*<Codenesium>
    <Hash>0cec6513e5219ba6b26908b92a11292f</Hash>
</Codenesium>*/