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
			int id,
			string firstName,
			bool isSalesPerson,
			bool isShipper,
			string lastName)
		{
			this.Id = id;
			this.FirstName = firstName;
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
    <Hash>d1366cf7d4d20c50e402c93371cb8ed0</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/