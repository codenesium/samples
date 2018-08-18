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
    <Hash>0f28f56d6776299e8df432d4123bab32</Hash>
</Codenesium>*/