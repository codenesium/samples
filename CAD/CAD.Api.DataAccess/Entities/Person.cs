using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace CADNS.Api.DataAccess
{
	[Table("Person", Schema="dbo")]
	public partial class Person : AbstractEntity
	{
		public Person()
		{
		}

		public virtual void SetProperties(
			int id,
			string firstName,
			string lastName,
			string phone,
			string ssn)
		{
			this.Id = id;
			this.FirstName = firstName;
			this.LastName = lastName;
			this.Phone = phone;
			this.Ssn = ssn;
		}

		[MaxLength(128)]
		[Column("firstName")]
		public virtual string FirstName { get; private set; }

		[Key]
		[Column("id")]
		public virtual int Id { get; private set; }

		[MaxLength(128)]
		[Column("lastName")]
		public virtual string LastName { get; private set; }

		[MaxLength(32)]
		[Column("phone")]
		public virtual string Phone { get; private set; }

		[MaxLength(12)]
		[Column("ssn")]
		public virtual string Ssn { get; private set; }
	}
}

/*<Codenesium>
    <Hash>16fd4f78ea5cbe70c6b53165d90f33f0</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/