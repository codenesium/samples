using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace OctopusDeployNS.Api.DataAccess
{
	[Table("Mutex", Schema="dbo")]
	public partial class Mutex : AbstractEntity
	{
		public Mutex()
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
		[MaxLength(450)]
		[Column("Id")]
		public string Id { get; private set; }

		[Column("JSON")]
		public string JSON { get; private set; }
	}
}

/*<Codenesium>
    <Hash>cfd757e607ab9d0080993c83403f0c0f</Hash>
</Codenesium>*/