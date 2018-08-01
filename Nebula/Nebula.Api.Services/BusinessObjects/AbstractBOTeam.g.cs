using Codenesium.DataConversionExtensions;
using System;

namespace NebulaNS.Api.Services
{
	public abstract class AbstractBOTeam : AbstractBusinessObject
	{
		public AbstractBOTeam()
			: base()
		{
		}

		public virtual void SetProperties(int id,
		                                  string name,
		                                  int organizationId)
		{
			this.Id = id;
			this.Name = name;
			this.OrganizationId = organizationId;
		}

		public int Id { get; private set; }

		public string Name { get; private set; }

		public int OrganizationId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>535c52bea80205cf88a2870311745633</Hash>
</Codenesium>*/