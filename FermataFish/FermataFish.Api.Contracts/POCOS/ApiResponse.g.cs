using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace FermataFishNS.Api.Contracts
{
	public class ReferenceEntity<T>
	{
		[JsonProperty(PropertyName = "Value")]
		public T Value { get; set; }

		[JsonProperty(PropertyName = "Object")]
		public string ReferenceObjectName { get; set; }

		public ReferenceEntity(T value, string referenceObjectName)
		{
			this.Value = value;
			this.ReferenceObjectName = referenceObjectName;
		}
	}

	public partial class ApiResponse
	{
		public ApiResponse()
		{}

		public void Merge(ApiResponse from)
		{
			from.Admins.ForEach(x => this.AddAdmin(x));
			from.Families.ForEach(x => this.AddFamily(x));
			from.Lessons.ForEach(x => this.AddLesson(x));
			from.LessonStatus.ForEach(x => this.AddLessonStatus(x));
			from.LessonXStudents.ForEach(x => this.AddLessonXStudent(x));
			from.LessonXTeachers.ForEach(x => this.AddLessonXTeacher(x));
			from.Rates.ForEach(x => this.AddRate(x));
			from.Spaces.ForEach(x => this.AddSpace(x));
			from.SpaceFeatures.ForEach(x => this.AddSpaceFeature(x));
			from.SpaceXSpaceFeatures.ForEach(x => this.AddSpaceXSpaceFeature(x));
			from.States.ForEach(x => this.AddState(x));
			from.Students.ForEach(x => this.AddStudent(x));
			from.StudentXFamilies.ForEach(x => this.AddStudentXFamily(x));
			from.Studios.ForEach(x => this.AddStudio(x));
			from.Teachers.ForEach(x => this.AddTeacher(x));
			from.TeacherSkills.ForEach(x => this.AddTeacherSkill(x));
			from.TeacherXTeacherSkills.ForEach(x => this.AddTeacherXTeacherSkill(x));
		}

		public List<POCOAdmin> Admins { get; private set; } = new List<POCOAdmin>();

		public List<POCOFamily> Families { get; private set; } = new List<POCOFamily>();

		public List<POCOLesson> Lessons { get; private set; } = new List<POCOLesson>();

		public List<POCOLessonStatus> LessonStatus { get; private set; } = new List<POCOLessonStatus>();

		public List<POCOLessonXStudent> LessonXStudents { get; private set; } = new List<POCOLessonXStudent>();

		public List<POCOLessonXTeacher> LessonXTeachers { get; private set; } = new List<POCOLessonXTeacher>();

		public List<POCORate> Rates { get; private set; } = new List<POCORate>();

		public List<POCOSpace> Spaces { get; private set; } = new List<POCOSpace>();

		public List<POCOSpaceFeature> SpaceFeatures { get; private set; } = new List<POCOSpaceFeature>();

		public List<POCOSpaceXSpaceFeature> SpaceXSpaceFeatures { get; private set; } = new List<POCOSpaceXSpaceFeature>();

		public List<POCOState> States { get; private set; } = new List<POCOState>();

		public List<POCOStudent> Students { get; private set; } = new List<POCOStudent>();

		public List<POCOStudentXFamily> StudentXFamilies { get; private set; } = new List<POCOStudentXFamily>();

		public List<POCOStudio> Studios { get; private set; } = new List<POCOStudio>();

		public List<POCOTeacher> Teachers { get; private set; } = new List<POCOTeacher>();

		public List<POCOTeacherSkill> TeacherSkills { get; private set; } = new List<POCOTeacherSkill>();

		public List<POCOTeacherXTeacherSkill> TeacherXTeacherSkills { get; private set; } = new List<POCOTeacherXTeacherSkill>();

		[JsonIgnore]
		public bool ShouldSerializeAdminsValue { get; set; } = true;

		public bool ShouldSerializeAdmins()
		{
			return this.ShouldSerializeAdminsValue;
		}

		public void AddAdmin(POCOAdmin item)
		{
			if (!this.Admins.Any(x => x.Id == item.Id))
			{
				this.Admins.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeFamiliesValue { get; set; } = true;

		public bool ShouldSerializeFamilies()
		{
			return this.ShouldSerializeFamiliesValue;
		}

		public void AddFamily(POCOFamily item)
		{
			if (!this.Families.Any(x => x.Id == item.Id))
			{
				this.Families.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeLessonsValue { get; set; } = true;

		public bool ShouldSerializeLessons()
		{
			return this.ShouldSerializeLessonsValue;
		}

		public void AddLesson(POCOLesson item)
		{
			if (!this.Lessons.Any(x => x.Id == item.Id))
			{
				this.Lessons.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeLessonStatusValue { get; set; } = true;

		public bool ShouldSerializeLessonStatus()
		{
			return this.ShouldSerializeLessonStatusValue;
		}

		public void AddLessonStatus(POCOLessonStatus item)
		{
			if (!this.LessonStatus.Any(x => x.Id == item.Id))
			{
				this.LessonStatus.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeLessonXStudentsValue { get; set; } = true;

		public bool ShouldSerializeLessonXStudents()
		{
			return this.ShouldSerializeLessonXStudentsValue;
		}

		public void AddLessonXStudent(POCOLessonXStudent item)
		{
			if (!this.LessonXStudents.Any(x => x.Id == item.Id))
			{
				this.LessonXStudents.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeLessonXTeachersValue { get; set; } = true;

		public bool ShouldSerializeLessonXTeachers()
		{
			return this.ShouldSerializeLessonXTeachersValue;
		}

		public void AddLessonXTeacher(POCOLessonXTeacher item)
		{
			if (!this.LessonXTeachers.Any(x => x.Id == item.Id))
			{
				this.LessonXTeachers.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeRatesValue { get; set; } = true;

		public bool ShouldSerializeRates()
		{
			return this.ShouldSerializeRatesValue;
		}

		public void AddRate(POCORate item)
		{
			if (!this.Rates.Any(x => x.Id == item.Id))
			{
				this.Rates.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeSpacesValue { get; set; } = true;

		public bool ShouldSerializeSpaces()
		{
			return this.ShouldSerializeSpacesValue;
		}

		public void AddSpace(POCOSpace item)
		{
			if (!this.Spaces.Any(x => x.Id == item.Id))
			{
				this.Spaces.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeSpaceFeaturesValue { get; set; } = true;

		public bool ShouldSerializeSpaceFeatures()
		{
			return this.ShouldSerializeSpaceFeaturesValue;
		}

		public void AddSpaceFeature(POCOSpaceFeature item)
		{
			if (!this.SpaceFeatures.Any(x => x.Id == item.Id))
			{
				this.SpaceFeatures.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeSpaceXSpaceFeaturesValue { get; set; } = true;

		public bool ShouldSerializeSpaceXSpaceFeatures()
		{
			return this.ShouldSerializeSpaceXSpaceFeaturesValue;
		}

		public void AddSpaceXSpaceFeature(POCOSpaceXSpaceFeature item)
		{
			if (!this.SpaceXSpaceFeatures.Any(x => x.Id == item.Id))
			{
				this.SpaceXSpaceFeatures.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeStatesValue { get; set; } = true;

		public bool ShouldSerializeStates()
		{
			return this.ShouldSerializeStatesValue;
		}

		public void AddState(POCOState item)
		{
			if (!this.States.Any(x => x.Id == item.Id))
			{
				this.States.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeStudentsValue { get; set; } = true;

		public bool ShouldSerializeStudents()
		{
			return this.ShouldSerializeStudentsValue;
		}

		public void AddStudent(POCOStudent item)
		{
			if (!this.Students.Any(x => x.Id == item.Id))
			{
				this.Students.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeStudentXFamiliesValue { get; set; } = true;

		public bool ShouldSerializeStudentXFamilies()
		{
			return this.ShouldSerializeStudentXFamiliesValue;
		}

		public void AddStudentXFamily(POCOStudentXFamily item)
		{
			if (!this.StudentXFamilies.Any(x => x.Id == item.Id))
			{
				this.StudentXFamilies.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeStudiosValue { get; set; } = true;

		public bool ShouldSerializeStudios()
		{
			return this.ShouldSerializeStudiosValue;
		}

		public void AddStudio(POCOStudio item)
		{
			if (!this.Studios.Any(x => x.Id == item.Id))
			{
				this.Studios.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeTeachersValue { get; set; } = true;

		public bool ShouldSerializeTeachers()
		{
			return this.ShouldSerializeTeachersValue;
		}

		public void AddTeacher(POCOTeacher item)
		{
			if (!this.Teachers.Any(x => x.Id == item.Id))
			{
				this.Teachers.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeTeacherSkillsValue { get; set; } = true;

		public bool ShouldSerializeTeacherSkills()
		{
			return this.ShouldSerializeTeacherSkillsValue;
		}

		public void AddTeacherSkill(POCOTeacherSkill item)
		{
			if (!this.TeacherSkills.Any(x => x.Id == item.Id))
			{
				this.TeacherSkills.Add(item);
			}
		}

		[JsonIgnore]
		public bool ShouldSerializeTeacherXTeacherSkillsValue { get; set; } = true;

		public bool ShouldSerializeTeacherXTeacherSkills()
		{
			return this.ShouldSerializeTeacherXTeacherSkillsValue;
		}

		public void AddTeacherXTeacherSkill(POCOTeacherXTeacherSkill item)
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

			if (this.LessonStatus.Count == 0)
			{
				this.ShouldSerializeLessonStatusValue = false;
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

			if (this.States.Count == 0)
			{
				this.ShouldSerializeStatesValue = false;
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
    <Hash>931c73397117559a0ba3161ccca23a71</Hash>
</Codenesium>*/