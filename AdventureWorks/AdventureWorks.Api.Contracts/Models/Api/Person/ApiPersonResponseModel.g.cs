using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiPersonResponseModel : AbstractApiResponseModel
	{
		public virtual void SetProperties(
			int businessEntityID,
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
			this.BusinessEntityID = businessEntityID;
			this.AdditionalContactInfo = additionalContactInfo;
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

		[Required]
		[JsonProperty]
		public string AdditionalContactInfo { get; private set; }

		[JsonProperty]
		public int BusinessEntityID { get; private set; }

		[Required]
		[JsonProperty]
		public string Demographic { get; private set; }

		[JsonProperty]
		public int EmailPromotion { get; private set; }

		[JsonProperty]
		public string FirstName { get; private set; }

		[JsonProperty]
		public string LastName { get; private set; }

		[Required]
		[JsonProperty]
		public string MiddleName { get; private set; }

		[JsonProperty]
		public DateTime ModifiedDate { get; private set; }

		[JsonProperty]
		public bool NameStyle { get; private set; }

		[JsonProperty]
		public string PersonType { get; private set; }

		[JsonProperty]
		public Guid Rowguid { get; private set; }

		[Required]
		[JsonProperty]
		public string Suffix { get; private set; }

		[Required]
		[JsonProperty]
		public string Title { get; private set; }
	}
}

/*<Codenesium>
    <Hash>a31f40b7c25409a9b53e4306a2a38a08</Hash>
</Codenesium>*/