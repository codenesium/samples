using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;
namespace AdventureWorksNS.Api.Contracts
{
	[Table("Illustration", Schema="Production")]
	public partial class EFIllustration
	{
		public EFIllustration()
		{}

		public void SetProperties(int illustrationID,
		                          string diagram,
		                          DateTime modifiedDate)
		{
			this.IllustrationID = illustrationID.ToInt();
			this.Diagram = diagram;
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("IllustrationID", TypeName="int")]
		public int IllustrationID {get; set;}

		[Column("Diagram", TypeName="xml(-1)")]
		public string Diagram {get; set;}

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate {get; set;}
	}
}

/*<Codenesium>
    <Hash>3ca0338ee62eedfce6f2c4e47c0bc143</Hash>
</Codenesium>*/