using Codenesium.DataConversionExtensions;
using System;

namespace StudioResourceManagerMTNS.Api.Services
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
		                                  int userId)
		{
			this.Birthday = birthday;
			this.Email = email;
			this.FirstName = firstName;
			this.Id = id;
			this.LastName = lastName;
			this.Phone = phone;
			this.UserId = userId;
		}

		public DateTime? Birthday { get; private set; }

		public string Email { get; private set; }

		public string FirstName { get; private set; }

		public int Id { get; private set; }

		public string LastName { get; private set; }

		public string Phone { get; private set; }

		public int UserId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>f7b1082dc18d02858692d5d5e24bc91c</Hash>
</Codenesium>*/