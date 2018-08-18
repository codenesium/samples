using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace OctopusDeployNS.Api.DataAccess
{
	[Table("ExtensionConfiguration", Schema="dbo")]
	public partial class ExtensionConfiguration : AbstractEntity
	{
		public ExtensionConfiguration()
		{
		}

		public virtual void SetProperties(
			string extensionAuthor,
			string id,
			string jSON,
			string name)
		{
			this.ExtensionAuthor = extensionAuthor;
			this.Id = id;
			this.JSON = jSON;
			this.Name = name;
		}

		[MaxLength(1000)]
		[Column("ExtensionAuthor")]
		public string ExtensionAuthor { get; private set; }

		[Key]
		[MaxLength(50)]
		[Column("Id")]
		public string Id { get; private set; }

		[Column("JSON")]
		public string JSON { get; private set; }

		[MaxLength(1000)]
		[Column("Name")]
		public string Name { get; private set; }
	}
}

/*<Codenesium>
    <Hash>0a4468ed29d0cf14fe5a7ee00fd137d1</Hash>
</Codenesium>*/