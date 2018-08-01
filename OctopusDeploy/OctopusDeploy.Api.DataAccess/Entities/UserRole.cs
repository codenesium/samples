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
		[Column("Id")]
		public string Id { get; private set; }

		[Column("JSON")]
		public string JSON { get; private set; }

		[Column("Name")]
		public string Name { get; private set; }
	}
}

/*<Codenesium>
    <Hash>9a7c20334f5b0c77ac648d644a82a6b9</Hash>
</Codenesium>*/