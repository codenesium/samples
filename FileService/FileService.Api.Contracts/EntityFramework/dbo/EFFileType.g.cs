using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;
namespace FileServiceNS.Api.Contracts
{
	[Table("FileType", Schema="dbo")]
	public partial class EFFileType
	{
		public EFFileType()
		{}

		public void SetProperties(int id,
		                          string name)
		{
			this.Id = id.ToInt();
			this.Name = name;
		}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("id", TypeName="int")]
		public int Id {get; set;}

		[Column("name", TypeName="varchar(255)")]
		public string Name {get; set;}
	}
}

/*<Codenesium>
    <Hash>16ecb5ca4141fc27ec7d77f366845562</Hash>
</Codenesium>*/