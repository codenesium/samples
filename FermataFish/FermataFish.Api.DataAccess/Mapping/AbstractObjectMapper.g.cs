using System;
using Microsoft.EntityFrameworkCore;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.DataAccess
{
	public abstract class AbstractObjectMapper
	{
		public virtual void AdminMapModelToEF(
			int id,
			ApiAdminModel model,
			Admin efAdmin)
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

		public virtual POCOAdmin AdminMapEFToPOCO(
			Admin efAdmin)
		{
			if (efAdmin == null)
			{
				return null;
			}

			return new POCOAdmin(efAdmin.Birthday, efAdmin.Email, efAdmin.FirstName, efAdmin.Id, efAdmin.LastName, efAdmin.Phone, efAdmin.StudioId);
		}

		public virtual void FamilyMapModelToEF(
			int id,
			ApiFamilyModel model,
			Family efFamily)
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

		public virtual POCOFamily FamilyMapEFToPOCO(
			Family efFamily)
		{
			if (efFamily == null)
			{
				return null;
			}

			return new POCOFamily(efFamily.Id, efFamily.Notes, efFamily.PcEmail, efFamily.PcFirstName, efFamily.PcLastName, efFamily.PcPhone, efFamily.StudioId);
		}

		public virtual void LessonMapModelToEF(
			int id,
			ApiLessonModel model,
			Lesson efLesson)
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

		public virtual POCOLesson LessonMapEFToPOCO(
			Lesson efLesson)
		{
			if (efLesson == null)
			{
				return null;
			}

			return new POCOLesson(efLesson.ActualEndDate, efLesson.ActualStartDate, efLesson.BillAmount, efLesson.Id, efLesson.LessonStatusId, efLesson.ScheduledEndDate, efLesson.ScheduledStartDate, efLesson.StudentNotes, efLesson.StudioId, efLesson.TeacherNotes);
		}

		public virtual void LessonStatusMapModelToEF(
			int id,
			ApiLessonStatusModel model,
			LessonStatus efLessonStatus)
		{
			efLessonStatus.SetProperties(
				id,
				model.Name,
				model.StudioId);
		}

		public virtual POCOLessonStatus LessonStatusMapEFToPOCO(
			LessonStatus efLessonStatus)
		{
			if (efLessonStatus == null)
			{
				return null;
			}

			return new POCOLessonStatus(efLessonStatus.Id, efLessonStatus.Name, efLessonStatus.StudioId);
		}

		public virtual void LessonXStudentMapModelToEF(
			int id,
			ApiLessonXStudentModel model,
			LessonXStudent efLessonXStudent)
		{
			efLessonXStudent.SetProperties(
				id,
				model.LessonId,
				model.StudentId);
		}

		public virtual POCOLessonXStudent LessonXStudentMapEFToPOCO(
			LessonXStudent efLessonXStudent)
		{
			if (efLessonXStudent == null)
			{
				return null;
			}

			return new POCOLessonXStudent(efLessonXStudent.Id, efLessonXStudent.LessonId, efLessonXStudent.StudentId);
		}

		public virtual void LessonXTeacherMapModelToEF(
			int id,
			ApiLessonXTeacherModel model,
			LessonXTeacher efLessonXTeacher)
		{
			efLessonXTeacher.SetProperties(
				id,
				model.LessonId,
				model.StudentId);
		}

		public virtual POCOLessonXTeacher LessonXTeacherMapEFToPOCO(
			LessonXTeacher efLessonXTeacher)
		{
			if (efLessonXTeacher == null)
			{
				return null;
			}

			return new POCOLessonXTeacher(efLessonXTeacher.Id, efLessonXTeacher.LessonId, efLessonXTeacher.StudentId);
		}

		public virtual void RateMapModelToEF(
			int id,
			ApiRateModel model,
			Rate efRate)
		{
			efRate.SetProperties(
				id,
				model.AmountPerMinute,
				model.TeacherId,
				model.TeacherSkillId);
		}

		public virtual POCORate RateMapEFToPOCO(
			Rate efRate)
		{
			if (efRate == null)
			{
				return null;
			}

			return new POCORate(efRate.AmountPerMinute, efRate.Id, efRate.TeacherId, efRate.TeacherSkillId);
		}

		public virtual void SpaceMapModelToEF(
			int id,
			ApiSpaceModel model,
			Space efSpace)
		{
			efSpace.SetProperties(
				id,
				model.Description,
				model.Name,
				model.StudioId);
		}

		public virtual POCOSpace SpaceMapEFToPOCO(
			Space efSpace)
		{
			if (efSpace == null)
			{
				return null;
			}

			return new POCOSpace(efSpace.Description, efSpace.Id, efSpace.Name, efSpace.StudioId);
		}

		public virtual void SpaceFeatureMapModelToEF(
			int id,
			ApiSpaceFeatureModel model,
			SpaceFeature efSpaceFeature)
		{
			efSpaceFeature.SetProperties(
				id,
				model.Name,
				model.StudioId);
		}

		public virtual POCOSpaceFeature SpaceFeatureMapEFToPOCO(
			SpaceFeature efSpaceFeature)
		{
			if (efSpaceFeature == null)
			{
				return null;
			}

			return new POCOSpaceFeature(efSpaceFeature.Id, efSpaceFeature.Name, efSpaceFeature.StudioId);
		}

		public virtual void SpaceXSpaceFeatureMapModelToEF(
			int id,
			ApiSpaceXSpaceFeatureModel model,
			SpaceXSpaceFeature efSpaceXSpaceFeature)
		{
			efSpaceXSpaceFeature.SetProperties(
				id,
				model.SpaceFeatureId,
				model.SpaceId);
		}

		public virtual POCOSpaceXSpaceFeature SpaceXSpaceFeatureMapEFToPOCO(
			SpaceXSpaceFeature efSpaceXSpaceFeature)
		{
			if (efSpaceXSpaceFeature == null)
			{
				return null;
			}

			return new POCOSpaceXSpaceFeature(efSpaceXSpaceFeature.Id, efSpaceXSpaceFeature.SpaceFeatureId, efSpaceXSpaceFeature.SpaceId);
		}

		public virtual void StateMapModelToEF(
			int id,
			ApiStateModel model,
			State efState)
		{
			efState.SetProperties(
				id,
				model.Name);
		}

		public virtual POCOState StateMapEFToPOCO(
			State efState)
		{
			if (efState == null)
			{
				return null;
			}

			return new POCOState(efState.Id, efState.Name);
		}

		public virtual void StudentMapModelToEF(
			int id,
			ApiStudentModel model,
			Student efStudent)
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

		public virtual POCOStudent StudentMapEFToPOCO(
			Student efStudent)
		{
			if (efStudent == null)
			{
				return null;
			}

			return new POCOStudent(efStudent.Birthday, efStudent.Email, efStudent.EmailRemindersEnabled, efStudent.FamilyId, efStudent.FirstName, efStudent.Id, efStudent.IsAdult, efStudent.LastName, efStudent.Phone, efStudent.SmsRemindersEnabled, efStudent.StudioId);
		}

		public virtual void StudentXFamilyMapModelToEF(
			int id,
			ApiStudentXFamilyModel model,
			StudentXFamily efStudentXFamily)
		{
			efStudentXFamily.SetProperties(
				id,
				model.FamilyId,
				model.StudentId);
		}

		public virtual POCOStudentXFamily StudentXFamilyMapEFToPOCO(
			StudentXFamily efStudentXFamily)
		{
			if (efStudentXFamily == null)
			{
				return null;
			}

			return new POCOStudentXFamily(efStudentXFamily.FamilyId, efStudentXFamily.Id, efStudentXFamily.StudentId);
		}

		public virtual void StudioMapModelToEF(
			int id,
			ApiStudioModel model,
			Studio efStudio)
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

		public virtual POCOStudio StudioMapEFToPOCO(
			Studio efStudio)
		{
			if (efStudio == null)
			{
				return null;
			}

			return new POCOStudio(efStudio.Address1, efStudio.Address2, efStudio.City, efStudio.Id, efStudio.Name, efStudio.StateId, efStudio.Website, efStudio.Zip);
		}

		public virtual void TeacherMapModelToEF(
			int id,
			ApiTeacherModel model,
			Teacher efTeacher)
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

		public virtual POCOTeacher TeacherMapEFToPOCO(
			Teacher efTeacher)
		{
			if (efTeacher == null)
			{
				return null;
			}

			return new POCOTeacher(efTeacher.Birthday, efTeacher.Email, efTeacher.FirstName, efTeacher.Id, efTeacher.LastName, efTeacher.Phone, efTeacher.StudioId);
		}

		public virtual void TeacherSkillMapModelToEF(
			int id,
			ApiTeacherSkillModel model,
			TeacherSkill efTeacherSkill)
		{
			efTeacherSkill.SetProperties(
				id,
				model.Name,
				model.StudioId);
		}

		public virtual POCOTeacherSkill TeacherSkillMapEFToPOCO(
			TeacherSkill efTeacherSkill)
		{
			if (efTeacherSkill == null)
			{
				return null;
			}

			return new POCOTeacherSkill(efTeacherSkill.Id, efTeacherSkill.Name, efTeacherSkill.StudioId);
		}

		public virtual void TeacherXTeacherSkillMapModelToEF(
			int id,
			ApiTeacherXTeacherSkillModel model,
			TeacherXTeacherSkill efTeacherXTeacherSkill)
		{
			efTeacherXTeacherSkill.SetProperties(
				id,
				model.TeacherId,
				model.TeacherSkillId);
		}

		public virtual POCOTeacherXTeacherSkill TeacherXTeacherSkillMapEFToPOCO(
			TeacherXTeacherSkill efTeacherXTeacherSkill)
		{
			if (efTeacherXTeacherSkill == null)
			{
				return null;
			}

			return new POCOTeacherXTeacherSkill(efTeacherXTeacherSkill.Id, efTeacherXTeacherSkill.TeacherId, efTeacherXTeacherSkill.TeacherSkillId);
		}
	}
}

/*<Codenesium>
    <Hash>e6848fdd7a6d0036481f00b8d1411e63</Hash>
</Codenesium>*/