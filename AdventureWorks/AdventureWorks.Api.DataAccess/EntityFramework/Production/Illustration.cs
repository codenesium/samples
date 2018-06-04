using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("Illustration", Schema="Production")]
	public partial class Illustration: AbstractEntity
	{
		public Illustration()
		{}

		public void SetProperties(
			string diagram,
			int illustrationID,
			DateTime modifiedDate)
		{
			this.Diagram = diagram;
			this.IllustrationID = illustrationID.ToInt();
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		[Column("Diagram", TypeName="xml(-1)")]
		public string Diagram { get; private set; }

		[Key]
		[Column("IllustrationID", TypeName="int")]
		public int IllustrationID { get; private set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; private set; }
	}
}

/*<Codenesium>
    <Hash>c9f3abba12744bf78eca3df5ad2b83ef</Hash>
</Codenesium>*/