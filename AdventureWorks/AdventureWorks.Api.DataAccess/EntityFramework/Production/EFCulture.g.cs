using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("Culture", Schema="Production")]
	public partial class EFCulture: AbstractEntityFrameworkPOCO
	{
		public EFCulture()
		{}

		public void SetProperties(
			string cultureID,
			string name,
			DateTime modifiedDate)
		{
			this.CultureID = cultureID.ToString();
			this.Name = name.ToString();
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		[Key]
		[Column("CultureID", TypeName="nchar(6)")]
		public string CultureID { get; set; }

		[Column("Name", TypeName="nvarchar(50)")]
		public string Name { get; set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; set; }
	}
}

/*<Codenesium>
    <Hash>81afaf42c4c99a4135f55b81c38e9d86</Hash>
</Codenesium>*/