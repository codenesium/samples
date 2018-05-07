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

		public virtual POCOAdmin AdminMapEFToPOCO(
			EFAdmin efAdmin)
		{
			if (efAdmin == null)
			{
				return null;
			}

			return new POCOAdmin(efAdmin.Birthday, efAdmin.Email, efAdmin.FirstName, efAdmin.Id, efAdmin.LastName, efAdmin.Phone, efAdmin.StudioId);
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

		public virtual POCOFamily FamilyMapEFToPOCO(
			EFFamily efFamily)
		{
			if (efFamily == null)
			{
				return null;
			}

			return new POCOFamily(efFamily.Id, efFamily.Notes, efFamily.PcEmail, efFamily.PcFirstName, efFamily.PcLastName, efFamily.PcPhone, efFamily.StudioId);
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

		public virtual POCOLesson LessonMapEFToPOCO(
			EFLesson efLesson)
		{
			if (efLesson == null)
			{
				return null;
			}

			return new POCOLesson(efLesson.ActualEndDate, efLesson.ActualStartDate, efLesson.BillAmount, efLesson.Id, efLesson.LessonStatusId, efLesson.ScheduledEndDate, efLesson.ScheduledStartDate, efLesson.StudentNotes, efLesson.StudioId, efLesson.TeacherNotes);
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

		public virtual POCOLessonStatus LessonStatusMapEFToPOCO(
			EFLessonStatus efLessonStatus)
		{
			if (efLessonStatus == null)
			{
				return null;
			}

			return new POCOLessonStatus(efLessonStatus.Id, efLessonStatus.Name, efLessonStatus.StudioId);
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

		public virtual POCOLessonXStudent LessonXStudentMapEFToPOCO(
			EFLessonXStudent efLessonXStudent)
		{
			if (efLessonXStudent == null)
			{
				return null;
			}

			return new POCOLessonXStudent(efLessonXStudent.Id, efLessonXStudent.LessonId, efLessonXStudent.StudentId);
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

		public virtual POCOLessonXTeacher LessonXTeacherMapEFToPOCO(
			EFLessonXTeacher efLessonXTeacher)
		{
			if (efLessonXTeacher == null)
			{
				return null;
			}

			return new POCOLessonXTeacher(efLessonXTeacher.Id, efLessonXTeacher.LessonId, efLessonXTeacher.StudentId);
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

		public virtual POCORate RateMapEFToPOCO(
			EFRate efRate)
		{
			if (efRate == null)
			{
				return null;
			}

			return new POCORate(efRate.AmountPerMinute, efRate.Id, efRate.TeacherId, efRate.TeacherSkillId);
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

		public virtual POCOSpace SpaceMapEFToPOCO(
			EFSpace efSpace)
		{
			if (efSpace == null)
			{
				return null;
			}

			return new POCOSpace(efSpace.Description, efSpace.Id, efSpace.Name, efSpace.StudioId);
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

		public virtual POCOSpaceFeature SpaceFeatureMapEFToPOCO(
			EFSpaceFeature efSpaceFeature)
		{
			if (efSpaceFeature == null)
			{
				return null;
			}

			return new POCOSpaceFeature(efSpaceFeature.Id, efSpaceFeature.Name, efSpaceFeature.StudioId);
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

		public virtual POCOSpaceXSpaceFeature SpaceXSpaceFeatureMapEFToPOCO(
			EFSpaceXSpaceFeature efSpaceXSpaceFeature)
		{
			if (efSpaceXSpaceFeature == null)
			{
				return null;
			}

			return new POCOSpaceXSpaceFeature(efSpaceXSpaceFeature.Id, efSpaceXSpaceFeature.SpaceFeatureId, efSpaceXSpaceFeature.SpaceId);
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

		public virtual POCOState StateMapEFToPOCO(
			EFState efState)
		{
			if (efState == null)
			{
				return null;
			}

			return new POCOState(efState.Id, efState.Name);
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

		public virtual POCOStudent StudentMapEFToPOCO(
			EFStudent efStudent)
		{
			if (efStudent == null)
			{
				return null;
			}

			return new POCOStudent(efStudent.Birthday, efStudent.Email, efStudent.EmailRemindersEnabled, efStudent.FamilyId, efStudent.FirstName, efStudent.Id, efStudent.IsAdult, efStudent.LastName, efStudent.Phone, efStudent.SmsRemindersEnabled, efStudent.StudioId);
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

		public virtual POCOStudentXFamily StudentXFamilyMapEFToPOCO(
			EFStudentXFamily efStudentXFamily)
		{
			if (efStudentXFamily == null)
			{
				return null;
			}

			return new POCOStudentXFamily(efStudentXFamily.FamilyId, efStudentXFamily.Id, efStudentXFamily.StudentId);
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

		public virtual POCOStudio StudioMapEFToPOCO(
			EFStudio efStudio)
		{
			if (efStudio == null)
			{
				return null;
			}

			return new POCOStudio(efStudio.Address1, efStudio.Address2, efStudio.City, efStudio.Id, efStudio.Name, efStudio.StateId, efStudio.Website, efStudio.Zip);
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

		public virtual POCOTeacher TeacherMapEFToPOCO(
			EFTeacher efTeacher)
		{
			if (efTeacher == null)
			{
				return null;
			}

			return new POCOTeacher(efTeacher.Birthday, efTeacher.Email, efTeacher.FirstName, efTeacher.Id, efTeacher.LastName, efTeacher.Phone, efTeacher.StudioId);
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

		public virtual POCOTeacherSkill TeacherSkillMapEFToPOCO(
			EFTeacherSkill efTeacherSkill)
		{
			if (efTeacherSkill == null)
			{
				return null;
			}

			return new POCOTeacherSkill(efTeacherSkill.Id, efTeacherSkill.Name, efTeacherSkill.StudioId);
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

		public virtual POCOTeacherXTeacherSkill TeacherXTeacherSkillMapEFToPOCO(
			EFTeacherXTeacherSkill efTeacherXTeacherSkill)
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
    <Hash>3c24d4095c50b0e48bba3c2583570f61</Hash>
</Codenesium>*/