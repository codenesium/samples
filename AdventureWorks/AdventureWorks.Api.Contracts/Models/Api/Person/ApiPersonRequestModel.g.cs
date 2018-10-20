using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiPersonRequestModel : AbstractApiRequestModel
	{
		public ApiPersonRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
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

		[JsonProperty]
		public string AdditionalContactInfo { get; private set; } = default(string);

		[JsonProperty]
		public string Demographic { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public int EmailPromotion { get; private set; } = default(int);

		[Required]
		[JsonProperty]
		public string FirstName { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public string LastName { get; private set; } = default(string);

		[JsonProperty]
		public string MiddleName { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public DateTime ModifiedDate { get; private set; } = default(DateTime);

		[Required]
		[JsonProperty]
		public bool NameStyle { get; private set; } = default(bool);

		[Required]
		[JsonProperty]
		public string PersonType { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public Guid Rowguid { get; private set; } = default(Guid);

		[JsonProperty]
		public string Suffix { get; private set; } = default(string);

		[JsonProperty]
		public string Title { get; private set; } = default(string);
	}
}

/*<Codenesium>
    <Hash>2d9702a2476c43d791207161c9851ace</Hash>
</Codenesium>*/