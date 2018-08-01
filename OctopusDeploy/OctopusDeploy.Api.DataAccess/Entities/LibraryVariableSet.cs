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

		[Column("ContentType")]
		public string ContentType { get; private set; }

		[Key]
		[Column("Id")]
		public string Id { get; private set; }

		[Column("JSON")]
		public string JSON { get; private set; }

		[Column("Name")]
		public string Name { get; private set; }

		[Column("VariableSetId")]
		public string VariableSetId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>8654805dbafa2fa4b878a2670e8cdd1c</Hash>
</Codenesium>*/