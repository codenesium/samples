using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("Illustration", Schema="Production")]
	public partial class Illustration : AbstractEntity
	{
		public Illustration()
		{
		}

		public virtual void SetProperties(
			string diagram,
			int illustrationID,
			DateTime modifiedDate)
		{
			this.Diagram = diagram;
			this.IllustrationID = illustrationID;
			this.ModifiedDate = modifiedDate;
		}

		[Column("Diagram")]
		public string Diagram { get; private set; }

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("IllustrationID")]
		public int IllustrationID { get; private set; }

		[Column("ModifiedDate")]
		public DateTime ModifiedDate { get; private set; }
	}
}

/*<Codenesium>
    <Hash>7543d90f5df7028d3121d1896b2a1e1c</Hash>
</Codenesium>*/