using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace NebulaNS.Api.Contracts
{
	public partial class POCOLink
	{
		public POCOLink()
		{}

		public POCOLink(Nullable<int> assignedMachineId,
		                int chainId,
		                Nullable<DateTime> dateCompleted,
		                Nullable<DateTime> dateStarted,
		                string dynamicParameters,
		                Guid externalId,
		                int id,
		                int linkStatusId,
		                string name,
		                int order,
		                string response,
		                string staticParameters)
		{
			this.DateCompleted = dateCompleted.ToNullableDateTime();
			this.DateStarted = dateStarted.ToNullableDateTime();
			this.DynamicParameters = dynamicParameters;
			this.ExternalId = externalId;
			this.Id = id.ToInt();
			this.Name = name;
			this.Order = order.ToInt();
			this.Response = response;
			this.StaticParameters = staticParameters;

			AssignedMachineId = new ReferenceEntity<Nullable<int>>(assignedMachineId,
			                                                       "Machine");
			ChainId = new ReferenceEntity<int>(chainId,
			                                   "Chain");
			LinkStatusId = new ReferenceEntity<int>(linkStatusId,
			                                        "LinkStatus");
		}

		public ReferenceEntity<Nullable<int>>AssignedMachineId {get; set;}
		public ReferenceEntity<int>ChainId {get; set;}
		public Nullable<DateTime> DateCompleted {get; set;}
		public Nullable<DateTime> DateStarted {get; set;}
		public string DynamicParameters {get; set;}
		public Guid ExternalId {get; set;}
		public int Id {get; set;}
		public ReferenceEntity<int>LinkStatusId {get; set;}
		public string Name {get; set;}
		public int Order {get; set;}
		public string Response {get; set;}
		public string StaticParameters {get; set;}

		[JsonIgnore]
		public bool ShouldSerializeAssignedMachineIdValue {get; set;} = true;

		public bool ShouldSerializeAssignedMachineId()
		{
			return ShouldSerializeAssignedMachineIdValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeChainIdValue {get; set;} = true;

		public bool ShouldSerializeChainId()
		{
			return ShouldSerializeChainIdValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeDateCompletedValue {get; set;} = true;

		public bool ShouldSerializeDateCompleted()
		{
			return ShouldSerializeDateCompletedValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeDateStartedValue {get; set;} = true;

		public bool ShouldSerializeDateStarted()
		{
			return ShouldSerializeDateStartedValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeDynamicParametersValue {get; set;} = true;

		public bool ShouldSerializeDynamicParameters()
		{
			return ShouldSerializeDynamicParametersValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeExternalIdValue {get; set;} = true;

		public bool ShouldSerializeExternalId()
		{
			return ShouldSerializeExternalIdValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeIdValue {get; set;} = true;

		public bool ShouldSerializeId()
		{
			return ShouldSerializeIdValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeLinkStatusIdValue {get; set;} = true;

		public bool ShouldSerializeLinkStatusId()
		{
			return ShouldSerializeLinkStatusIdValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeNameValue {get; set;} = true;

		public bool ShouldSerializeName()
		{
			return ShouldSerializeNameValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeOrderValue {get; set;} = true;

		public bool ShouldSerializeOrder()
		{
			return ShouldSerializeOrderValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeResponseValue {get; set;} = true;

		public bool ShouldSerializeResponse()
		{
			return ShouldSerializeResponseValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeStaticParametersValue {get; set;} = true;

		public bool ShouldSerializeStaticParameters()
		{
			return ShouldSerializeStaticParametersValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeAssignedMachineIdValue = false;
			this.ShouldSerializeChainIdValue = false;
			this.ShouldSerializeDateCompletedValue = false;
			this.ShouldSerializeDateStartedValue = false;
			this.ShouldSerializeDynamicParametersValue = false;
			this.ShouldSerializeExternalIdValue = false;
			this.ShouldSerializeIdValue = false;
			this.ShouldSerializeLinkStatusIdValue = false;
			this.ShouldSerializeNameValue = false;
			this.ShouldSerializeOrderValue = false;
			this.ShouldSerializeResponseValue = false;
			this.ShouldSerializeStaticParametersValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>9a0637b240ae8de26a4d986ceb9cd779</Hash>
</Codenesium>*/