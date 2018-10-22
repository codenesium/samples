using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StudioResourceManagerNS.Api.Contracts
{
	public partial class ApiResponse
	{
		public ApiResponse()
		{
		}

		public void Merge(ApiResponse from)
		{
			from.Admins.ForEach(x => this.AddAdmin(x));
			from.Events.ForEach(x => this.AddEvent(x));
			from.EventStatuses.ForEach(x => this.AddEventStatus(x));
			from.Families.ForEach(x => this.AddFamily(x));
			from.Rates.ForEach(x => this.AddRate(x));
			from.Spaces.ForEach(x => this.AddSpace(x));
			from.SpaceFeatures.ForEach(x => this.AddSpaceFeature(x));
			from.Students.ForEach(x => this.AddStudent(x));
			from.Studios.ForEach(x => this.AddStudio(x));
			from.Teachers.ForEach(x => this.AddTeacher(x));
			from.TeacherSkills.ForEach(x => this.AddTeacherSkill(x));
			from.Tenants.ForEach(x => this.AddTenant(x));
			from.Users.ForEach(x => this.AddUser(x));
			from.VEvents.ForEach(x => this.AddVEvent(x));
		}

		public List<ApiAdminResponseModel> Admins { get; private set; } = new List<ApiAdminResponseModel>();

		public List<ApiEventResponseModel> Events { get; private set; } = new List<ApiEventResponseModel>();

		public List<ApiEventStatusResponseModel> EventStatuses { get; private set; } = new List<ApiEventStatusResponseModel>();

		public List<ApiFamilyResponseModel> Families { get; private set; } = new List<ApiFamilyResponseModel>();

		public List<ApiRateResponseModel> Rates { get; private set; } = new List<ApiRateResponseModel>();

		public List<ApiSpaceResponseModel> Spaces { get; private set; } = new List<ApiSpaceResponseModel>();

		public List<ApiSpaceFeatureResponseModel> SpaceFeatures { get; private set; } = new List<ApiSpaceFeatureResponseModel>();

		public List<ApiStudentResponseModel> Students { get; private set; } = new List<ApiStudentResponseModel>();

		public List<ApiStudioResponseModel> Studios { get; private set; } = new List<ApiStudioResponseModel>();

		public List<ApiTeacherResponseModel> Teachers { get; private set; } = new List<ApiTeacherResponseModel>();

		public List<ApiTeacherSkillResponseModel> TeacherSkills { get; private set; } = new List<ApiTeacherSkillResponseModel>();

		public List<ApiTenantResponseModel> Tenants { get; private set; } = new List<ApiTenantResponseModel>();

		public List<ApiUserResponseModel> Users { get; private set; } = new List<ApiUserResponseModel>();

		public List<ApiVEventResponseModel> VEvents { get; private set; } = new List<ApiVEventResponseModel>();

		[JsonIgnore]
		public bool ShouldSerializeAdminsValue { get; private set; } = true;

		public bool ShouldSerializeAdmins()
		{
			return this.ShouldSerializeAdminsValue;
		}

		public void AddAdmin(ApiAdminResponseModel item)
		{
			if (!this.Admins.Any(x => x.Id == item.Id))
			{
				this.Admins.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeEventsValue { get; private set; } = true;

		public bool ShouldSerializeEvents()
		{
			return this.ShouldSerializeEventsValue;
		}

		public void AddEvent(ApiEventResponseModel item)
		{
			if (!this.Events.Any(x => x.Id == item.Id))
			{
				this.Events.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeEventStatusesValue { get; private set; } = true;

		public bool ShouldSerializeEventStatuses()
		{
			return this.ShouldSerializeEventStatusesValue;
		}

		public void AddEventStatus(ApiEventStatusResponseModel item)
		{
			if (!this.EventStatuses.Any(x => x.Id == item.Id))
			{
				this.EventStatuses.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeFamiliesValue { get; private set; } = true;

		public bool ShouldSerializeFamilies()
		{
			return this.ShouldSerializeFamiliesValue;
		}

		public void AddFamily(ApiFamilyResponseModel item)
		{
			if (!this.Families.Any(x => x.Id == item.Id))
			{
				this.Families.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeRatesValue { get; private set; } = true;

		public bool ShouldSerializeRates()
		{
			return this.ShouldSerializeRatesValue;
		}

		public void AddRate(ApiRateResponseModel item)
		{
			if (!this.Rates.Any(x => x.Id == item.Id))
			{
				this.Rates.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeSpacesValue { get; private set; } = true;

		public bool ShouldSerializeSpaces()
		{
			return this.ShouldSerializeSpacesValue;
		}

		public void AddSpace(ApiSpaceResponseModel item)
		{
			if (!this.Spaces.Any(x => x.Id == item.Id))
			{
				this.Spaces.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeSpaceFeaturesValue { get; private set; } = true;

		public bool ShouldSerializeSpaceFeatures()
		{
			return this.ShouldSerializeSpaceFeaturesValue;
		}

		public void AddSpaceFeature(ApiSpaceFeatureResponseModel item)
		{
			if (!this.SpaceFeatures.Any(x => x.Id == item.Id))
			{
				this.SpaceFeatures.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeStudentsValue { get; private set; } = true;

		public bool ShouldSerializeStudents()
		{
			return this.ShouldSerializeStudentsValue;
		}

		public void AddStudent(ApiStudentResponseModel item)
		{
			if (!this.Students.Any(x => x.Id == item.Id))
			{
				this.Students.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeStudiosValue { get; private set; } = true;

		public bool ShouldSerializeStudios()
		{
			return this.ShouldSerializeStudiosValue;
		}

		public void AddStudio(ApiStudioResponseModel item)
		{
			if (!this.Studios.Any(x => x.Id == item.Id))
			{
				this.Studios.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeTeachersValue { get; private set; } = true;

		public bool ShouldSerializeTeachers()
		{
			return this.ShouldSerializeTeachersValue;
		}

		public void AddTeacher(ApiTeacherResponseModel item)
		{
			if (!this.Teachers.Any(x => x.Id == item.Id))
			{
				this.Teachers.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeTeacherSkillsValue { get; private set; } = true;

		public bool ShouldSerializeTeacherSkills()
		{
			return this.ShouldSerializeTeacherSkillsValue;
		}

		public void AddTeacherSkill(ApiTeacherSkillResponseModel item)
		{
			if (!this.TeacherSkills.Any(x => x.Id == item.Id))
			{
				this.TeacherSkills.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeTenantsValue { get; private set; } = true;

		public bool ShouldSerializeTenants()
		{
			return this.ShouldSerializeTenantsValue;
		}

		public void AddTenant(ApiTenantResponseModel item)
		{
			if (!this.Tenants.Any(x => x.Id == item.Id))
			{
				this.Tenants.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeUsersValue { get; private set; } = true;

		public bool ShouldSerializeUsers()
		{
			return this.ShouldSerializeUsersValue;
		}

		public void AddUser(ApiUserResponseModel item)
		{
			if (!this.Users.Any(x => x.Id == item.Id))
			{
				this.Users.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeVEventsValue { get; private set; } = true;

		public bool ShouldSerializeVEvents()
		{
			return this.ShouldSerializeVEventsValue;
		}

		public void AddVEvent(ApiVEventResponseModel item)
		{
			if (!this.VEvents.Any(x => x.Id == item.Id))
			{
				this.VEvents.Add(item);
			}
		}

		public void DisableSerializationOfEmptyFields()
		{
			if (this.Admins.Count == 0)
			{
				this.ShouldSerializeAdminsValue = false;
			}

			if (this.Events.Count == 0)
			{
				this.ShouldSerializeEventsValue = false;
			}

			if (this.EventStatuses.Count == 0)
			{
				this.ShouldSerializeEventStatusesValue = false;
			}

			if (this.Families.Count == 0)
			{
				this.ShouldSerializeFamiliesValue = false;
			}

			if (this.Rates.Count == 0)
			{
				this.ShouldSerializeRatesValue = false;
			}

			if (this.Spaces.Count == 0)
			{
				this.ShouldSerializeSpacesValue = false;
			}

			if (this.SpaceFeatures.Count == 0)
			{
				this.ShouldSerializeSpaceFeaturesValue = false;
			}

			if (this.Students.Count == 0)
			{
				this.ShouldSerializeStudentsValue = false;
			}

			if (this.Studios.Count == 0)
			{
				this.ShouldSerializeStudiosValue = false;
			}

			if (this.Teachers.Count == 0)
			{
				this.ShouldSerializeTeachersValue = false;
			}

			if (this.TeacherSkills.Count == 0)
			{
				this.ShouldSerializeTeacherSkillsValue = false;
			}

			if (this.Tenants.Count == 0)
			{
				this.ShouldSerializeTenantsValue = false;
			}

			if (this.Users.Count == 0)
			{
				this.ShouldSerializeUsersValue = false;
			}

			if (this.VEvents.Count == 0)
			{
				this.ShouldSerializeVEventsValue = false;
			}
		}
	}
}

/*<Codenesium>
    <Hash>9c7feec9bec0ebf6174baa713eb3c2c2</Hash>
</Codenesium>*/