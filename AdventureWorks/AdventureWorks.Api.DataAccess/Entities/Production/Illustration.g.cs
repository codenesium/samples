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
		public virtual string Diagram { get; private set; }

		[Key]
		[Column("IllustrationID")]
		public virtual int IllustrationID { get; private set; }

		[Column("ModifiedDate")]
		public virtual DateTime ModifiedDate { get; private set; }
	}
}

/*<Codenesium>
    <Hash>5f725e1086434c6cc207303fef819059</Hash>
</Codenesium>*/