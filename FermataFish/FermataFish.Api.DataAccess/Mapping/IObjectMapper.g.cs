using System;
using Microsoft.EntityFrameworkCore;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.DataAccess
{
	public interface IObjectMapper
	{
		void AdminMapModelToEF(
			int id,
			AdminModel model,
			EFAdmin efAdmin);

		POCOAdmin AdminMapEFToPOCO(
			EFAdmin efAdmin);

		void FamilyMapModelToEF(
			int id,
			FamilyModel model,
			EFFamily efFamily);

		POCOFamily FamilyMapEFToPOCO(
			EFFamily efFamily);

		void LessonMapModelToEF(
			int id,
			LessonModel model,
			EFLesson efLesson);

		POCOLesson LessonMapEFToPOCO(
			EFLesson efLesson);

		void LessonStatusMapModelToEF(
			int id,
			LessonStatusModel model,
			EFLessonStatus efLessonStatus);

		POCOLessonStatus LessonStatusMapEFToPOCO(
			EFLessonStatus efLessonStatus);

		void LessonXStudentMapModelToEF(
			int id,
			LessonXStudentModel model,
			EFLessonXStudent efLessonXStudent);

		POCOLessonXStudent LessonXStudentMapEFToPOCO(
			EFLessonXStudent efLessonXStudent);

		void LessonXTeacherMapModelToEF(
			int id,
			LessonXTeacherModel model,
			EFLessonXTeacher efLessonXTeacher);

		POCOLessonXTeacher LessonXTeacherMapEFToPOCO(
			EFLessonXTeacher efLessonXTeacher);

		void RateMapModelToEF(
			int id,
			RateModel model,
			EFRate efRate);

		POCORate RateMapEFToPOCO(
			EFRate efRate);

		void SpaceMapModelToEF(
			int id,
			SpaceModel model,
			EFSpace efSpace);

		POCOSpace SpaceMapEFToPOCO(
			EFSpace efSpace);

		void SpaceFeatureMapModelToEF(
			int id,
			SpaceFeatureModel model,
			EFSpaceFeature efSpaceFeature);

		POCOSpaceFeature SpaceFeatureMapEFToPOCO(
			EFSpaceFeature efSpaceFeature);

		void SpaceXSpaceFeatureMapModelToEF(
			int id,
			SpaceXSpaceFeatureModel model,
			EFSpaceXSpaceFeature efSpaceXSpaceFeature);

		POCOSpaceXSpaceFeature SpaceXSpaceFeatureMapEFToPOCO(
			EFSpaceXSpaceFeature efSpaceXSpaceFeature);

		void StateMapModelToEF(
			int id,
			StateModel model,
			EFState efState);

		POCOState StateMapEFToPOCO(
			EFState efState);

		void StudentMapModelToEF(
			int id,
			StudentModel model,
			EFStudent efStudent);

		POCOStudent StudentMapEFToPOCO(
			EFStudent efStudent);

		void StudentXFamilyMapModelToEF(
			int id,
			StudentXFamilyModel model,
			EFStudentXFamily efStudentXFamily);

		POCOStudentXFamily StudentXFamilyMapEFToPOCO(
			EFStudentXFamily efStudentXFamily);

		void StudioMapModelToEF(
			int id,
			StudioModel model,
			EFStudio efStudio);

		POCOStudio StudioMapEFToPOCO(
			EFStudio efStudio);

		void TeacherMapModelToEF(
			int id,
			TeacherModel model,
			EFTeacher efTeacher);

		POCOTeacher TeacherMapEFToPOCO(
			EFTeacher efTeacher);

		void TeacherSkillMapModelToEF(
			int id,
			TeacherSkillModel model,
			EFTeacherSkill efTeacherSkill);

		POCOTeacherSkill TeacherSkillMapEFToPOCO(
			EFTeacherSkill efTeacherSkill);

		void TeacherXTeacherSkillMapModelToEF(
			int id,
			TeacherXTeacherSkillModel model,
			EFTeacherXTeacherSkill efTeacherXTeacherSkill);

		POCOTeacherXTeacherSkill TeacherXTeacherSkillMapEFToPOCO(
			EFTeacherXTeacherSkill efTeacherXTeacherSkill);
	}
}

/*<Codenesium>
    <Hash>ddb1728c57be6cc57a6e2e3bb0defb75</Hash>
</Codenesium>*/