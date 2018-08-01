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

		[Column("ExtensionAuthor")]
		public string ExtensionAuthor { get; private set; }

		[Key]
		[Column("Id")]
		public string Id { get; private set; }

		[Column("JSON")]
		public string JSON { get; private set; }

		[Column("Name")]
		public string Name { get; private set; }
	}
}

/*<Codenesium>
    <Hash>b08ef22d2e250b3af3869efa41d7660d</Hash>
</Codenesium>*/