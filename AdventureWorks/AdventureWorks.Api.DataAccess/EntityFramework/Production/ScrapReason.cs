using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("ScrapReason", Schema="Production")]
	public partial class ScrapReason: AbstractEntityFrameworkDTO
	{
		public ScrapReason()
		{}

		public void SetProperties(
			short scrapReasonID,
			DateTime modifiedDate,
			string name)
		{
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.Name = name;
			this.ScrapReasonID = scrapReasonID;
		}

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; set; }

		[Column("Name", TypeName="nvarchar(50)")]
		public string Name { get; set; }

		[Key]
		[Column("ScrapReasonID", TypeName="smallint")]
		public short ScrapReasonID { get; set; }
	}
}

/*<Codenesium>
    <Hash>0866bc2669cf00eb1fe0d28f9acce04a</Hash>
</Codenesium>*/