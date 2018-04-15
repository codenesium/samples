using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("ContactType", Schema="Person")]
	public partial class EFContactType
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
    <Hash>f4542635c42463283d85d74602778f1a</Hash>
</Codenesium>*/