using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("PhoneNumberType", Schema="Person")]
	public partial class PhoneNumberType: AbstractEntityFrameworkPOCO
	{
		public PhoneNumberType()
		{}

		public void SetProperties(
			int phoneNumberTypeID,
			DateTime modifiedDate,
			string name)
		{
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.Name = name.ToString();
			this.PhoneNumberTypeID = phoneNumberTypeID.ToInt();
		}

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; set; }

		[Column("Name", TypeName="nvarchar(50)")]
		public string Name { get; set; }

		[Key]
		[Column("PhoneNumberTypeID", TypeName="int")]
		public int PhoneNumberTypeID { get; set; }
	}
}

/*<Codenesium>
    <Hash>d95b556fc3f3170df7aafae42e7a65fd</Hash>
</Codenesium>*/