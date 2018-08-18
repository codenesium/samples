using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace OctopusDeployNS.Api.DataAccess
{
	[Table("Invitation", Schema="dbo")]
	public partial class Invitation : AbstractEntity
	{
		public Invitation()
		{
		}

		public virtual void SetProperties(
			string id,
			string invitationCode,
			string jSON)
		{
			this.Id = id;
			this.InvitationCode = invitationCode;
			this.JSON = jSON;
		}

		[Key]
		[MaxLength(50)]
		[Column("Id")]
		public string Id { get; private set; }

		[MaxLength(200)]
		[Column("InvitationCode")]
		public string InvitationCode { get; private set; }

		[Column("JSON")]
		public string JSON { get; private set; }
	}
}

/*<Codenesium>
    <Hash>c90800544038354110a1338a30b51d89</Hash>
</Codenesium>*/