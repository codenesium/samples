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
			DateTime modifiedDate,
			string name,
			short scrapReasonID)
		{
			this.ModifiedDate = modifiedDate;
			this.Name = name;
			this.ScrapReasonID = scrapReasonID;
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
    <Hash>bfff8507d58fefc6c737d12105725940</Hash>
</Codenesium>*/