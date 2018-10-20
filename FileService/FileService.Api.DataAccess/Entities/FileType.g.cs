using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace FileServiceNS.Api.DataAccess
{
	[Table("FileType", Schema="dbo")]
	public partial class FileType : AbstractEntity
	{
		public FileType()
		{
		}

		public virtual void SetProperties(
			int id,
			string name)
		{
			this.Id = id;
			this.Name = name;
		}

		[Key]
		[Column("id")]
		public int Id { get; private set; }

		[MaxLength(255)]
		[Column("name")]
		public string Name { get; private set; }
	}
}

/*<Codenesium>
    <Hash>fa1bef6cdc0b5673acd097ec5cef1920</Hash>
</Codenesium>*/