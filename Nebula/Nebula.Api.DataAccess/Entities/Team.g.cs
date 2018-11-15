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
		public virtual Organization OrganizationNavigation { get; private set; }

		public void SetOrganizationNavigation(Organization item)
		{
			this.OrganizationNavigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>d064bddae0f63eb842f116a3bd697cf7</Hash>
</Codenesium>*/