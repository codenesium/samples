using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace OctopusDeployNS.Api.DataAccess
{
	[Table("Lifecycle", Schema="dbo")]
	public partial class Lifecycle : AbstractEntity
	{
		public Lifecycle()
		{
		}

		public virtual void SetProperties(
			byte[] dataVersion,
			string id,
			string jSON,
			string name)
		{
			this.DataVersion = dataVersion;
			this.Id = id;
			this.JSON = jSON;
			this.Name = name;
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
	}
}

/*<Codenesium>
    <Hash>27e79d356bf49d3b4f2147e2ebd97210</Hash>
</Codenesium>*/