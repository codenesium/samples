using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("Culture", Schema="Production")]
	public partial class Culture: AbstractEntityFrameworkPOCO
	{
		public Culture()
		{}

		public void SetProperties(
			string cultureID,
			DateTime modifiedDate,
			string name)
		{
			this.CultureID = cultureID.ToString();
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.Name = name.ToString();
		}

		[Key]
		[Column("CultureID", TypeName="nchar(6)")]
		public string CultureID { get; set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; set; }

		[Column("Name", TypeName="nvarchar(50)")]
		public string Name { get; set; }
	}
}

/*<Codenesium>
    <Hash>239f2a273dd0d313d66587e8839b5a4f</Hash>
</Codenesium>*/