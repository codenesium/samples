using Codenesium.DataConversionExtensions;
using System;

namespace OctopusDeployNS.Api.Services
{
	public abstract class AbstractBOSchemaVersions : AbstractBusinessObject
	{
		public AbstractBOSchemaVersions()
			: base()
		{
		}

		public virtual void SetProperties(int id,
		                                  DateTime applied,
		                                  string scriptName)
		{
			this.Applied = applied;
			this.Id = id;
			this.ScriptName = scriptName;
		}

		public DateTime Applied { get; private set; }

		public int Id { get; private set; }

		public string ScriptName { get; private set; }
	}
}

/*<Codenesium>
    <Hash>cc75c06e18e26a1e6afde79c86e68dc9</Hash>
</Codenesium>*/