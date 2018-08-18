using Codenesium.DataConversionExtensions;
using System;

namespace NebulaNS.Api.Services
{
	public abstract class AbstractBOLinkLog : AbstractBusinessObject
	{
		public AbstractBOLinkLog()
			: base()
		{
		}

		public virtual void SetProperties(int id,
		                                  DateTime dateEntered,
		                                  int linkId,
		                                  string log)
		{
			this.DateEntered = dateEntered;
			this.Id = id;
			this.LinkId = linkId;
			this.Log = log;
		}

		public DateTime DateEntered { get; private set; }

		public int Id { get; private set; }

		public int LinkId { get; private set; }

		public string Log { get; private set; }
	}
}

/*<Codenesium>
    <Hash>8d868ad7f665a604ebdc0f0c5e42920c</Hash>
</Codenesium>*/