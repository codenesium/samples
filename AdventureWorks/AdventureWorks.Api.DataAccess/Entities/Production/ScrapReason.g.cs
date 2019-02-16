using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("ScrapReason", Schema="Production")]
	public partial class ScrapReason : AbstractEntity
	{
		public ScrapReason()
		{
		}

		public virtual void SetProperties(
			short scrapReasonID,
			DateTime modifiedDate,
			string name)
		{
			this.ScrapReasonID = scrapReasonID;
			this.ModifiedDate = modifiedDate;
			this.Name = name;
		}

		[Column("ModifiedDate")]
		public virtual DateTime ModifiedDate { get; private set; }

		[MaxLength(50)]
		[Column("Name")]
		public virtual string Name { get; private set; }

		[Key]
		[Column("ScrapReasonID")]
		public virtual short ScrapReasonID { get; private set; }
	}
}

/*<Codenesium>
    <Hash>0ab55ca6753659a30e66d99c6fa3274c</Hash>
</Codenesium>*/