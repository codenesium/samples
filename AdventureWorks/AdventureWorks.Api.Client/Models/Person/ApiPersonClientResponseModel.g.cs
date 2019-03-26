using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Client
{
	public partial class ApiPersonClientResponseModel : AbstractApiClientResponseModel
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

			this.BusinessEntityIDEntity = nameof(ApiResponse.BusinessEntities);
		}

		[JsonProperty]
		public ApiBusinessEntityClientResponseModel BusinessEntityIDNavigation { get; private set; }

		public void SetBusinessEntityIDNavigation(ApiBusinessEntityClientResponseModel value)
		{
			this.BusinessEntityIDNavigation = value;
		}

		[JsonProperty]
		public string AdditionalContactInfo { get; private set; }

		[JsonProperty]
		public int BusinessEntityID { get; private set; }

		[JsonProperty]
		public string BusinessEntityIDEntity { get; set; }

		[JsonProperty]
		public string Demographic { get; private set; }

		[JsonProperty]
		public int EmailPromotion { get; private set; }

		[JsonProperty]
		public string FirstName { get; private set; }

		[JsonProperty]
		public string LastName { get; private set; }

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

		[JsonProperty]
		public string Suffix { get; private set; }

		[JsonProperty]
		public string Title { get; private set; }
	}
}

/*<Codenesium>
    <Hash>f6edf5849a1094f035aa37bd1e5257ed</Hash>
</Codenesium>*/