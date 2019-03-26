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
			int illustrationID,
			string diagram,
			DateTime modifiedDate)
		{
			this.IllustrationID = illustrationID;
			this.Diagram = diagram;
			this.ModifiedDate = modifiedDate;
		}

		[Column("Diagram")]
		public virtual string Diagram { get; private set; }

		[Key]
		[Column("IllustrationID")]
		public virtual int IllustrationID { get; private set; }

		[Column("ModifiedDate")]
		public virtual DateTime ModifiedDate { get; private set; }
	}
}

/*<Codenesium>
    <Hash>a7819a2064a4a7ad95f6b76a4e69434a</Hash>
</Codenesium>*/