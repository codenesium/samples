using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("ContactType", Schema="Person")]
	public partial class ContactType: AbstractEntityFrameworkDTO
	{
		public ContactType()
		{}

		public void SetProperties(
			int contactTypeID,
			DateTime modifiedDate,
			string name)
		{
			this.ContactTypeID = contactTypeID.ToInt();
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.Name = name;
		}

		[Key]
		[Column("ContactTypeID", TypeName="int")]
		public int ContactTypeID { get; set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; set; }

		[Column("Name", TypeName="nvarchar(50)")]
		public string Name { get; set; }
	}
}

/*<Codenesium>
    <Hash>600c988ef0b7011cdf26f846f92abe07</Hash>
</Codenesium>*/