using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace FileServiceNS.Api.DataAccess
{
	[Table("FileType", Schema="dbo")]
	public partial class FileType: AbstractEntityFrameworkPOCO
	{
		public FileType()
		{}

		public void SetProperties(
			int id,
			string name)
		{
			this.Id = id.ToInt();
			this.Name = name;
		}

		[Key]
		[Column("id", TypeName="int")]
		public int Id { get; set; }

		[Column("name", TypeName="varchar(255)")]
		public string Name { get; set; }
	}
}

/*<Codenesium>
    <Hash>c6294970f1f86ad35dd0cbeb639fb41b</Hash>
</Codenesium>*/