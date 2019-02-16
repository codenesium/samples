using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace NebulaNS.Api.DataAccess
{
	[Table("Team", Schema="dbo")]
	public partial class Team : AbstractEntity
	{
		public Team()
		{
		}

		public virtual void SetProperties(
			int id,
			string name,
			int organizationId)
		{
			this.Id = id;
			this.Name = name;
			this.OrganizationId = organizationId;
		}

		[Key]
		[Column("id")]
		public virtual int Id { get; private set; }

		[MaxLength(128)]
		[Column("name")]
		public virtual string Name { get; private set; }

		[Column("organizationId")]
		public virtual int OrganizationId { get; private set; }

		[ForeignKey("OrganizationId")]
		public virtual Organization OrganizationIdNavigation { get; private set; }

		public void SetOrganizationIdNavigation(Organization item)
		{
			this.OrganizationIdNavigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>8d2a78ab28a935e05dd904d30aa5c94f</Hash>
</Codenesium>*/