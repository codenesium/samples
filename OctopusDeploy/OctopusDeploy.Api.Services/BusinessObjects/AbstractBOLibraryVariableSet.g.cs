using Codenesium.DataConversionExtensions;
using System;

namespace OctopusDeployNS.Api.Services
{
	public abstract class AbstractBOLibraryVariableSet : AbstractBusinessObject
	{
		public AbstractBOLibraryVariableSet()
			: base()
		{
		}

		public virtual void SetProperties(string id,
		                                  string contentType,
		                                  string jSON,
		                                  string name,
		                                  string variableSetId)
		{
			this.ContentType = contentType;
			this.Id = id;
			this.JSON = jSON;
			this.Name = name;
			this.VariableSetId = variableSetId;
		}

		public string ContentType { get; private set; }

		public string Id { get; private set; }

		public string JSON { get; private set; }

		public string Name { get; private set; }

		public string VariableSetId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>5c8c82f438e7183a0cab37793efb370e</Hash>
</Codenesium>*/