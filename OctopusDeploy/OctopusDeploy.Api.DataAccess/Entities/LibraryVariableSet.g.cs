using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace OctopusDeployNS.Api.DataAccess
{
	[Table("LibraryVariableSet", Schema="dbo")]
	public partial class LibraryVariableSet : AbstractEntity
	{
		public LibraryVariableSet()
		{
		}

		public virtual void SetProperties(
			string contentType,
			string id,
			string jSON,
			string name,
			string variableSetId)
		{
			this.ContentType = contentType;
			this.Id = id;
			this.JSON = jSON;
			this.Name = name;
			this.VariableSetId = variableSetId;
		}

		[MaxLength(50)]
		[Column("ContentType")]
		public string ContentType { get; private set; }

		[Key]
		[MaxLength(50)]
		[Column("Id")]
		public string Id { get; private set; }

		[Column("JSON")]
		public string JSON { get; private set; }

		[MaxLength(200)]
		[Column("Name")]
		public string Name { get; private set; }

		[MaxLength(150)]
		[Column("VariableSetId")]
		public string VariableSetId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>d7a38c620519ac58c3841976f55434e9</Hash>
</Codenesium>*/