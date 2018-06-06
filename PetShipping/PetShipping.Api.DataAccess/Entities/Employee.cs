using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace PetShippingNS.Api.DataAccess
{
	[Table("Employee", Schema="dbo")]
	public partial class Employee: AbstractEntity
	{
		public Employee()
		{}

		public void SetProperties(
			string firstName,
			int id,
			bool isSalesPerson,
			bool isShipper,
			string lastName)
		{
			this.FirstName = firstName;
			this.Id = id.ToInt();
			this.IsSalesPerson = isSalesPerson.ToBoolean();
			this.IsShipper = isShipper.ToBoolean();
			this.LastName = lastName;
		}

		[Column("firstName", TypeName="varchar(128)")]
		public string FirstName { get; private set; }

		[Key]
		[Column("id", TypeName="int")]
		public int Id { get; private set; }

		[Column("isSalesPerson", TypeName="bit")]
		public bool IsSalesPerson { get; private set; }

		[Column("isShipper", TypeName="bit")]
		public bool IsShipper { get; private set; }

		[Column("lastName", TypeName="varchar(128)")]
		public string LastName { get; private set; }
	}
}

/*<Codenesium>
    <Hash>36368d673ffef58c722000c2dae8a1cd</Hash>
</Codenesium>*/