using Codenesium.DataConversionExtensions;
using System;

namespace FermataFishNS.Api.Services
{
	public abstract class AbstractBOAdmin : AbstractBusinessObject
	{
		public AbstractBOAdmin()
			: base()
		{
		}

		public virtual void SetProperties(int id,
		                                  DateTime? birthday,
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

		public DateTime? Birthday { get; private set; }

		public string Email { get; private set; }

		public string FirstName { get; private set; }

		public int Id { get; private set; }

		public string LastName { get; private set; }

		public string Phone { get; private set; }

		public int StudioId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>995d2534e226e0993b6f5de4bd51577c</Hash>
</Codenesium>*/