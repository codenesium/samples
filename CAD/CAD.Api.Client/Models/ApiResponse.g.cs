using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CADNS.Api.Client
{
	public partial class ApiResponse
	{
		public ApiResponse()
		{
		}

		public void Merge(ApiResponse from)
		{
			from.Addresses.ForEach(x => this.AddAddress(x));
			from.Calls.ForEach(x => this.AddCall(x));
			from.CallDispositions.ForEach(x => this.AddCallDisposition(x));
			from.CallPersons.ForEach(x => this.AddCallPerson(x));
			from.CallStatus.ForEach(x => this.AddCallStatu(x));
			from.CallTypes.ForEach(x => this.AddCallType(x));
			from.Notes.ForEach(x => this.AddNote(x));
			from.Officers.ForEach(x => this.AddOfficer(x));
			from.OfficerCapabilities.ForEach(x => this.AddOfficerCapability(x));
			from.People.ForEach(x => this.AddPerson(x));
			from.PersonTypes.ForEach(x => this.AddPersonType(x));
			from.Units.ForEach(x => this.AddUnit(x));
			from.UnitDispositions.ForEach(x => this.AddUnitDisposition(x));
			from.Vehicles.ForEach(x => this.AddVehicle(x));
			from.VehicleCapabilities.ForEach(x => this.AddVehicleCapabilitty(x));
		}

		public List<ApiAddressClientResponseModel> Addresses { get; private set; } = new List<ApiAddressClientResponseModel>();

		public List<ApiCallClientResponseModel> Calls { get; private set; } = new List<ApiCallClientResponseModel>();

		public List<ApiCallDispositionClientResponseModel> CallDispositions { get; private set; } = new List<ApiCallDispositionClientResponseModel>();

		public List<ApiCallPersonClientResponseModel> CallPersons { get; private set; } = new List<ApiCallPersonClientResponseModel>();

		public List<ApiCallStatuClientResponseModel> CallStatus { get; private set; } = new List<ApiCallStatuClientResponseModel>();

		public List<ApiCallTypeClientResponseModel> CallTypes { get; private set; } = new List<ApiCallTypeClientResponseModel>();

		public List<ApiNoteClientResponseModel> Notes { get; private set; } = new List<ApiNoteClientResponseModel>();

		public List<ApiOfficerClientResponseModel> Officers { get; private set; } = new List<ApiOfficerClientResponseModel>();

		public List<ApiOfficerCapabilityClientResponseModel> OfficerCapabilities { get; private set; } = new List<ApiOfficerCapabilityClientResponseModel>();

		public List<ApiPersonClientResponseModel> People { get; private set; } = new List<ApiPersonClientResponseModel>();

		public List<ApiPersonTypeClientResponseModel> PersonTypes { get; private set; } = new List<ApiPersonTypeClientResponseModel>();

		public List<ApiUnitClientResponseModel> Units { get; private set; } = new List<ApiUnitClientResponseModel>();

		public List<ApiUnitDispositionClientResponseModel> UnitDispositions { get; private set; } = new List<ApiUnitDispositionClientResponseModel>();

		public List<ApiVehicleClientResponseModel> Vehicles { get; private set; } = new List<ApiVehicleClientResponseModel>();

		public List<ApiVehicleCapabilittyClientResponseModel> VehicleCapabilities { get; private set; } = new List<ApiVehicleCapabilittyClientResponseModel>();

		public void AddAddress(ApiAddressClientResponseModel item)
		{
			if (!this.Addresses.Any(x => x.Id == item.Id))
			{
				this.Addresses.Add(item);
			}
		}

		public void AddCall(ApiCallClientResponseModel item)
		{
			if (!this.Calls.Any(x => x.Id == item.Id))
			{
				this.Calls.Add(item);
			}
		}

		public void AddCallDisposition(ApiCallDispositionClientResponseModel item)
		{
			if (!this.CallDispositions.Any(x => x.Id == item.Id))
			{
				this.CallDispositions.Add(item);
			}
		}

		public void AddCallPerson(ApiCallPersonClientResponseModel item)
		{
			if (!this.CallPersons.Any(x => x.Id == item.Id))
			{
				this.CallPersons.Add(item);
			}
		}

		public void AddCallStatu(ApiCallStatuClientResponseModel item)
		{
			if (!this.CallStatus.Any(x => x.Id == item.Id))
			{
				this.CallStatus.Add(item);
			}
		}

		public void AddCallType(ApiCallTypeClientResponseModel item)
		{
			if (!this.CallTypes.Any(x => x.Id == item.Id))
			{
				this.CallTypes.Add(item);
			}
		}

		public void AddNote(ApiNoteClientResponseModel item)
		{
			if (!this.Notes.Any(x => x.Id == item.Id))
			{
				this.Notes.Add(item);
			}
		}

		public void AddOfficer(ApiOfficerClientResponseModel item)
		{
			if (!this.Officers.Any(x => x.Id == item.Id))
			{
				this.Officers.Add(item);
			}
		}

		public void AddOfficerCapability(ApiOfficerCapabilityClientResponseModel item)
		{
			if (!this.OfficerCapabilities.Any(x => x.CapabilityId == item.CapabilityId))
			{
				this.OfficerCapabilities.Add(item);
			}
		}

		public void AddPerson(ApiPersonClientResponseModel item)
		{
			if (!this.People.Any(x => x.Id == item.Id))
			{
				this.People.Add(item);
			}
		}

		public void AddPersonType(ApiPersonTypeClientResponseModel item)
		{
			if (!this.PersonTypes.Any(x => x.Id == item.Id))
			{
				this.PersonTypes.Add(item);
			}
		}

		public void AddUnit(ApiUnitClientResponseModel item)
		{
			if (!this.Units.Any(x => x.Id == item.Id))
			{
				this.Units.Add(item);
			}
		}

		public void AddUnitDisposition(ApiUnitDispositionClientResponseModel item)
		{
			if (!this.UnitDispositions.Any(x => x.Id == item.Id))
			{
				this.UnitDispositions.Add(item);
			}
		}

		public void AddVehicle(ApiVehicleClientResponseModel item)
		{
			if (!this.Vehicles.Any(x => x.Id == item.Id))
			{
				this.Vehicles.Add(item);
			}
		}

		public void AddVehicleCapabilitty(ApiVehicleCapabilittyClientResponseModel item)
		{
			if (!this.VehicleCapabilities.Any(x => x.VehicleId == item.VehicleId))
			{
				this.VehicleCapabilities.Add(item);
			}
		}
	}
}

/*<Codenesium>
    <Hash>8ba019e94cd338e10b92348fc5e85e6a</Hash>
</Codenesium>*/