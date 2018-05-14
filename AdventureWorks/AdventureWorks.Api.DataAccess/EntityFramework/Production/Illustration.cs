using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("Illustration", Schema="Production")]
	public partial class Illustration: AbstractEntityFrameworkPOCO
	{
		public Illustration()
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
    <Hash>96582b3debac91256733a26b64b02dd8</Hash>
</Codenesium>*/