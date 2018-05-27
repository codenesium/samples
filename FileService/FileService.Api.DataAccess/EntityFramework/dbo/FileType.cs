using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace FileServiceNS.Api.DataAccess
{
	[Table("FileType", Schema="dbo")]
	public partial class FileType: AbstractEntityFrameworkDTO
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
    <Hash>6712a0a61b5c2e4d5c0dc8f61fe052cc</Hash>
</Codenesium>*/