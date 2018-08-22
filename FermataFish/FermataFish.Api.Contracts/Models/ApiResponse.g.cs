using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FermataFishNS.Api.Contracts
{
	public partial class ApiResponse
	{
		public ApiResponse()
		{
		}

		public void Merge(ApiResponse from)
		{
			from.Admins.ForEach(x => this.AddAdmin(x));
			from.Families.ForEach(x => this.AddFamily(x));
			from.Lessons.ForEach(x => this.AddLesson(x));
			from.LessonStatuses.ForEach(x => this.AddLessonStatus(x));
			from.LessonXStudents.ForEach(x => this.AddLessonXStudent(x));
			from.LessonXTeachers.ForEach(x => this.AddLessonXTeacher(x));
			from.Rates.ForEach(x => this.AddRate(x));
			from.Spaces.ForEach(x => this.AddSpace(x));
			from.SpaceFeatures.ForEach(x => this.AddSpaceFeature(x));
			from.SpaceXSpaceFeatures.ForEach(x => this.AddSpaceXSpaceFeature(x));
			from.Students.ForEach(x => this.AddStudent(x));
			from.StudentXFamilies.ForEach(x => this.AddStudentXFamily(x));
			from.Studios.ForEach(x => this.AddStudio(x));
			from.Teachers.ForEach(x => this.AddTeacher(x));
			from.TeacherSkills.ForEach(x => this.AddTeacherSkill(x));
			from.TeacherXTeacherSkills.ForEach(x => this.AddTeacherXTeacherSkill(x));
		}

		public List<ApiAdminResponseModel> Admins { get; private set; } = new List<ApiAdminResponseModel>();

		public List<ApiFamilyResponseModel> Families { get; private set; } = new List<ApiFamilyResponseModel>();

		public List<ApiLessonResponseModel> Lessons { get; private set; } = new List<ApiLessonResponseModel>();

		public List<ApiLessonStatusResponseModel> LessonStatuses { get; private set; } = new List<ApiLessonStatusResponseModel>();

		public List<ApiLessonXStudentResponseModel> LessonXStudents { get; private set; } = new List<ApiLessonXStudentResponseModel>();

		public List<ApiLessonXTeacherResponseModel> LessonXTeachers { get; private set; } = new List<ApiLessonXTeacherResponseModel>();

		public List<ApiRateResponseModel> Rates { get; private set; } = new List<ApiRateResponseModel>();

		public List<ApiSpaceResponseModel> Spaces { get; private set; } = new List<ApiSpaceResponseModel>();

		public List<ApiSpaceFeatureResponseModel> SpaceFeatures { get; private set; } = new List<ApiSpaceFeatureResponseModel>();

		public List<ApiSpaceXSpaceFeatureResponseModel> SpaceXSpaceFeatures { get; private set; } = new List<ApiSpaceXSpaceFeatureResponseModel>();

		public List<ApiStudentResponseModel> Students { get; private set; } = new List<ApiStudentResponseModel>();

		public List<ApiStudentXFamilyResponseModel> StudentXFamilies { get; private set; } = new List<ApiStudentXFamilyResponseModel>();

		public List<ApiStudioResponseModel> Studios { get; private set; } = new List<ApiStudioResponseModel>();

		public List<ApiTeacherResponseModel> Teachers { get; private set; } = new List<ApiTeacherResponseModel>();

		public List<ApiTeacherSkillResponseModel> TeacherSkills { get; private set; } = new List<ApiTeacherSkillResponseModel>();

		public List<ApiTeacherXTeacherSkillResponseModel> TeacherXTeacherSkills { get; private set; } = new List<ApiTeacherXTeacherSkillResponseModel>();

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
		public bool ShouldSerializeLessonsValue { get; private set; } = true;

		public bool ShouldSerializeLessons()
		{
			return this.ShouldSerializeLessonsValue;
		}

		public void AddLesson(ApiLessonResponseModel item)
		{
			if (!this.Lessons.Any(x => x.Id == item.Id))
			{
				this.Lessons.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeLessonStatusesValue { get; private set; } = true;

		public bool ShouldSerializeLessonStatuses()
		{
			return this.ShouldSerializeLessonStatusesValue;
		}

		public void AddLessonStatus(ApiLessonStatusResponseModel item)
		{
			if (!this.LessonStatuses.Any(x => x.Id == item.Id))
			{
				this.LessonStatuses.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeLessonXStudentsValue { get; private set; } = true;

		public bool ShouldSerializeLessonXStudents()
		{
			return this.ShouldSerializeLessonXStudentsValue;
		}

		public void AddLessonXStudent(ApiLessonXStudentResponseModel item)
		{
			if (!this.LessonXStudents.Any(x => x.Id == item.Id))
			{
				this.LessonXStudents.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeLessonXTeachersValue { get; private set; } = true;

		public bool ShouldSerializeLessonXTeachers()
		{
			return this.ShouldSerializeLessonXTeachersValue;
		}

		public void AddLessonXTeacher(ApiLessonXTeacherResponseModel item)
		{
			if (!this.LessonXTeachers.Any(x => x.Id == item.Id))
			{
				this.LessonXTeachers.Add(item);
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
		public bool ShouldSerializeSpaceXSpaceFeaturesValue { get; private set; } = true;

		public bool ShouldSerializeSpaceXSpaceFeatures()
		{
			return this.ShouldSerializeSpaceXSpaceFeaturesValue;
		}

		public void AddSpaceXSpaceFeature(ApiSpaceXSpaceFeatureResponseModel item)
		{
			if (!this.SpaceXSpaceFeatures.Any(x => x.Id == item.Id))
			{
				this.SpaceXSpaceFeatures.Add(item);
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
		public bool ShouldSerializeStudentXFamiliesValue { get; private set; } = true;

		public bool ShouldSerializeStudentXFamilies()
		{
			return this.ShouldSerializeStudentXFamiliesValue;
		}

		public void AddStudentXFamily(ApiStudentXFamilyResponseModel item)
		{
			if (!this.StudentXFamilies.Any(x => x.Id == item.Id))
			{
				this.StudentXFamilies.Add(item);
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
		public bool ShouldSerializeTeacherXTeacherSkillsValue { get; private set; } = true;

		public bool ShouldSerializeTeacherXTeacherSkills()
		{
			return this.ShouldSerializeTeacherXTeacherSkillsValue;
		}

		public void AddTeacherXTeacherSkill(ApiTeacherXTeacherSkillResponseModel item)
		{
			if (!this.TeacherXTeacherSkills.Any(x => x.Id == item.Id))
			{
				this.TeacherXTeacherSkills.Add(item);
			}
		}

		public void DisableSerializationOfEmptyFields()
		{
			if (this.Admins.Count == 0)
			{
				this.ShouldSerializeAdminsValue = false;
			}

			if (this.Families.Count == 0)
			{
				this.ShouldSerializeFamiliesValue = false;
			}

			if (this.Lessons.Count == 0)
			{
				this.ShouldSerializeLessonsValue = false;
			}

			if (this.LessonStatuses.Count == 0)
			{
				this.ShouldSerializeLessonStatusesValue = false;
			}

			if (this.LessonXStudents.Count == 0)
			{
				this.ShouldSerializeLessonXStudentsValue = false;
			}

			if (this.LessonXTeachers.Count == 0)
			{
				this.ShouldSerializeLessonXTeachersValue = false;
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

			if (this.SpaceXSpaceFeatures.Count == 0)
			{
				this.ShouldSerializeSpaceXSpaceFeaturesValue = false;
			}

			if (this.Students.Count == 0)
			{
				this.ShouldSerializeStudentsValue = false;
			}

			if (this.StudentXFamilies.Count == 0)
			{
				this.ShouldSerializeStudentXFamiliesValue = false;
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

			if (this.TeacherXTeacherSkills.Count == 0)
			{
				this.ShouldSerializeTeacherXTeacherSkillsValue = false;
			}
		}
	}
}

/*<Codenesium>
    <Hash>28b407459d32057b358f513682f1f9f1</Hash>
</Codenesium>*/