using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace OctopusDeployNS.Api.DataAccess
{
	[Table("DeploymentEnvironment", Schema="dbo")]
	public partial class DeploymentEnvironment : AbstractEntity
	{
		public DeploymentEnvironment()
		{
		}

		public virtual void SetProperties(
			byte[] dataVersion,
			string id,
			string jSON,
			string name,
			int sortOrder)
		{
			this.DataVersion = dataVersion;
			this.Id = id;
			this.JSON = jSON;
			this.Name = name;
			this.SortOrder = sortOrder;
		}

		[Column("DataVersion")]
		public byte[] DataVersion { get; private set; }

		[Key]
		[MaxLength(50)]
		[Column("Id")]
		public string Id { get; private set; }

		[Column("JSON")]
		public string JSON { get; private set; }

		[MaxLength(200)]
		[Column("Name")]
		public string Name { get; private set; }

		[Column("SortOrder")]
		public int SortOrder { get; private set; }
	}
}

/*<Codenesium>
    <Hash>8d8dc14950cf081d94ee784c03ff2270</Hash>
</Codenesium>*/