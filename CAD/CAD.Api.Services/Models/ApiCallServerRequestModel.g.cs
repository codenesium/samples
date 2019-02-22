using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace CADNS.Api.Services
{
	public partial class ApiCallServerRequestModel : AbstractApiServerRequestModel
	{
		public ApiCallServerRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			int? addressId,
			int? callDispositionId,
			int? callStatusId,
			string callString,
			int? callTypeId,
			DateTime? dateCleared,
			DateTime dateCreated,
			DateTime? dateDispatched,
			int quickCallNumber)
		{
			this.AddressId = addressId;
			this.CallDispositionId = callDispositionId;
			this.CallStatusId = callStatusId;
			this.CallString = callString;
			this.CallTypeId = callTypeId;
			this.DateCleared = dateCleared;
			this.DateCreated = dateCreated;
			this.DateDispatched = dateDispatched;
			this.QuickCallNumber = quickCallNumber;
		}

		[JsonProperty]
		public int? AddressId { get; private set; }

		[JsonProperty]
		public int? CallDispositionId { get; private set; }

		[JsonProperty]
		public int? CallStatusId { get; private set; }

		[Required]
		[JsonProperty]
		public string CallString { get; private set; } = default(string);

		[JsonProperty]
		public int? CallTypeId { get; private set; }

		[JsonProperty]
		public DateTime? DateCleared { get; private set; } = null;

		[Required]
		[JsonProperty]
		public DateTime DateCreated { get; private set; } = SqlDateTime.MinValue.Value;

		[JsonProperty]
		public DateTime? DateDispatched { get; private set; } = null;

		[Required]
		[JsonProperty]
		public int QuickCallNumber { get; private set; } = default(int);
	}
}

/*<Codenesium>
    <Hash>5049ab833ce8fa5324aee23b367c4996</Hash>
</Codenesium>*/