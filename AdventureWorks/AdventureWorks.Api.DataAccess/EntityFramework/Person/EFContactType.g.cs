using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("ContactType", Schema="Person")]
	public partial class EFContactType: AbstractEntityFrameworkPOCO
	{
		public EFContactType()
		{}

		public void SetProperties(
			int contactTypeID,
			string name,
			DateTime modifiedDate)
		{
			this.ContactTypeID = contactTypeID.ToInt();
			this.Name = name.ToString();
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("ContactTypeID", TypeName="int")]
		public int ContactTypeID { get; set; }

		[Column("Name", TypeName="nvarchar(50)")]
		public string Name { get; set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; set; }
	}
}

/*<Codenesium>
    <Hash>2b5c47f0abb1a34aa16f6f09d91c3482</Hash>
</Codenesium>*/