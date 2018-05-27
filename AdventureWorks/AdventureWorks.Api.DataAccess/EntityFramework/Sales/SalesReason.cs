using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("SalesReason", Schema="Sales")]
	public partial class SalesReason: AbstractEntityFrameworkDTO
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
			this.Name = name;
			this.ReasonType = reasonType;
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
    <Hash>d51d08f897d4af5e87ea7ddc40a0c1f0</Hash>
</Codenesium>*/