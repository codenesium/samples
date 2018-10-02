using Codenesium.DataConversionExtensions;
using System;

namespace StackOverflowNS.Api.Services
{
	public abstract class AbstractBOBadge : AbstractBusinessObject
	{
		public AbstractBOBadge()
			: base()
		{
		}

		public virtual void SetProperties(int id,
		                                  DateTime date,
		                                  string name,
		                                  int userId)
		{
			this.Date = date;
			this.Id = id;
			this.Name = name;
			this.UserId = userId;
		}

		public DateTime Date { get; private set; }

		public int Id { get; private set; }

		public string Name { get; private set; }

		public int UserId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>32d6513afbc3de544ba676f0be4f34af</Hash>
</Codenesium>*/