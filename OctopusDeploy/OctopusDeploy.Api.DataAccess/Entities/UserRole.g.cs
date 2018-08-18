using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace OctopusDeployNS.Api.DataAccess
{
	[Table("UserRole", Schema="dbo")]
	public partial class UserRole : AbstractEntity
	{
		public UserRole()
		{
		}

		public virtual void SetProperties(
			string id,
			string jSON,
			string name)
		{
			this.Id = id;
			this.JSON = jSON;
			this.Name = name;
		}

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
    <Hash>398aef7a47d306d698140a0177d743ff</Hash>
</Codenesium>*/