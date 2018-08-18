using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace OctopusDeployNS.Api.DataAccess
{
	[Table("Configuration", Schema="dbo")]
	public partial class Configuration : AbstractEntity
	{
		public Configuration()
		{
		}

		public virtual void SetProperties(
			string id,
			string jSON)
		{
			this.Id = id;
			this.JSON = jSON;
		}

		[Key]
		[MaxLength(50)]
		[Column("Id")]
		public string Id { get; private set; }

		[Column("JSON")]
		public string JSON { get; private set; }
	}
}

/*<Codenesium>
    <Hash>3b46f0f115a6af8ab4c5ce03dc950c11</Hash>
</Codenesium>*/