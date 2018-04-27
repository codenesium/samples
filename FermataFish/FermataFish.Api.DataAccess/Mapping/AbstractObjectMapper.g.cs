using System;
using Microsoft.EntityFrameworkCore;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.DataAccess
{
	public abstract class AbstractObjectMapper
	{
		public virtual void AdminMapModelToEF(
			int id,
			AdminModel model,
			EFAdmin efAdmin)
		{
			efAdmin.SetProperties(
				id,
				model.Birthday,
				model.Email,
				model.FirstName,
				model.LastName,
				model.Phone,
				model.StudioId);
		}

		public virtual void AdminMapEFToPOCO(
			EFAdmin efAdmin,
			ApiResponse response)
		{
			if (efAdmin == null)
			{
				return;
			}

			response.AddAdmin(new POCOAdmin(efAdmin.Birthday, efAdmin.Email, efAdmin.FirstName, efAdmin.Id, efAdmin.LastName, efAdmin.Phone, efAdmin.StudioId));

			this.StudioMapEFToPOCO(efAdmin.Studio, response);
		}

		public virtual void FamilyMapModelToEF(
			int id,
			FamilyModel model,
			EFFamily efFamily)
		{
			efFamily.SetProperties(
				id,
				model.Notes,
				model.PcEmail,
				model.PcFirstName,
				model.PcLastName,
				model.PcPhone,
				model.StudioId);
		}

		public virtual void FamilyMapEFToPOCO(
			EFFamily efFamily,
			ApiResponse response)
		{
			if (efFamily == null)
			{
				return;
			}

			response.AddFamily(new POCOFamily(efFamily.Id, efFamily.Notes, efFamily.PcEmail, efFamily.PcFirstName, efFamily.PcLastName, efFamily.PcPhone, efFamily.StudioId));

			this.StudioMapEFToPOCO(efFamily.Studio, response);

			this.StudioMapEFToPOCO(efFamily.Studio1, response);
		}

		public virtual void LessonMapModelToEF(
			int id,
			LessonModel model,
			EFLesson efLesson)
		{
			efLesson.SetProperties(
				id,
				model.ActualEndDate,
				model.ActualStartDate,
				model.BillAmount,
				model.LessonStatusId,
				model.ScheduledEndDate,
				model.ScheduledStartDate,
				model.StudentNotes,
				model.StudioId,
				model.TeacherNotes);
		}

		public virtual void LessonMapEFToPOCO(
			EFLesson efLesson,
			ApiResponse response)
		{
			if (efLesson == null)
			{
				return;
			}

			response.AddLesson(new POCOLesson(efLesson.ActualEndDate, efLesson.ActualStartDate, efLesson.BillAmount, efLesson.Id, efLesson.LessonStatusId, efLesson.ScheduledEndDate, efLesson.ScheduledStartDate, efLesson.StudentNotes, efLesson.StudioId, efLesson.TeacherNotes));

			this.LessonStatusMapEFToPOCO(efLesson.LessonStatus, response);

			this.StudioMapEFToPOCO(efLesson.Studio, response);
		}

		public virtual void LessonStatusMapModelToEF(
			int id,
			LessonStatusModel model,
			EFLessonStatus efLessonStatus)
		{
			efLessonStatus.SetProperties(
				id,
				model.Name,
				model.StudioId);
		}

		public virtual void LessonStatusMapEFToPOCO(
			EFLessonStatus efLessonStatus,
			ApiResponse response)
		{
			if (efLessonStatus == null)
			{
				return;
			}

			response.AddLessonStatus(new POCOLessonStatus(efLessonStatus.Id, efLessonStatus.Name, efLessonStatus.StudioId));

			this.StudioMapEFToPOCO(efLessonStatus.Studio, response);

			this.StudioMapEFToPOCO(efLessonStatus.Studio1, response);
		}

		public virtual void LessonXStudentMapModelToEF(
			int id,
			LessonXStudentModel model,
			EFLessonXStudent efLessonXStudent)
		{
			efLessonXStudent.SetProperties(
				id,
				model.LessonId,
				model.StudentId);
		}

		public virtual void LessonXStudentMapEFToPOCO(
			EFLessonXStudent efLessonXStudent,
			ApiResponse response)
		{
			if (efLessonXStudent == null)
			{
				return;
			}

			response.AddLessonXStudent(new POCOLessonXStudent(efLessonXStudent.Id, efLessonXStudent.LessonId, efLessonXStudent.StudentId));

			this.LessonMapEFToPOCO(efLessonXStudent.Lesson, response);

			this.StudentMapEFToPOCO(efLessonXStudent.Student, response);
		}

		public virtual void LessonXTeacherMapModelToEF(
			int id,
			LessonXTeacherModel model,
			EFLessonXTeacher efLessonXTeacher)
		{
			efLessonXTeacher.SetProperties(
				id,
				model.LessonId,
				model.StudentId);
		}

		public virtual void LessonXTeacherMapEFToPOCO(
			EFLessonXTeacher efLessonXTeacher,
			ApiResponse response)
		{
			if (efLessonXTeacher == null)
			{
				return;
			}

			response.AddLessonXTeacher(new POCOLessonXTeacher(efLessonXTeacher.Id, efLessonXTeacher.LessonId, efLessonXTeacher.StudentId));

			this.LessonMapEFToPOCO(efLessonXTeacher.Lesson, response);

			this.StudentMapEFToPOCO(efLessonXTeacher.Student, response);
		}

		public virtual void RateMapModelToEF(
			int id,
			RateModel model,
			EFRate efRate)
		{
			efRate.SetProperties(
				id,
				model.AmountPerMinute,
				model.TeacherId,
				model.TeacherSkillId);
		}

		public virtual void RateMapEFToPOCO(
			EFRate efRate,
			ApiResponse response)
		{
			if (efRate == null)
			{
				return;
			}

			response.AddRate(new POCORate(efRate.AmountPerMinute, efRate.Id, efRate.TeacherId, efRate.TeacherSkillId));

			this.TeacherMapEFToPOCO(efRate.Teacher, response);

			this.TeacherSkillMapEFToPOCO(efRate.TeacherSkill, response);
		}

		public virtual void SpaceMapModelToEF(
			int id,
			SpaceModel model,
			EFSpace efSpace)
		{
			efSpace.SetProperties(
				id,
				model.Description,
				model.Name,
				model.StudioId);
		}

		public virtual void SpaceMapEFToPOCO(
			EFSpace efSpace,
			ApiResponse response)
		{
			if (efSpace == null)
			{
				return;
			}

			response.AddSpace(new POCOSpace(efSpace.Description, efSpace.Id, efSpace.Name, efSpace.StudioId));

			this.StudioMapEFToPOCO(efSpace.Studio, response);
		}

		public virtual void SpaceFeatureMapModelToEF(
			int id,
			SpaceFeatureModel model,
			EFSpaceFeature efSpaceFeature)
		{
			efSpaceFeature.SetProperties(
				id,
				model.Name,
				model.StudioId);
		}

		public virtual void SpaceFeatureMapEFToPOCO(
			EFSpaceFeature efSpaceFeature,
			ApiResponse response)
		{
			if (efSpaceFeature == null)
			{
				return;
			}

			response.AddSpaceFeature(new POCOSpaceFeature(efSpaceFeature.Id, efSpaceFeature.Name, efSpaceFeature.StudioId));

			this.StudioMapEFToPOCO(efSpaceFeature.Studio, response);
		}

		public virtual void SpaceXSpaceFeatureMapModelToEF(
			int id,
			SpaceXSpaceFeatureModel model,
			EFSpaceXSpaceFeature efSpaceXSpaceFeature)
		{
			efSpaceXSpaceFeature.SetProperties(
				id,
				model.SpaceFeatureId,
				model.SpaceId);
		}

		public virtual void SpaceXSpaceFeatureMapEFToPOCO(
			EFSpaceXSpaceFeature efSpaceXSpaceFeature,
			ApiResponse response)
		{
			if (efSpaceXSpaceFeature == null)
			{
				return;
			}

			response.AddSpaceXSpaceFeature(new POCOSpaceXSpaceFeature(efSpaceXSpaceFeature.Id, efSpaceXSpaceFeature.SpaceFeatureId, efSpaceXSpaceFeature.SpaceId));

			this.SpaceFeatureMapEFToPOCO(efSpaceXSpaceFeature.SpaceFeature, response);

			this.SpaceMapEFToPOCO(efSpaceXSpaceFeature.Space, response);
		}

		public virtual void StateMapModelToEF(
			int id,
			StateModel model,
			EFState efState)
		{
			efState.SetProperties(
				id,
				model.Name);
		}

		public virtual void StateMapEFToPOCO(
			EFState efState,
			ApiResponse response)
		{
			if (efState == null)
			{
				return;
			}

			response.AddState(new POCOState(efState.Id, efState.Name));
		}

		public virtual void StudentMapModelToEF(
			int id,
			StudentModel model,
			EFStudent efStudent)
		{
			efStudent.SetProperties(
				id,
				model.Birthday,
				model.Email,
				model.EmailRemindersEnabled,
				model.FamilyId,
				model.FirstName,
				model.IsAdult,
				model.LastName,
				model.Phone,
				model.SmsRemindersEnabled,
				model.StudioId);
		}

		public virtual void StudentMapEFToPOCO(
			EFStudent efStudent,
			ApiResponse response)
		{
			if (efStudent == null)
			{
				return;
			}

			response.AddStudent(new POCOStudent(efStudent.Birthday, efStudent.Email, efStudent.EmailRemindersEnabled, efStudent.FamilyId, efStudent.FirstName, efStudent.Id, efStudent.IsAdult, efStudent.LastName, efStudent.Phone, efStudent.SmsRemindersEnabled, efStudent.StudioId));

			this.FamilyMapEFToPOCO(efStudent.Family, response);

			this.StudioMapEFToPOCO(efStudent.Studio, response);
		}

		public virtual void StudentXFamilyMapModelToEF(
			int id,
			StudentXFamilyModel model,
			EFStudentXFamily efStudentXFamily)
		{
			efStudentXFamily.SetProperties(
				id,
				model.FamilyId,
				model.StudentId);
		}

		public virtual void StudentXFamilyMapEFToPOCO(
			EFStudentXFamily efStudentXFamily,
			ApiResponse response)
		{
			if (efStudentXFamily == null)
			{
				return;
			}

			response.AddStudentXFamily(new POCOStudentXFamily(efStudentXFamily.FamilyId, efStudentXFamily.Id, efStudentXFamily.StudentId));

			this.FamilyMapEFToPOCO(efStudentXFamily.Family, response);

			this.StudentMapEFToPOCO(efStudentXFamily.Student, response);
		}

		public virtual void StudioMapModelToEF(
			int id,
			StudioModel model,
			EFStudio efStudio)
		{
			efStudio.SetProperties(
				id,
				model.Address1,
				model.Address2,
				model.City,
				model.Name,
				model.StateId,
				model.Website,
				model.Zip);
		}

		public virtual void StudioMapEFToPOCO(
			EFStudio efStudio,
			ApiResponse response)
		{
			if (efStudio == null)
			{
				return;
			}

			response.AddStudio(new POCOStudio(efStudio.Address1, efStudio.Address2, efStudio.City, efStudio.Id, efStudio.Name, efStudio.StateId, efStudio.Website, efStudio.Zip));

			this.StateMapEFToPOCO(efStudio.State, response);
		}

		public virtual void TeacherMapModelToEF(
			int id,
			TeacherModel model,
			EFTeacher efTeacher)
		{
			efTeacher.SetProperties(
				id,
				model.Birthday,
				model.Email,
				model.FirstName,
				model.LastName,
				model.Phone,
				model.StudioId);
		}

		public virtual void TeacherMapEFToPOCO(
			EFTeacher efTeacher,
			ApiResponse response)
		{
			if (efTeacher == null)
			{
				return;
			}

			response.AddTeacher(new POCOTeacher(efTeacher.Birthday, efTeacher.Email, efTeacher.FirstName, efTeacher.Id, efTeacher.LastName, efTeacher.Phone, efTeacher.StudioId));

			this.StudioMapEFToPOCO(efTeacher.Studio, response);
		}

		public virtual void TeacherSkillMapModelToEF(
			int id,
			TeacherSkillModel model,
			EFTeacherSkill efTeacherSkill)
		{
			efTeacherSkill.SetProperties(
				id,
				model.Name,
				model.StudioId);
		}

		public virtual void TeacherSkillMapEFToPOCO(
			EFTeacherSkill efTeacherSkill,
			ApiResponse response)
		{
			if (efTeacherSkill == null)
			{
				return;
			}

			response.AddTeacherSkill(new POCOTeacherSkill(efTeacherSkill.Id, efTeacherSkill.Name, efTeacherSkill.StudioId));

			this.StudioMapEFToPOCO(efTeacherSkill.Studio, response);
		}

		public virtual void TeacherXTeacherSkillMapModelToEF(
			int id,
			TeacherXTeacherSkillModel model,
			EFTeacherXTeacherSkill efTeacherXTeacherSkill)
		{
			efTeacherXTeacherSkill.SetProperties(
				id,
				model.TeacherId,
				model.TeacherSkillId);
		}

		public virtual void TeacherXTeacherSkillMapEFToPOCO(
			EFTeacherXTeacherSkill efTeacherXTeacherSkill,
			ApiResponse response)
		{
			if (efTeacherXTeacherSkill == null)
			{
				return;
			}

			response.AddTeacherXTeacherSkill(new POCOTeacherXTeacherSkill(efTeacherXTeacherSkill.Id, efTeacherXTeacherSkill.TeacherId, efTeacherXTeacherSkill.TeacherSkillId));

			this.TeacherMapEFToPOCO(efTeacherXTeacherSkill.Teacher, response);

			this.TeacherSkillMapEFToPOCO(efTeacherXTeacherSkill.TeacherSkill, response);
		}
	}
}

/*<Codenesium>
    <Hash>a4a14f388d886c6c02a49ebfb2275da9</Hash>
</Codenesium>*/