using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace CADNS.Api.Services
{
	public partial class ApiCallServerResponseModel : AbstractApiServerResponseModel
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
		}

		[Required]
		[JsonProperty]
		public int? AddressId { get; private set; }

		[JsonProperty]
		public string AddressIdEntity { get; private set; } = RouteConstants.Addresses;

		[JsonProperty]
		public ApiAddressServerResponseModel AddressIdNavigation { get; private set; }

		public void SetAddressIdNavigation(ApiAddressServerResponseModel value)
		{
			this.AddressIdNavigation = value;
		}

		[Required]
		[JsonProperty]
		public int? CallDispositionId { get; private set; }

		[JsonProperty]
		public string CallDispositionIdEntity { get; private set; } = RouteConstants.CallDispositions;

		[JsonProperty]
		public ApiCallDispositionServerResponseModel CallDispositionIdNavigation { get; private set; }

		public void SetCallDispositionIdNavigation(ApiCallDispositionServerResponseModel value)
		{
			this.CallDispositionIdNavigation = value;
		}

		[Required]
		[JsonProperty]
		public int? CallStatusId { get; private set; }

		[JsonProperty]
		public string CallStatusIdEntity { get; private set; } = RouteConstants.CallStatus;

		[JsonProperty]
		public ApiCallStatusServerResponseModel CallStatusIdNavigation { get; private set; }

		public void SetCallStatusIdNavigation(ApiCallStatusServerResponseModel value)
		{
			this.CallStatusIdNavigation = value;
		}

		[JsonProperty]
		public string CallString { get; private set; }

		[Required]
		[JsonProperty]
		public int? CallTypeId { get; private set; }

		[JsonProperty]
		public string CallTypeIdEntity { get; private set; } = RouteConstants.CallTypes;

		[JsonProperty]
		public ApiCallTypeServerResponseModel CallTypeIdNavigation { get; private set; }

		public void SetCallTypeIdNavigation(ApiCallTypeServerResponseModel value)
		{
			this.CallTypeIdNavigation = value;
		}

		[Required]
		[JsonProperty]
		public DateTime? DateCleared { get; private set; }

		[JsonProperty]
		public DateTime DateCreated { get; private set; }

		[Required]
		[JsonProperty]
		public DateTime? DateDispatched { get; private set; }

		[JsonProperty]
		public int Id { get; private set; }

		[JsonProperty]
		public int QuickCallNumber { get; private set; }
	}
}

/*<Codenesium>
    <Hash>3c2824954e8d829b9f64dd3b266507fe</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/