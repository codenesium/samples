using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;
namespace AdventureWorksNS.Api.Contracts
{
	[Table("Culture", Schema="Production")]
	public partial class EFCulture
	{
		public EFCulture()
		{}

		public void SetProperties(string cultureID,
		                          string name,
		                          DateTime modifiedDate)
		{
			this.CultureID = cultureID;
			this.Name = name;
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("CultureID", TypeName="nchar(6)")]
		public string CultureID {get; set;}

		[Column("Name", TypeName="nvarchar(50)")]
		public string Name {get; set;}

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate {get; set;}
	}
}

/*<Codenesium>
    <Hash>e058c70d8f45a5268003509f71dd8718</Hash>
</Codenesium>*/