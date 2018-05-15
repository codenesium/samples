using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("ScrapReason", Schema="Production")]
	public partial class ScrapReason: AbstractEntityFrameworkPOCO
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
    <Hash>1315727d1148364d6b2128b04f37d301</Hash>
</Codenesium>*/