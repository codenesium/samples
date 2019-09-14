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
		[Column("PERSON_ID")]
		public virtual int PersonId { get; private set; }

		[MaxLength(50)]
		[Column("PERSON_NAME")]
		public virtual string PersonName { get; private set; }
	}
}

/*<Codenesium>
    <Hash>7123083a27e3bf0258dc2f92cba1190a</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/