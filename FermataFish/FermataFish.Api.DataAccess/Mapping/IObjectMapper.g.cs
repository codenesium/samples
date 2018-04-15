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

		void AdminMapEFToPOCO(
			EFAdmin efAdmin,
			ApiResponse response);

		void FamilyMapModelToEF(
			int id,
			FamilyModel model,
			EFFamily efFamily);

		void FamilyMapEFToPOCO(
			EFFamily efFamily,
			ApiResponse response);

		void LessonMapModelToEF(
			int id,
			LessonModel model,
			EFLesson efLesson);

		void LessonMapEFToPOCO(
			EFLesson efLesson,
			ApiResponse response);

		void LessonStatusMapModelToEF(
			int id,
			LessonStatusModel model,
			EFLessonStatus efLessonStatus);

		void LessonStatusMapEFToPOCO(
			EFLessonStatus efLessonStatus,
			ApiResponse response);

		void LessonXStudentMapModelToEF(
			int id,
			LessonXStudentModel model,
			EFLessonXStudent efLessonXStudent);

		void LessonXStudentMapEFToPOCO(
			EFLessonXStudent efLessonXStudent,
			ApiResponse response);

		void LessonXTeacherMapModelToEF(
			int id,
			LessonXTeacherModel model,
			EFLessonXTeacher efLessonXTeacher);

		void LessonXTeacherMapEFToPOCO(
			EFLessonXTeacher efLessonXTeacher,
			ApiResponse response);

		void RateMapModelToEF(
			int id,
			RateModel model,
			EFRate efRate);

		void RateMapEFToPOCO(
			EFRate efRate,
			ApiResponse response);

		void SpaceMapModelToEF(
			int id,
			SpaceModel model,
			EFSpace efSpace);

		void SpaceMapEFToPOCO(
			EFSpace efSpace,
			ApiResponse response);

		void SpaceFeatureMapModelToEF(
			int id,
			SpaceFeatureModel model,
			EFSpaceFeature efSpaceFeature);

		void SpaceFeatureMapEFToPOCO(
			EFSpaceFeature efSpaceFeature,
			ApiResponse response);

		void SpaceXSpaceFeatureMapModelToEF(
			int id,
			SpaceXSpaceFeatureModel model,
			EFSpaceXSpaceFeature efSpaceXSpaceFeature);

		void SpaceXSpaceFeatureMapEFToPOCO(
			EFSpaceXSpaceFeature efSpaceXSpaceFeature,
			ApiResponse response);

		void StateMapModelToEF(
			int id,
			StateModel model,
			EFState efState);

		void StateMapEFToPOCO(
			EFState efState,
			ApiResponse response);

		void StudentMapModelToEF(
			int id,
			StudentModel model,
			EFStudent efStudent);

		void StudentMapEFToPOCO(
			EFStudent efStudent,
			ApiResponse response);

		void StudentXFamilyMapModelToEF(
			int id,
			StudentXFamilyModel model,
			EFStudentXFamily efStudentXFamily);

		void StudentXFamilyMapEFToPOCO(
			EFStudentXFamily efStudentXFamily,
			ApiResponse response);

		void StudioMapModelToEF(
			int id,
			StudioModel model,
			EFStudio efStudio);

		void StudioMapEFToPOCO(
			EFStudio efStudio,
			ApiResponse response);

		void TeacherMapModelToEF(
			int id,
			TeacherModel model,
			EFTeacher efTeacher);

		void TeacherMapEFToPOCO(
			EFTeacher efTeacher,
			ApiResponse response);

		void TeacherSkillMapModelToEF(
			int id,
			TeacherSkillModel model,
			EFTeacherSkill efTeacherSkill);

		void TeacherSkillMapEFToPOCO(
			EFTeacherSkill efTeacherSkill,
			ApiResponse response);

		void TeacherXTeacherSkillMapModelToEF(
			int id,
			TeacherXTeacherSkillModel model,
			EFTeacherXTeacherSkill efTeacherXTeacherSkill);

		void TeacherXTeacherSkillMapEFToPOCO(
			EFTeacherXTeacherSkill efTeacherXTeacherSkill,
			ApiResponse response);
	}
}

/*<Codenesium>
    <Hash>ad4863c843e755630bc3c1790e85732e</Hash>
</Codenesium>*/