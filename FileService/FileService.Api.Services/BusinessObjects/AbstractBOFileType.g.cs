using Codenesium.DataConversionExtensions;
using System;

namespace FileServiceNS.Api.Services
{
	public abstract class AbstractBOFileType : AbstractBusinessObject
	{
		public AbstractBOFileType()
			: base()
		{
		}

		public virtual void SetProperties(int id,
		                                  string name)
		{
			this.Id = id;
			this.Name = name;
		}

		public int Id { get; private set; }

		public string Name { get; private set; }
	}
}

/*<Codenesium>
    <Hash>94e9b7cce126f30e862e1a90cf33c0be</Hash>
</Codenesium>*/