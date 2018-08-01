using Codenesium.DataConversionExtensions;
using System;

namespace FermataFishNS.Api.Services
{
	public abstract class AbstractBOTeacher : AbstractBusinessObject
	{
		public AbstractBOTeacher()
			: base()
		{
		}

		public virtual void SetProperties(int id,
		                                  DateTime birthday,
		                                  string email,
		                                  string firstName,
		                                  string lastName,
		                                  string phone,
		                                  int studioId)
		{
			this.Birthday = birthday;
			this.Email = email;
			this.FirstName = firstName;
			this.Id = id;
			this.LastName = lastName;
			this.Phone = phone;
			this.StudioId = studioId;
		}

		public DateTime Birthday { get; private set; }

		public string Email { get; private set; }

		public string FirstName { get; private set; }

		public int Id { get; private set; }

		public string LastName { get; private set; }

		public string Phone { get; private set; }

		public int StudioId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>e7e3f9c5b736f765746703a43e3a5d7d</Hash>
</Codenesium>*/