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
			from.CallAssignments.ForEach(x => this.AddCallAssignment(x));
			from.CallDispositions.ForEach(x => this.AddCallDisposition(x));
			from.CallPersons.ForEach(x => this.AddCallPerson(x));
			from.CallStatus.ForEach(x => this.AddCallStatu(x));
			from.CallTypes.ForEach(x => this.AddCallType(x));
			from.Notes.ForEach(x => this.AddNote(x));
			from.Officers.ForEach(x => this.AddOfficer(x));
			from.OfficerCapabilities.ForEach(x => this.AddOfficerCapability(x));
			from.OfficerRefCapabilities.ForEach(x => this.AddOfficerRefCapability(x));
			from.People.ForEach(x => this.AddPerson(x));
			from.PersonTypes.ForEach(x => this.AddPersonType(x));
			from.Units.ForEach(x => this.AddUnit(x));
			from.UnitDispositions.ForEach(x => this.AddUnitDisposition(x));
			from.UnitOfficers.ForEach(x => this.AddUnitOfficer(x));
			from.Vehicles.ForEach(x => this.AddVehicle(x));
			from.VehicleCapabilities.ForEach(x => this.AddVehicleCapability(x));
			from.VehicleOfficers.ForEach(x => this.AddVehicleOfficer(x));
			from.VehicleRefCapabilities.ForEach(x => this.AddVehicleRefCapability(x));
		}

		public List<ApiAddressClientResponseModel> Addresses { get; private set; } = new List<ApiAddressClientResponseModel>();

		public List<ApiCallClientResponseModel> Calls { get; private set; } = new List<ApiCallClientResponseModel>();

		public List<ApiCallAssignmentClientResponseModel> CallAssignments { get; private set; } = new List<ApiCallAssignmentClientResponseModel>();

		public List<ApiCallDispositionClientResponseModel> CallDispositions { get; private set; } = new List<ApiCallDispositionClientResponseModel>();

		public List<ApiCallPersonClientResponseModel> CallPersons { get; private set; } = new List<ApiCallPersonClientResponseModel>();

		public List<ApiCallStatuClientResponseModel> CallStatus { get; private set; } = new List<ApiCallStatuClientResponseModel>();

		public List<ApiCallTypeClientResponseModel> CallTypes { get; private set; } = new List<ApiCallTypeClientResponseModel>();

		public List<ApiNoteClientResponseModel> Notes { get; private set; } = new List<ApiNoteClientResponseModel>();

		public List<ApiOfficerClientResponseModel> Officers { get; private set; } = new List<ApiOfficerClientResponseModel>();

		public List<ApiOfficerCapabilityClientResponseModel> OfficerCapabilities { get; private set; } = new List<ApiOfficerCapabilityClientResponseModel>();

		public List<ApiOfficerRefCapabilityClientResponseModel> OfficerRefCapabilities { get; private set; } = new List<ApiOfficerRefCapabilityClientResponseModel>();

		public List<ApiPersonClientResponseModel> People { get; private set; } = new List<ApiPersonClientResponseModel>();

		public List<ApiPersonTypeClientResponseModel> PersonTypes { get; private set; } = new List<ApiPersonTypeClientResponseModel>();

		public List<ApiUnitClientResponseModel> Units { get; private set; } = new List<ApiUnitClientResponseModel>();

		public List<ApiUnitDispositionClientResponseModel> UnitDispositions { get; private set; } = new List<ApiUnitDispositionClientResponseModel>();

		public List<ApiUnitOfficerClientResponseModel> UnitOfficers { get; private set; } = new List<ApiUnitOfficerClientResponseModel>();

		public List<ApiVehicleClientResponseModel> Vehicles { get; private set; } = new List<ApiVehicleClientResponseModel>();

		public List<ApiVehicleCapabilityClientResponseModel> VehicleCapabilities { get; private set; } = new List<ApiVehicleCapabilityClientResponseModel>();

		public List<ApiVehicleOfficerClientResponseModel> VehicleOfficers { get; private set; } = new List<ApiVehicleOfficerClientResponseModel>();

		public List<ApiVehicleRefCapabilityClientResponseModel> VehicleRefCapabilities { get; private set; } = new List<ApiVehicleRefCapabilityClientResponseModel>();

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

		public void AddCallAssignment(ApiCallAssignmentClientResponseModel item)
		{
			if (!this.CallAssignments.Any(x => x.Id == item.Id))
			{
				this.CallAssignments.Add(item);
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
			if (!this.OfficerCapabilities.Any(x => x.Id == item.Id))
			{
				this.OfficerCapabilities.Add(item);
			}
		}

		public void AddOfficerRefCapability(ApiOfficerRefCapabilityClientResponseModel item)
		{
			if (!this.OfficerRefCapabilities.Any(x => x.Id == item.Id))
			{
				this.OfficerRefCapabilities.Add(item);
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

		public void AddUnitOfficer(ApiUnitOfficerClientResponseModel item)
		{
			if (!this.UnitOfficers.Any(x => x.Id == item.Id))
			{
				this.UnitOfficers.Add(item);
			}
		}

		public void AddVehicle(ApiVehicleClientResponseModel item)
		{
			if (!this.Vehicles.Any(x => x.Id == item.Id))
			{
				this.Vehicles.Add(item);
			}
		}

		public void AddVehicleCapability(ApiVehicleCapabilityClientResponseModel item)
		{
			if (!this.VehicleCapabilities.Any(x => x.Id == item.Id))
			{
				this.VehicleCapabilities.Add(item);
			}
		}

		public void AddVehicleOfficer(ApiVehicleOfficerClientResponseModel item)
		{
			if (!this.VehicleOfficers.Any(x => x.Id == item.Id))
			{
				this.VehicleOfficers.Add(item);
			}
		}

		public void AddVehicleRefCapability(ApiVehicleRefCapabilityClientResponseModel item)
		{
			if (!this.VehicleRefCapabilities.Any(x => x.Id == item.Id))
			{
				this.VehicleRefCapabilities.Add(item);
			}
		}
	}
}

/*<Codenesium>
    <Hash>9b2be4e3b342078acccce688ba01b71b</Hash>
</Codenesium>*/