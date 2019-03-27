using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CADNS.Api.Client
{
	public partial class ApiCallClientResponseModel : AbstractApiClientResponseModel
	{
		public virtual void SetProperties(
			int id,
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
			this.Id = id;
			this.AddressId = addressId;
			this.CallDispositionId = callDispositionId;
			this.CallStatusId = callStatusId;
			this.CallString = callString;
			this.CallTypeId = callTypeId;
			this.DateCleared = dateCleared;
			this.DateCreated = dateCreated;
			this.DateDispatched = dateDispatched;
			this.QuickCallNumber = quickCallNumber;

			this.AddressIdEntity = nameof(ApiResponse.Addresses);

			this.CallDispositionIdEntity = nameof(ApiResponse.CallDispositions);

			this.CallStatusIdEntity = nameof(ApiResponse.CallStatus);

			this.CallTypeIdEntity = nameof(ApiResponse.CallTypes);
		}

		[JsonProperty]
		public ApiAddressClientResponseModel AddressIdNavigation { get; private set; }

		public void SetAddressIdNavigation(ApiAddressClientResponseModel value)
		{
			this.AddressIdNavigation = value;
		}

		[JsonProperty]
		public ApiCallDispositionClientResponseModel CallDispositionIdNavigation { get; private set; }

		public void SetCallDispositionIdNavigation(ApiCallDispositionClientResponseModel value)
		{
			this.CallDispositionIdNavigation = value;
		}

		[JsonProperty]
		public ApiCallStatusClientResponseModel CallStatusIdNavigation { get; private set; }

		public void SetCallStatusIdNavigation(ApiCallStatusClientResponseModel value)
		{
			this.CallStatusIdNavigation = value;
		}

		[JsonProperty]
		public ApiCallTypeClientResponseModel CallTypeIdNavigation { get; private set; }

		public void SetCallTypeIdNavigation(ApiCallTypeClientResponseModel value)
		{
			this.CallTypeIdNavigation = value;
		}

		[JsonProperty]
		public int? AddressId { get; private set; }

		[JsonProperty]
		public string AddressIdEntity { get; set; }

		[JsonProperty]
		public int? CallDispositionId { get; private set; }

		[JsonProperty]
		public string CallDispositionIdEntity { get; set; }

		[JsonProperty]
		public int? CallStatusId { get; private set; }

		[JsonProperty]
		public string CallStatusIdEntity { get; set; }

		[JsonProperty]
		public string CallString { get; private set; }

		[JsonProperty]
		public int? CallTypeId { get; private set; }

		[JsonProperty]
		public string CallTypeIdEntity { get; set; }

		[JsonProperty]
		public DateTime? DateCleared { get; private set; }

		[JsonProperty]
		public DateTime DateCreated { get; private set; }

		[JsonProperty]
		public DateTime? DateDispatched { get; private set; }

		[JsonProperty]
		public int Id { get; private set; }

		[JsonProperty]
		public int QuickCallNumber { get; private set; }
	}
}

/*<Codenesium>
    <Hash>468ac4e7716ede69ca6c5737a7919201</Hash>
</Codenesium>*/