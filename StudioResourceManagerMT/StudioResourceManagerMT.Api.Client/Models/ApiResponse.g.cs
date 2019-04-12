using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StudioResourceManagerMTNS.Api.Client
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
			from.EventStatus.ForEach(x => this.AddEventStatus(x));
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

		public List<ApiAdminClientResponseModel> Admins { get; private set; } = new List<ApiAdminClientResponseModel>();

		public List<ApiEventClientResponseModel> Events { get; private set; } = new List<ApiEventClientResponseModel>();

		public List<ApiEventStatusClientResponseModel> EventStatus { get; private set; } = new List<ApiEventStatusClientResponseModel>();

		public List<ApiEventStudentClientResponseModel> EventStudents { get; private set; } = new List<ApiEventStudentClientResponseModel>();

		public List<ApiEventTeacherClientResponseModel> EventTeachers { get; private set; } = new List<ApiEventTeacherClientResponseModel>();

		public List<ApiFamilyClientResponseModel> Families { get; private set; } = new List<ApiFamilyClientResponseModel>();

		public List<ApiRateClientResponseModel> Rates { get; private set; } = new List<ApiRateClientResponseModel>();

		public List<ApiSpaceClientResponseModel> Spaces { get; private set; } = new List<ApiSpaceClientResponseModel>();

		public List<ApiSpaceFeatureClientResponseModel> SpaceFeatures { get; private set; } = new List<ApiSpaceFeatureClientResponseModel>();

		public List<ApiSpaceSpaceFeatureClientResponseModel> SpaceSpaceFeatures { get; private set; } = new List<ApiSpaceSpaceFeatureClientResponseModel>();

		public List<ApiStudentClientResponseModel> Students { get; private set; } = new List<ApiStudentClientResponseModel>();

		public List<ApiStudioClientResponseModel> Studios { get; private set; } = new List<ApiStudioClientResponseModel>();

		public List<ApiTeacherClientResponseModel> Teachers { get; private set; } = new List<ApiTeacherClientResponseModel>();

		public List<ApiTeacherSkillClientResponseModel> TeacherSkills { get; private set; } = new List<ApiTeacherSkillClientResponseModel>();

		public List<ApiTeacherTeacherSkillClientResponseModel> TeacherTeacherSkills { get; private set; } = new List<ApiTeacherTeacherSkillClientResponseModel>();

		public List<ApiTenantClientResponseModel> Tenants { get; private set; } = new List<ApiTenantClientResponseModel>();

		public List<ApiUserClientResponseModel> Users { get; private set; } = new List<ApiUserClientResponseModel>();

		public void AddAdmin(ApiAdminClientResponseModel item)
		{
			if (!this.Admins.Any(x => x.Id == item.Id))
			{
				this.Admins.Add(item);
			}
		}

		public void AddEvent(ApiEventClientResponseModel item)
		{
			if (!this.Events.Any(x => x.Id == item.Id))
			{
				this.Events.Add(item);
			}
		}

		public void AddEventStatus(ApiEventStatusClientResponseModel item)
		{
			if (!this.EventStatus.Any(x => x.Id == item.Id))
			{
				this.EventStatus.Add(item);
			}
		}

		public void AddEventStudent(ApiEventStudentClientResponseModel item)
		{
			if (!this.EventStudents.Any(x => x.Id == item.Id))
			{
				this.EventStudents.Add(item);
			}
		}

		public void AddEventTeacher(ApiEventTeacherClientResponseModel item)
		{
			if (!this.EventTeachers.Any(x => x.Id == item.Id))
			{
				this.EventTeachers.Add(item);
			}
		}

		public void AddFamily(ApiFamilyClientResponseModel item)
		{
			if (!this.Families.Any(x => x.Id == item.Id))
			{
				this.Families.Add(item);
			}
		}

		public void AddRate(ApiRateClientResponseModel item)
		{
			if (!this.Rates.Any(x => x.Id == item.Id))
			{
				this.Rates.Add(item);
			}
		}

		public void AddSpace(ApiSpaceClientResponseModel item)
		{
			if (!this.Spaces.Any(x => x.Id == item.Id))
			{
				this.Spaces.Add(item);
			}
		}

		public void AddSpaceFeature(ApiSpaceFeatureClientResponseModel item)
		{
			if (!this.SpaceFeatures.Any(x => x.Id == item.Id))
			{
				this.SpaceFeatures.Add(item);
			}
		}

		public void AddSpaceSpaceFeature(ApiSpaceSpaceFeatureClientResponseModel item)
		{
			if (!this.SpaceSpaceFeatures.Any(x => x.Id == item.Id))
			{
				this.SpaceSpaceFeatures.Add(item);
			}
		}

		public void AddStudent(ApiStudentClientResponseModel item)
		{
			if (!this.Students.Any(x => x.Id == item.Id))
			{
				this.Students.Add(item);
			}
		}

		public void AddStudio(ApiStudioClientResponseModel item)
		{
			if (!this.Studios.Any(x => x.Id == item.Id))
			{
				this.Studios.Add(item);
			}
		}

		public void AddTeacher(ApiTeacherClientResponseModel item)
		{
			if (!this.Teachers.Any(x => x.Id == item.Id))
			{
				this.Teachers.Add(item);
			}
		}

		public void AddTeacherSkill(ApiTeacherSkillClientResponseModel item)
		{
			if (!this.TeacherSkills.Any(x => x.Id == item.Id))
			{
				this.TeacherSkills.Add(item);
			}
		}

		public void AddTeacherTeacherSkill(ApiTeacherTeacherSkillClientResponseModel item)
		{
			if (!this.TeacherTeacherSkills.Any(x => x.Id == item.Id))
			{
				this.TeacherTeacherSkills.Add(item);
			}
		}

		public void AddTenant(ApiTenantClientResponseModel item)
		{
			if (!this.Tenants.Any(x => x.Id == item.Id))
			{
				this.Tenants.Add(item);
			}
		}

		public void AddUser(ApiUserClientResponseModel item)
		{
			if (!this.Users.Any(x => x.Id == item.Id))
			{
				this.Users.Add(item);
			}
		}
	}
}

/*<Codenesium>
    <Hash>0c6b043085794b85bce9cf9ca6c6e3b5</Hash>
</Codenesium>*/