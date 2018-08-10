using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace OctopusDeployNS.Api.DataAccess
{
	[Table("SchemaVersions", Schema="dbo")]
	public partial class SchemaVersions : AbstractEntity
	{
		public SchemaVersions()
		{
		}

		public virtual void SetProperties(
			DateTime applied,
			int id,
			string scriptName)
		{
			this.Applied = applied;
			this.Id = id;
			this.ScriptName = scriptName;
		}

		[Column("Applied")]
		public DateTime Applied { get; private set; }

		[Key]
		[Column("Id")]
		public int Id { get; private set; }

		[Column("ScriptName")]
		public string ScriptName { get; private set; }
	}
}

/*<Codenesium>
    <Hash>ec359a3d1bbd54397cdfdab13b504a6d</Hash>
</Codenesium>*/