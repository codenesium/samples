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
    <Hash>e053024c44a549360056c1e6076b5268</Hash>
</Codenesium>*/