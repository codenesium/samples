using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace PetShippingNS.Api.DataAccess
{
	[Table("Employee", Schema="dbo")]
	public partial class Employee : AbstractEntity
	{
		public Employee()
		{
		}

		public virtual void SetProperties(
			string firstName,
			int id,
			bool isSalesPerson,
			bool isShipper,
			string lastName)
		{
			this.FirstName = firstName;
			this.Id = id;
			this.IsSalesPerson = isSalesPerson;
			this.IsShipper = isShipper;
			this.LastName = lastName;
		}

		[MaxLength(128)]
		[Column("firstName")]
		public virtual string FirstName { get; private set; }

		[Key]
		[Column("id")]
		public virtual int Id { get; private set; }

		[Column("isSalesPerson")]
		public virtual bool IsSalesPerson { get; private set; }

		[Column("isShipper")]
		public virtual bool IsShipper { get; private set; }

		[MaxLength(128)]
		[Column("lastName")]
		public virtual string LastName { get; private set; }
	}
}

/*<Codenesium>
    <Hash>9b1ce8736886ff533ee728dc0c82a668</Hash>
</Codenesium>*/