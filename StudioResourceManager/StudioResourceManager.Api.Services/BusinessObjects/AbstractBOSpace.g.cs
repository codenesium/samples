using Codenesium.DataConversionExtensions;
using System;

namespace StudioResourceManagerNS.Api.Services
{
	public abstract class AbstractBOSpace : AbstractBusinessObject
	{
		public AbstractBOSpace()
			: base()
		{
		}

		public virtual void SetProperties(int id,
		                                  string description,
		                                  string name,
		                                  bool isDeleted)
		{
			this.Description = description;
			this.Id = id;
			this.Name = name;
			this.IsDeleted = isDeleted;
		}

		public string Description { get; private set; }

		public int Id { get; private set; }

		public string Name { get; private set; }

		public bool IsDeleted { get; private set; }
	}
}

/*<Codenesium>
    <Hash>c0c7ec3683530701840e1a8d0be7bc3b</Hash>
</Codenesium>*/