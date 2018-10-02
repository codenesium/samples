using Codenesium.DataConversionExtensions;
using System;

namespace NebulaNS.Api.Services
{
	public abstract class AbstractBOSysdiagram : AbstractBusinessObject
	{
		public AbstractBOSysdiagram()
			: base()
		{
		}

		public virtual void SetProperties(int diagramId,
		                                  byte[] definition,
		                                  string name,
		                                  int principalId,
		                                  int? version)
		{
			this.Definition = definition;
			this.DiagramId = diagramId;
			this.Name = name;
			this.PrincipalId = principalId;
			this.Version = version;
		}

		public byte[] Definition { get; private set; }

		public int DiagramId { get; private set; }

		public string Name { get; private set; }

		public int PrincipalId { get; private set; }

		public int? Version { get; private set; }
	}
}

/*<Codenesium>
    <Hash>94eedac9ced89358d8eeb9444688ecf0</Hash>
</Codenesium>*/