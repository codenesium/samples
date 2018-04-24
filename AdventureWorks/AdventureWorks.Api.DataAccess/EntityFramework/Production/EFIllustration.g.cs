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
			this.IllustrationID = illustrationID.ToInt();
			this.Diagram = diagram;
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("IllustrationID", TypeName="int")]
		public int IllustrationID { get; set; }

		[Column("Diagram", TypeName="xml(-1)")]
		public string Diagram { get; set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; set; }
	}
}

/*<Codenesium>
    <Hash>d984c878b11c49515b368a31e636f8a0</Hash>
</Codenesium>*/