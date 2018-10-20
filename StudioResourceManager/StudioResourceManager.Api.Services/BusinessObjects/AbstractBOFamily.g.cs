using Codenesium.DataConversionExtensions;
using System;

namespace StudioResourceManagerNS.Api.Services
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
		                                  string primaryContactPhone,
		                                  bool isDeleted)
		{
			this.Id = id;
			this.Note = note;
			this.PrimaryContactEmail = primaryContactEmail;
			this.PrimaryContactFirstName = primaryContactFirstName;
			this.PrimaryContactLastName = primaryContactLastName;
			this.PrimaryContactPhone = primaryContactPhone;
			this.IsDeleted = isDeleted;
		}

		public int Id { get; private set; }

		public string Note { get; private set; }

		public string PrimaryContactEmail { get; private set; }

		public string PrimaryContactFirstName { get; private set; }

		public string PrimaryContactLastName { get; private set; }

		public string PrimaryContactPhone { get; private set; }

		public bool IsDeleted { get; private set; }
	}
}

/*<Codenesium>
    <Hash>d3b1472254ed826f9b1a0449ba6b0728</Hash>
</Codenesium>*/