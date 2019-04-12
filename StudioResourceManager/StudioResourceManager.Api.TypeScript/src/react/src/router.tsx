import * as React from 'react';
import { Route, Switch, match, BrowserRouter } from 'react-router-dom';
import Dashboard from './components/dashboard';
import { wrapperHeader } from './components/header';
import { wrapperAuthHeader } from './components/auth/authHeader';
import { AuthClientRoutes, ClientRoutes, Constants } from './constants';
import { WrappedLoginComponent } from './components/auth/loginForm';
import { WrappedLogoutComponent } from './components/auth/logoutForm';
import { WrappedRegisterComponent } from './components/auth/registerForm';
import { WrappedResetPasswordComponent } from './components/auth/resetPasswordForm';
import { WrappedConfirmPasswordResetComponent } from './components/auth/confirmPasswordResetForm';
import { WrappedConfirmRegistrationComponent } from './components/auth/confirmRegistrationForm';
import { WrappedChangePasswordComponent } from './components/auth/changePasswordForm';
import { WrappedChangeEmailComponent } from './components/auth/changeEmailForm';
import { WrappedConfirmChangeEmailComponent } from './components/auth/confirmChangeEmailForm';
import { WrappedAdminCreateComponent } from './components/admin/adminCreateForm';
import { WrappedAdminDetailComponent } from './components/admin/adminDetailForm';
import { WrappedAdminEditComponent } from './components/admin/adminEditForm';
import { WrappedAdminSearchComponent } from './components/admin/adminSearchForm';
import { WrappedEventCreateComponent } from './components/event/eventCreateForm';
import { WrappedEventDetailComponent } from './components/event/eventDetailForm';
import { WrappedEventEditComponent } from './components/event/eventEditForm';
import { WrappedEventSearchComponent } from './components/event/eventSearchForm';
import { WrappedEventStatusCreateComponent } from './components/eventStatus/eventStatusCreateForm';
import { WrappedEventStatusDetailComponent } from './components/eventStatus/eventStatusDetailForm';
import { WrappedEventStatusEditComponent } from './components/eventStatus/eventStatusEditForm';
import { WrappedEventStatusSearchComponent } from './components/eventStatus/eventStatusSearchForm';
import { WrappedEventStudentCreateComponent } from './components/eventStudent/eventStudentCreateForm';
import { WrappedEventStudentDetailComponent } from './components/eventStudent/eventStudentDetailForm';
import { WrappedEventStudentEditComponent } from './components/eventStudent/eventStudentEditForm';
import { WrappedEventStudentSearchComponent } from './components/eventStudent/eventStudentSearchForm';
import { WrappedEventTeacherCreateComponent } from './components/eventTeacher/eventTeacherCreateForm';
import { WrappedEventTeacherDetailComponent } from './components/eventTeacher/eventTeacherDetailForm';
import { WrappedEventTeacherEditComponent } from './components/eventTeacher/eventTeacherEditForm';
import { WrappedEventTeacherSearchComponent } from './components/eventTeacher/eventTeacherSearchForm';
import { WrappedFamilyCreateComponent } from './components/family/familyCreateForm';
import { WrappedFamilyDetailComponent } from './components/family/familyDetailForm';
import { WrappedFamilyEditComponent } from './components/family/familyEditForm';
import { WrappedFamilySearchComponent } from './components/family/familySearchForm';
import { WrappedRateCreateComponent } from './components/rate/rateCreateForm';
import { WrappedRateDetailComponent } from './components/rate/rateDetailForm';
import { WrappedRateEditComponent } from './components/rate/rateEditForm';
import { WrappedRateSearchComponent } from './components/rate/rateSearchForm';
import { WrappedSpaceCreateComponent } from './components/space/spaceCreateForm';
import { WrappedSpaceDetailComponent } from './components/space/spaceDetailForm';
import { WrappedSpaceEditComponent } from './components/space/spaceEditForm';
import { WrappedSpaceSearchComponent } from './components/space/spaceSearchForm';
import { WrappedSpaceFeatureCreateComponent } from './components/spaceFeature/spaceFeatureCreateForm';
import { WrappedSpaceFeatureDetailComponent } from './components/spaceFeature/spaceFeatureDetailForm';
import { WrappedSpaceFeatureEditComponent } from './components/spaceFeature/spaceFeatureEditForm';
import { WrappedSpaceFeatureSearchComponent } from './components/spaceFeature/spaceFeatureSearchForm';
import { WrappedSpaceSpaceFeatureCreateComponent } from './components/spaceSpaceFeature/spaceSpaceFeatureCreateForm';
import { WrappedSpaceSpaceFeatureDetailComponent } from './components/spaceSpaceFeature/spaceSpaceFeatureDetailForm';
import { WrappedSpaceSpaceFeatureEditComponent } from './components/spaceSpaceFeature/spaceSpaceFeatureEditForm';
import { WrappedSpaceSpaceFeatureSearchComponent } from './components/spaceSpaceFeature/spaceSpaceFeatureSearchForm';
import { WrappedStudentCreateComponent } from './components/student/studentCreateForm';
import { WrappedStudentDetailComponent } from './components/student/studentDetailForm';
import { WrappedStudentEditComponent } from './components/student/studentEditForm';
import { WrappedStudentSearchComponent } from './components/student/studentSearchForm';
import { WrappedStudioCreateComponent } from './components/studio/studioCreateForm';
import { WrappedStudioDetailComponent } from './components/studio/studioDetailForm';
import { WrappedStudioEditComponent } from './components/studio/studioEditForm';
import { WrappedStudioSearchComponent } from './components/studio/studioSearchForm';
import { WrappedTeacherCreateComponent } from './components/teacher/teacherCreateForm';
import { WrappedTeacherDetailComponent } from './components/teacher/teacherDetailForm';
import { WrappedTeacherEditComponent } from './components/teacher/teacherEditForm';
import { WrappedTeacherSearchComponent } from './components/teacher/teacherSearchForm';
import { WrappedTeacherSkillCreateComponent } from './components/teacherSkill/teacherSkillCreateForm';
import { WrappedTeacherSkillDetailComponent } from './components/teacherSkill/teacherSkillDetailForm';
import { WrappedTeacherSkillEditComponent } from './components/teacherSkill/teacherSkillEditForm';
import { WrappedTeacherSkillSearchComponent } from './components/teacherSkill/teacherSkillSearchForm';
import { WrappedTeacherTeacherSkillCreateComponent } from './components/teacherTeacherSkill/teacherTeacherSkillCreateForm';
import { WrappedTeacherTeacherSkillDetailComponent } from './components/teacherTeacherSkill/teacherTeacherSkillDetailForm';
import { WrappedTeacherTeacherSkillEditComponent } from './components/teacherTeacherSkill/teacherTeacherSkillEditForm';
import { WrappedTeacherTeacherSkillSearchComponent } from './components/teacherTeacherSkill/teacherTeacherSkillSearchForm';
import { WrappedUserCreateComponent } from './components/user/userCreateForm';
import { WrappedUserDetailComponent } from './components/user/userDetailForm';
import { WrappedUserEditComponent } from './components/user/userEditForm';
import { WrappedUserSearchComponent } from './components/user/userSearchForm';

export const AppRouter: React.StatelessComponent<{}> = () => {
  return (
    <BrowserRouter basename={Constants.HostedSubDirectory}>
      <Switch>
        <Route
          exact
          path={AuthClientRoutes.ConfirmPasswordReset + '/:id/:token'}
          component={wrapperAuthHeader(
            WrappedConfirmPasswordResetComponent,
            'Confirm Password Reset'
          )}
        />
        <Route
          exact
          path={AuthClientRoutes.ConfirmRegistration + '/:id/:token'}
          component={wrapperAuthHeader(
            WrappedConfirmRegistrationComponent,
            'Confirm Registration'
          )}
        />
        <Route
          exact
          path={AuthClientRoutes.Login}
          component={wrapperAuthHeader(WrappedLoginComponent, 'Login')}
        />
        <Route
          exact
          path={AuthClientRoutes.Logout}
          component={wrapperAuthHeader(WrappedLogoutComponent, 'Logout')}
        />
        <Route
          exact
          path={AuthClientRoutes.Register}
          component={wrapperAuthHeader(WrappedRegisterComponent, 'Register')}
        />
        <Route
          exact
          path={AuthClientRoutes.ResetPassword}
          component={wrapperAuthHeader(
            WrappedResetPasswordComponent,
            'Reset Password'
          )}
        />
        <Route
          exact
          path={AuthClientRoutes.ChangePassword}
          component={wrapperHeader(
            WrappedChangePasswordComponent,
            'Change Password'
          )}
        />
        <Route
          exact
          path={AuthClientRoutes.ChangeEmail}
          component={wrapperHeader(WrappedChangeEmailComponent, 'Change Email')}
        />
        <Route
          exact
          path={AuthClientRoutes.ConfirmChangeEmail + '/:id/:token'}
          component={wrapperAuthHeader(
            WrappedConfirmChangeEmailComponent,
            'Confirm Email Change'
          )}
        />
        <Route
          exact
          path="/"
          component={wrapperHeader(Dashboard, 'Dashboard')}
        />
        <Route
          path={ClientRoutes.Admins + '/create'}
          component={wrapperHeader(
            WrappedAdminCreateComponent,
            'Admins Create'
          )}
        />
        <Route
          path={ClientRoutes.Admins + '/edit/:id'}
          component={wrapperHeader(WrappedAdminEditComponent, 'Admins Edit')}
        />
        <Route
          path={ClientRoutes.Admins + '/:id'}
          component={wrapperHeader(
            WrappedAdminDetailComponent,
            'Admins Detail'
          )}
        />
        <Route
          path={ClientRoutes.Admins}
          component={wrapperHeader(
            WrappedAdminSearchComponent,
            'Admins Search'
          )}
        />
        <Route
          path={ClientRoutes.Events + '/create'}
          component={wrapperHeader(
            WrappedEventCreateComponent,
            'Events Create'
          )}
        />
        <Route
          path={ClientRoutes.Events + '/edit/:id'}
          component={wrapperHeader(WrappedEventEditComponent, 'Events Edit')}
        />
        <Route
          path={ClientRoutes.Events + '/:id'}
          component={wrapperHeader(
            WrappedEventDetailComponent,
            'Events Detail'
          )}
        />
        <Route
          path={ClientRoutes.Events}
          component={wrapperHeader(
            WrappedEventSearchComponent,
            'Events Search'
          )}
        />
        <Route
          path={ClientRoutes.EventStatus + '/create'}
          component={wrapperHeader(
            WrappedEventStatusCreateComponent,
            'Event Status Create'
          )}
        />
        <Route
          path={ClientRoutes.EventStatus + '/edit/:id'}
          component={wrapperHeader(
            WrappedEventStatusEditComponent,
            'Event Status Edit'
          )}
        />
        <Route
          path={ClientRoutes.EventStatus + '/:id'}
          component={wrapperHeader(
            WrappedEventStatusDetailComponent,
            'Event Status Detail'
          )}
        />
        <Route
          path={ClientRoutes.EventStatus}
          component={wrapperHeader(
            WrappedEventStatusSearchComponent,
            'Event Status Search'
          )}
        />
        <Route
          path={ClientRoutes.EventStudents + '/create'}
          component={wrapperHeader(
            WrappedEventStudentCreateComponent,
            'Event Student Create'
          )}
        />
        <Route
          path={ClientRoutes.EventStudents + '/edit/:id'}
          component={wrapperHeader(
            WrappedEventStudentEditComponent,
            'Event Student Edit'
          )}
        />
        <Route
          path={ClientRoutes.EventStudents + '/:id'}
          component={wrapperHeader(
            WrappedEventStudentDetailComponent,
            'Event Student Detail'
          )}
        />
        <Route
          path={ClientRoutes.EventStudents}
          component={wrapperHeader(
            WrappedEventStudentSearchComponent,
            'Event Student Search'
          )}
        />
        <Route
          path={ClientRoutes.EventTeachers + '/create'}
          component={wrapperHeader(
            WrappedEventTeacherCreateComponent,
            'Event Teacher Create'
          )}
        />
        <Route
          path={ClientRoutes.EventTeachers + '/edit/:id'}
          component={wrapperHeader(
            WrappedEventTeacherEditComponent,
            'Event Teacher Edit'
          )}
        />
        <Route
          path={ClientRoutes.EventTeachers + '/:id'}
          component={wrapperHeader(
            WrappedEventTeacherDetailComponent,
            'Event Teacher Detail'
          )}
        />
        <Route
          path={ClientRoutes.EventTeachers}
          component={wrapperHeader(
            WrappedEventTeacherSearchComponent,
            'Event Teacher Search'
          )}
        />
        <Route
          path={ClientRoutes.Families + '/create'}
          component={wrapperHeader(
            WrappedFamilyCreateComponent,
            'Familes Create'
          )}
        />
        <Route
          path={ClientRoutes.Families + '/edit/:id'}
          component={wrapperHeader(WrappedFamilyEditComponent, 'Familes Edit')}
        />
        <Route
          path={ClientRoutes.Families + '/:id'}
          component={wrapperHeader(
            WrappedFamilyDetailComponent,
            'Familes Detail'
          )}
        />
        <Route
          path={ClientRoutes.Families}
          component={wrapperHeader(
            WrappedFamilySearchComponent,
            'Familes Search'
          )}
        />
        <Route
          path={ClientRoutes.Rates + '/create'}
          component={wrapperHeader(WrappedRateCreateComponent, 'Rates Create')}
        />
        <Route
          path={ClientRoutes.Rates + '/edit/:id'}
          component={wrapperHeader(WrappedRateEditComponent, 'Rates Edit')}
        />
        <Route
          path={ClientRoutes.Rates + '/:id'}
          component={wrapperHeader(WrappedRateDetailComponent, 'Rates Detail')}
        />
        <Route
          path={ClientRoutes.Rates}
          component={wrapperHeader(WrappedRateSearchComponent, 'Rates Search')}
        />
        <Route
          path={ClientRoutes.Spaces + '/create'}
          component={wrapperHeader(
            WrappedSpaceCreateComponent,
            'Spaces Create'
          )}
        />
        <Route
          path={ClientRoutes.Spaces + '/edit/:id'}
          component={wrapperHeader(WrappedSpaceEditComponent, 'Spaces Edit')}
        />
        <Route
          path={ClientRoutes.Spaces + '/:id'}
          component={wrapperHeader(
            WrappedSpaceDetailComponent,
            'Spaces Detail'
          )}
        />
        <Route
          path={ClientRoutes.Spaces}
          component={wrapperHeader(
            WrappedSpaceSearchComponent,
            'Spaces Search'
          )}
        />
        <Route
          path={ClientRoutes.SpaceFeatures + '/create'}
          component={wrapperHeader(
            WrappedSpaceFeatureCreateComponent,
            'Space Feature Create'
          )}
        />
        <Route
          path={ClientRoutes.SpaceFeatures + '/edit/:id'}
          component={wrapperHeader(
            WrappedSpaceFeatureEditComponent,
            'Space Feature Edit'
          )}
        />
        <Route
          path={ClientRoutes.SpaceFeatures + '/:id'}
          component={wrapperHeader(
            WrappedSpaceFeatureDetailComponent,
            'Space Feature Detail'
          )}
        />
        <Route
          path={ClientRoutes.SpaceFeatures}
          component={wrapperHeader(
            WrappedSpaceFeatureSearchComponent,
            'Space Feature Search'
          )}
        />
        <Route
          path={ClientRoutes.SpaceSpaceFeatures + '/create'}
          component={wrapperHeader(
            WrappedSpaceSpaceFeatureCreateComponent,
            'Space Space Feature Create'
          )}
        />
        <Route
          path={ClientRoutes.SpaceSpaceFeatures + '/edit/:id'}
          component={wrapperHeader(
            WrappedSpaceSpaceFeatureEditComponent,
            'Space Space Feature Edit'
          )}
        />
        <Route
          path={ClientRoutes.SpaceSpaceFeatures + '/:id'}
          component={wrapperHeader(
            WrappedSpaceSpaceFeatureDetailComponent,
            'Space Space Feature Detail'
          )}
        />
        <Route
          path={ClientRoutes.SpaceSpaceFeatures}
          component={wrapperHeader(
            WrappedSpaceSpaceFeatureSearchComponent,
            'Space Space Feature Search'
          )}
        />
        <Route
          path={ClientRoutes.Students + '/create'}
          component={wrapperHeader(
            WrappedStudentCreateComponent,
            'Students Create'
          )}
        />
        <Route
          path={ClientRoutes.Students + '/edit/:id'}
          component={wrapperHeader(
            WrappedStudentEditComponent,
            'Students Edit'
          )}
        />
        <Route
          path={ClientRoutes.Students + '/:id'}
          component={wrapperHeader(
            WrappedStudentDetailComponent,
            'Students Detail'
          )}
        />
        <Route
          path={ClientRoutes.Students}
          component={wrapperHeader(
            WrappedStudentSearchComponent,
            'Students Search'
          )}
        />
        <Route
          path={ClientRoutes.Studios + '/create'}
          component={wrapperHeader(
            WrappedStudioCreateComponent,
            'Studios Create'
          )}
        />
        <Route
          path={ClientRoutes.Studios + '/edit/:id'}
          component={wrapperHeader(WrappedStudioEditComponent, 'Studios Edit')}
        />
        <Route
          path={ClientRoutes.Studios + '/:id'}
          component={wrapperHeader(
            WrappedStudioDetailComponent,
            'Studios Detail'
          )}
        />
        <Route
          path={ClientRoutes.Studios}
          component={wrapperHeader(
            WrappedStudioSearchComponent,
            'Studios Search'
          )}
        />
        <Route
          path={ClientRoutes.Teachers + '/create'}
          component={wrapperHeader(
            WrappedTeacherCreateComponent,
            'Teachers Create'
          )}
        />
        <Route
          path={ClientRoutes.Teachers + '/edit/:id'}
          component={wrapperHeader(
            WrappedTeacherEditComponent,
            'Teachers Edit'
          )}
        />
        <Route
          path={ClientRoutes.Teachers + '/:id'}
          component={wrapperHeader(
            WrappedTeacherDetailComponent,
            'Teachers Detail'
          )}
        />
        <Route
          path={ClientRoutes.Teachers}
          component={wrapperHeader(
            WrappedTeacherSearchComponent,
            'Teachers Search'
          )}
        />
        <Route
          path={ClientRoutes.TeacherSkills + '/create'}
          component={wrapperHeader(
            WrappedTeacherSkillCreateComponent,
            'Teacher Skills Create'
          )}
        />
        <Route
          path={ClientRoutes.TeacherSkills + '/edit/:id'}
          component={wrapperHeader(
            WrappedTeacherSkillEditComponent,
            'Teacher Skills Edit'
          )}
        />
        <Route
          path={ClientRoutes.TeacherSkills + '/:id'}
          component={wrapperHeader(
            WrappedTeacherSkillDetailComponent,
            'Teacher Skills Detail'
          )}
        />
        <Route
          path={ClientRoutes.TeacherSkills}
          component={wrapperHeader(
            WrappedTeacherSkillSearchComponent,
            'Teacher Skills Search'
          )}
        />
        <Route
          path={ClientRoutes.TeacherTeacherSkills + '/create'}
          component={wrapperHeader(
            WrappedTeacherTeacherSkillCreateComponent,
            'Teacher Teacher Skill Create'
          )}
        />
        <Route
          path={ClientRoutes.TeacherTeacherSkills + '/edit/:id'}
          component={wrapperHeader(
            WrappedTeacherTeacherSkillEditComponent,
            'Teacher Teacher Skill Edit'
          )}
        />
        <Route
          path={ClientRoutes.TeacherTeacherSkills + '/:id'}
          component={wrapperHeader(
            WrappedTeacherTeacherSkillDetailComponent,
            'Teacher Teacher Skill Detail'
          )}
        />
        <Route
          path={ClientRoutes.TeacherTeacherSkills}
          component={wrapperHeader(
            WrappedTeacherTeacherSkillSearchComponent,
            'Teacher Teacher Skill Search'
          )}
        />
        <Route
          path={ClientRoutes.Users + '/create'}
          component={wrapperHeader(WrappedUserCreateComponent, 'Users Create')}
        />
        <Route
          path={ClientRoutes.Users + '/edit/:id'}
          component={wrapperHeader(WrappedUserEditComponent, 'Users Edit')}
        />
        <Route
          path={ClientRoutes.Users + '/:id'}
          component={wrapperHeader(WrappedUserDetailComponent, 'Users Detail')}
        />
        <Route
          path={ClientRoutes.Users}
          component={wrapperHeader(WrappedUserSearchComponent, 'Users Search')}
        />
        <Route render={() => <div>No handler for route found...</div>} />
      </Switch>
    </BrowserRouter>
  );
};


/*<Codenesium>
    <Hash>169fccff313cd010871da33b1a414c2e</Hash>
</Codenesium>*/