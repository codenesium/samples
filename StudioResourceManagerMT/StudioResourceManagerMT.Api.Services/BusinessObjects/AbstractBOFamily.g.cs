using Codenesium.DataConversionExtensions;
using System;

namespace StudioResourceManagerMTNS.Api.Services
{
	public abstract class AbstractBOFamily : AbstractBusinessObject
	{
		public AbstractBOFamily()
			: base()
		{
		}

		public virtual void SetProperties(int id,
		                                  string note,
		                                  string primaryContactEmail,
		                                  string primaryContactFirstName,
		                                  string primaryContactLastName,
		                                  string primaryContactPhone)
		{
			this.Id = id;
			this.Note = note;
			this.PrimaryContactEmail = primaryContactEmail;
			this.PrimaryContactFirstName = primaryContactFirstName;
			this.PrimaryContactLastName = primaryContactLastName;
			this.PrimaryContactPhone = primaryContactPhone;
		}

		public int Id { get; private set; }

		public string Note { get; private set; }

		public string PrimaryContactEmail { get; private set; }

		public string PrimaryContactFirstName { get; private set; }

		public string PrimaryContactLastName { get; private set; }

		public string PrimaryContactPhone { get; private set; }
	}
}

/*<Codenesium>
    <Hash>379c927bbf349b1db7e142ee0967b6e8</Hash>
</Codenesium>*/