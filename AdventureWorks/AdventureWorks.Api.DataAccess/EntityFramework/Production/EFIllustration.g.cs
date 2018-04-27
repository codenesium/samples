using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("Illustration", Schema="Production")]
	public partial class EFIllustration: AbstractEntityFrameworkPOCO
	{
		public EFIllustration()
		{}

		public void SetProperties(
			int illustrationID,
			string diagram,
			DateTime modifiedDate)
		{
			this.Diagram = diagram;
			this.IllustrationID = illustrationID.ToInt();
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		[Column("Diagram", TypeName="xml(-1)")]
		public string Diagram { get; set; }

		[Key]
		[Column("IllustrationID", TypeName="int")]
		public int IllustrationID { get; set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; set; }
	}
}

/*<Codenesium>
    <Hash>0eeb391bfa0f13bfecb59f4cf405732c</Hash>
</Codenesium>*/