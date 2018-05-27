using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class DTOPerson: AbstractDTO
	{
		public DTOPerson() : base()
		{}

		public void SetProperties(int businessEntityID,
		                          string additionalContactInfo,
		                          string demographics,
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
			this.BusinessEntityID = businessEntityID.ToInt();
			this.Demographics = demographics;
			this.EmailPromotion = emailPromotion.ToInt();
			this.FirstName = firstName;
			this.LastName = lastName;
			this.MiddleName = middleName;
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.NameStyle = nameStyle.ToBoolean();
			this.PersonType = personType;
			this.Rowguid = rowguid.ToGuid();
			this.Suffix = suffix;
			this.Title = title;
		}

		public string AdditionalContactInfo { get; set; }
		public int BusinessEntityID { get; set; }
		public string Demographics { get; set; }
		public int EmailPromotion { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string MiddleName { get; set; }
		public DateTime ModifiedDate { get; set; }
		public bool NameStyle { get; set; }
		public string PersonType { get; set; }
		public Guid Rowguid { get; set; }
		public string Suffix { get; set; }
		public string Title { get; set; }
	}
}

/*<Codenesium>
    <Hash>fbd7e5671f5587575178b1a775112192</Hash>
</Codenesium>*/