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
				model.Email,
				model.FirstName,
				model.LastName,
				model.Phone,
				model.Birthday,
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

			response.AddAdmin(new POCOAdmin(efAdmin.Id, efAdmin.Email, efAdmin.FirstName, efAdmin.LastName, efAdmin.Phone, efAdmin.Birthday, efAdmin.StudioId));

			this.StudioMapEFToPOCO(efAdmin.Studio, response);
		}

		public virtual void FamilyMapModelToEF(
			int id,
			FamilyModel model,
			EFFamily efFamily)
		{
			efFamily.SetProperties(
				id,
				model.PcFirstName,
				model.PcLastName,
				model.PcPhone,
				model.PcEmail,
				model.Notes,
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

			response.AddFamily(new POCOFamily(efFamily.Id, efFamily.PcFirstName, efFamily.PcLastName, efFamily.PcPhone, efFamily.PcEmail, efFamily.Notes, efFamily.StudioId));

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
				model.ScheduledStartDate,
				model.ScheduledEndDate,
				model.ActualStartDate,
				model.ActualEndDate,
				model.LessonStatusId,
				model.TeacherNotes,
				model.StudentNotes,
				model.BillAmount,
				model.StudioId);
		}

		public virtual void LessonMapEFToPOCO(
			EFLesson efLesson,
			ApiResponse response)
		{
			if (efLesson == null)
			{
				return;
			}

			response.AddLesson(new POCOLesson(efLesson.Id, efLesson.ScheduledStartDate, efLesson.ScheduledEndDate, efLesson.ActualStartDate, efLesson.ActualEndDate, efLesson.LessonStatusId, efLesson.TeacherNotes, efLesson.StudentNotes, efLesson.BillAmount, efLesson.StudioId));

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

			response.AddLessonStatus(new POCOLessonStatus(efLessonStatus.Name, efLessonStatus.Id, efLessonStatus.StudioId));

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

			response.AddLessonXStudent(new POCOLessonXStudent(efLessonXStudent.LessonId, efLessonXStudent.StudentId, efLessonXStudent.Id));

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
				model.TeacherSkillId,
				model.TeacherId);
		}

		public virtual void RateMapEFToPOCO(
			EFRate efRate,
			ApiResponse response)
		{
			if (efRate == null)
			{
				return;
			}

			response.AddRate(new POCORate(efRate.Id, efRate.AmountPerMinute, efRate.TeacherSkillId, efRate.TeacherId));

			this.TeacherSkillMapEFToPOCO(efRate.TeacherSkill, response);

			this.TeacherMapEFToPOCO(efRate.Teacher, response);
		}

		public virtual void SpaceMapModelToEF(
			int id,
			SpaceModel model,
			EFSpace efSpace)
		{
			efSpace.SetProperties(
				id,
				model.Name,
				model.Description,
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

			response.AddSpace(new POCOSpace(efSpace.Id, efSpace.Name, efSpace.Description, efSpace.StudioId));

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
				model.SpaceId,
				model.SpaceFeatureId);
		}

		public virtual void SpaceXSpaceFeatureMapEFToPOCO(
			EFSpaceXSpaceFeature efSpaceXSpaceFeature,
			ApiResponse response)
		{
			if (efSpaceXSpaceFeature == null)
			{
				return;
			}

			response.AddSpaceXSpaceFeature(new POCOSpaceXSpaceFeature(efSpaceXSpaceFeature.Id, efSpaceXSpaceFeature.SpaceId, efSpaceXSpaceFeature.SpaceFeatureId));

			this.SpaceMapEFToPOCO(efSpaceXSpaceFeature.Space, response);

			this.SpaceFeatureMapEFToPOCO(efSpaceXSpaceFeature.SpaceFeature, response);
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
				model.Email,
				model.FirstName,
				model.LastName,
				model.Phone,
				model.IsAdult,
				model.Birthday,
				model.FamilyId,
				model.StudioId,
				model.SmsRemindersEnabled,
				model.EmailRemindersEnabled);
		}

		public virtual void StudentMapEFToPOCO(
			EFStudent efStudent,
			ApiResponse response)
		{
			if (efStudent == null)
			{
				return;
			}

			response.AddStudent(new POCOStudent(efStudent.Id, efStudent.Email, efStudent.FirstName, efStudent.LastName, efStudent.Phone, efStudent.IsAdult, efStudent.Birthday, efStudent.FamilyId, efStudent.StudioId, efStudent.SmsRemindersEnabled, efStudent.EmailRemindersEnabled));

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
				model.StudentId,
				model.FamilyId);
		}

		public virtual void StudentXFamilyMapEFToPOCO(
			EFStudentXFamily efStudentXFamily,
			ApiResponse response)
		{
			if (efStudentXFamily == null)
			{
				return;
			}

			response.AddStudentXFamily(new POCOStudentXFamily(efStudentXFamily.Id, efStudentXFamily.StudentId, efStudentXFamily.FamilyId));

			this.StudentMapEFToPOCO(efStudentXFamily.Student, response);

			this.FamilyMapEFToPOCO(efStudentXFamily.Family, response);
		}

		public virtual void StudioMapModelToEF(
			int id,
			StudioModel model,
			EFStudio efStudio)
		{
			efStudio.SetProperties(
				id,
				model.Name,
				model.Website,
				model.Address1,
				model.Address2,
				model.City,
				model.StateId,
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

			response.AddStudio(new POCOStudio(efStudio.Id, efStudio.Name, efStudio.Website, efStudio.Address1, efStudio.Address2, efStudio.City, efStudio.StateId, efStudio.Zip));

			this.StateMapEFToPOCO(efStudio.State, response);
		}

		public virtual void TeacherMapModelToEF(
			int id,
			TeacherModel model,
			EFTeacher efTeacher)
		{
			efTeacher.SetProperties(
				id,
				model.FirstName,
				model.LastName,
				model.Email,
				model.Phone,
				model.Birthday,
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

			response.AddTeacher(new POCOTeacher(efTeacher.Id, efTeacher.FirstName, efTeacher.LastName, efTeacher.Email, efTeacher.Phone, efTeacher.Birthday, efTeacher.StudioId));

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
    <Hash>757572d61c9d7abeddcdf377234390c4</Hash>
</Codenesium>*/