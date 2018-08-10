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
		public DateTime ModifiedDate { get; private set; }

		[Column("Name")]
		public string Name { get; private set; }

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("ScrapReasonID")]
		public short ScrapReasonID { get; private set; }
	}
}

/*<Codenesium>
    <Hash>6b0390c8b43c04dc81dca05ff964c2c8</Hash>
</Codenesium>*/