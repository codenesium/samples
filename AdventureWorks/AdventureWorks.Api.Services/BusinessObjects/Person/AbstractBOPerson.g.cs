using Codenesium.DataConversionExtensions;
using System;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractBOPerson : AbstractBusinessObject
	{
		public AbstractBOPerson()
			: base()
		{
		}

		public virtual void SetProperties(int businessEntityID,
		                                  string additionalContactInfo,
		                                  string demographic,
		                                  int emailPromotion,
		                                  string firstName,
		                                  string lastName,
		                                  string middleName,
		                                  DateTime modifiedDate,
		                                  bool nameStyle,
		                                  string personType,
		                                  Guid rowguid,
		                                  string suffix,
		                                  string title)
		{
			this.AdditionalContactInfo = additionalContactInfo;
			this.BusinessEntityID = businessEntityID;
			this.Demographic = demographic;
			this.EmailPromotion = emailPromotion;
			this.FirstName = firstName;
			this.LastName = lastName;
			this.MiddleName = middleName;
			this.ModifiedDate = modifiedDate;
			this.NameStyle = nameStyle;
			this.PersonType = personType;
			this.Rowguid = rowguid;
			this.Suffix = suffix;
			this.Title = title;
		}

		public string AdditionalContactInfo { get; private set; }

		public int BusinessEntityID { get; private set; }

		public string Demographic { get; private set; }

		public int EmailPromotion { get; private set; }

		public string FirstName { get; private set; }

		public string LastName { get; private set; }

		public string MiddleName { get; private set; }

		public DateTime ModifiedDate { get; private set; }

		public bool NameStyle { get; private set; }

		public string PersonType { get; private set; }

		public Guid Rowguid { get; private set; }

		public string Suffix { get; private set; }

		public string Title { get; private set; }
	}
}

/*<Codenesium>
    <Hash>8a51a4849bb758e1492513f757572cc3</Hash>
</Codenesium>*/