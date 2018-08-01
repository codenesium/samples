using Codenesium.DataConversionExtensions;
using System;

namespace StackOverflowNS.Api.Services
{
	public abstract class AbstractBOBadges : AbstractBusinessObject
	{
		public AbstractBOBadges()
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
    <Hash>be743d05583fa374c7a23cc6f7a3e5e1</Hash>
</Codenesium>*/