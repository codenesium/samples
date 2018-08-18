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
    <Hash>6dfea7063f5b4d77e00bbb3d701f2d45</Hash>
</Codenesium>*/