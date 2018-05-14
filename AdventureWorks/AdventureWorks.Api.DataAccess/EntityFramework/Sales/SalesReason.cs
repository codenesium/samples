using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("SalesReason", Schema="Sales")]
	public partial class SalesReason: AbstractEntityFrameworkPOCO
	{
		public SalesReason()
		{}

		public void SetProperties(
			int salesReasonID,
			DateTime modifiedDate,
			string name,
			string reasonType)
		{
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.Name = name.ToString();
			this.ReasonType = reasonType.ToString();
			this.SalesReasonID = salesReasonID.ToInt();
		}

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; set; }

		[Column("Name", TypeName="nvarchar(50)")]
		public string Name { get; set; }

		[Column("ReasonType", TypeName="nvarchar(50)")]
		public string ReasonType { get; set; }

		[Key]
		[Column("SalesReasonID", TypeName="int")]
		public int SalesReasonID { get; set; }
	}
}

/*<Codenesium>
    <Hash>ecb539ea4429121dc7eeb712a97f8ce1</Hash>
</Codenesium>*/