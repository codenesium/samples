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
			from.EventStudents.ForEach(x => this.AddEventStudent(x));
			from.EventTeachers.ForEach(x => this.AddEventTeacher(x));
			from.Families.ForEach(x => this.AddFamily(x));
			from.Rates.ForEach(x => this.AddRate(x));
			from.Spaces.ForEach(x => this.AddSpace(x));
			from.SpaceFeatures.ForEach(x => this.AddSpaceFeature(x));
			from.SpaceSpaceFeatures.ForEach(x => this.AddSpaceSpaceFeature(x));
			from.Students.ForEach(x => this.AddStudent(x));
			from.Studios.ForEach(x => this.AddStudio(x));
			from.Teachers.ForEach(x => this.AddTeacher(x));
			from.TeacherSkills.ForEach(x => this.AddTeacherSkill(x));
			from.TeacherTeacherSkills.ForEach(x => this.AddTeacherTeacherSkill(x));
			from.Tenants.ForEach(x => this.AddTenant(x));
			from.Users.ForEach(x => this.AddUser(x));
		}

		public List<ApiAdminResponseModel> Admins { get; private set; } = new List<ApiAdminResponseModel>();

		public List<ApiEventResponseModel> Events { get; private set; } = new List<ApiEventResponseModel>();

		public List<ApiEventStatusResponseModel> EventStatuses { get; private set; } = new List<ApiEventStatusResponseModel>();

		public List<ApiEventStudentResponseModel> EventStudents { get; private set; } = new List<ApiEventStudentResponseModel>();

		public List<ApiEventTeacherResponseModel> EventTeachers { get; private set; } = new List<ApiEventTeacherResponseModel>();

		public List<ApiFamilyResponseModel> Families { get; private set; } = new List<ApiFamilyResponseModel>();

		public List<ApiRateResponseModel> Rates { get; private set; } = new List<ApiRateResponseModel>();

		public List<ApiSpaceResponseModel> Spaces { get; private set; } = new List<ApiSpaceResponseModel>();

		public List<ApiSpaceFeatureResponseModel> SpaceFeatures { get; private set; } = new List<ApiSpaceFeatureResponseModel>();

		public List<ApiSpaceSpaceFeatureResponseModel> SpaceSpaceFeatures { get; private set; } = new List<ApiSpaceSpaceFeatureResponseModel>();

		public List<ApiStudentResponseModel> Students { get; private set; } = new List<ApiStudentResponseModel>();

		public List<ApiStudioResponseModel> Studios { get; private set; } = new List<ApiStudioResponseModel>();

		public List<ApiTeacherResponseModel> Teachers { get; private set; } = new List<ApiTeacherResponseModel>();

		public List<ApiTeacherSkillResponseModel> TeacherSkills { get; private set; } = new List<ApiTeacherSkillResponseModel>();

		public List<ApiTeacherTeacherSkillResponseModel> TeacherTeacherSkills { get; private set; } = new List<ApiTeacherTeacherSkillResponseModel>();

		public List<ApiTenantResponseModel> Tenants { get; private set; } = new List<ApiTenantResponseModel>();

		public List<ApiUserResponseModel> Users { get; private set; } = new List<ApiUserResponseModel>();

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
		public bool ShouldSerializeEventStudentsValue { get; private set; } = true;

		public bool ShouldSerializeEventStudents()
		{
			return this.ShouldSerializeEventStudentsValue;
		}

		public void AddEventStudent(ApiEventStudentResponseModel item)
		{
			if (!this.EventStudents.Any(x => x.Id == item.Id))
			{
				this.EventStudents.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeEventTeachersValue { get; private set; } = true;

		public bool ShouldSerializeEventTeachers()
		{
			return this.ShouldSerializeEventTeachersValue;
		}

		public void AddEventTeacher(ApiEventTeacherResponseModel item)
		{
			if (!this.EventTeachers.Any(x => x.Id == item.Id))
			{
				this.EventTeachers.Add(item);
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
		public bool ShouldSerializeSpaceSpaceFeaturesValue { get; private set; } = true;

		public bool ShouldSerializeSpaceSpaceFeatures()
		{
			return this.ShouldSerializeSpaceSpaceFeaturesValue;
		}

		public void AddSpaceSpaceFeature(ApiSpaceSpaceFeatureResponseModel item)
		{
			if (!this.SpaceSpaceFeatures.Any(x => x.Id == item.Id))
			{
				this.SpaceSpaceFeatures.Add(item);
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
		public bool ShouldSerializeTeacherTeacherSkillsValue { get; private set; } = true;

		public bool ShouldSerializeTeacherTeacherSkills()
		{
			return this.ShouldSerializeTeacherTeacherSkillsValue;
		}

		public void AddTeacherTeacherSkill(ApiTeacherTeacherSkillResponseModel item)
		{
			if (!this.TeacherTeacherSkills.Any(x => x.Id == item.Id))
			{
				this.TeacherTeacherSkills.Add(item);
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

			if (this.EventStudents.Count == 0)
			{
				this.ShouldSerializeEventStudentsValue = false;
			}

			if (this.EventTeachers.Count == 0)
			{
				this.ShouldSerializeEventTeachersValue = false;
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

			if (this.SpaceSpaceFeatures.Count == 0)
			{
				this.ShouldSerializeSpaceSpaceFeaturesValue = false;
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

			if (this.TeacherTeacherSkills.Count == 0)
			{
				this.ShouldSerializeTeacherTeacherSkillsValue = false;
			}

			if (this.Tenants.Count == 0)
			{
				this.ShouldSerializeTenantsValue = false;
			}

			if (this.Users.Count == 0)
			{
				this.ShouldSerializeUsersValue = false;
			}
		}
	}
}

/*<Codenesium>
    <Hash>42f891083a2ee79b48e73a736e7f88e4</Hash>
</Codenesium>*/