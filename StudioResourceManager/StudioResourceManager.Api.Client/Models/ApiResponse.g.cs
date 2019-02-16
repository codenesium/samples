using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StudioResourceManagerNS.Api.Client
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
			from.Families.ForEach(x => this.AddFamily(x));
			from.Rates.ForEach(x => this.AddRate(x));
			from.Spaces.ForEach(x => this.AddSpace(x));
			from.SpaceFeatures.ForEach(x => this.AddSpaceFeature(x));
			from.Students.ForEach(x => this.AddStudent(x));
			from.Studios.ForEach(x => this.AddStudio(x));
			from.Teachers.ForEach(x => this.AddTeacher(x));
			from.TeacherSkills.ForEach(x => this.AddTeacherSkill(x));
			from.Users.ForEach(x => this.AddUser(x));
		}

		public List<ApiAdminClientResponseModel> Admins { get; private set; } = new List<ApiAdminClientResponseModel>();

		public List<ApiEventClientResponseModel> Events { get; private set; } = new List<ApiEventClientResponseModel>();

		public List<ApiEventStatusClientResponseModel> EventStatus { get; private set; } = new List<ApiEventStatusClientResponseModel>();

		public List<ApiFamilyClientResponseModel> Families { get; private set; } = new List<ApiFamilyClientResponseModel>();

		public List<ApiRateClientResponseModel> Rates { get; private set; } = new List<ApiRateClientResponseModel>();

		public List<ApiSpaceClientResponseModel> Spaces { get; private set; } = new List<ApiSpaceClientResponseModel>();

		public List<ApiSpaceFeatureClientResponseModel> SpaceFeatures { get; private set; } = new List<ApiSpaceFeatureClientResponseModel>();

		public List<ApiStudentClientResponseModel> Students { get; private set; } = new List<ApiStudentClientResponseModel>();

		public List<ApiStudioClientResponseModel> Studios { get; private set; } = new List<ApiStudioClientResponseModel>();

		public List<ApiTeacherClientResponseModel> Teachers { get; private set; } = new List<ApiTeacherClientResponseModel>();

		public List<ApiTeacherSkillClientResponseModel> TeacherSkills { get; private set; } = new List<ApiTeacherSkillClientResponseModel>();

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
    <Hash>1e079aeafc117ad82c90bfb57746979c</Hash>
</Codenesium>*/