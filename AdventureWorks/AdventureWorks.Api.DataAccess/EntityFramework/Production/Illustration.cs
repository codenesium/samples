using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("Illustration", Schema="Production")]
	public partial class Illustration: AbstractEntityFrameworkDTO
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
    <Hash>795b7126027f8e027c954e55f844d01f</Hash>
</Codenesium>*/