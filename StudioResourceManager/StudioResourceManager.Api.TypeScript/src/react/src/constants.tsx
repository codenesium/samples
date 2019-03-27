export class Constants {
  static readonly BaseEndpoint = process.env.REACT_APP_API_URL;
  static readonly ApiEndpoint = Constants.BaseEndpoint + 'api/';
  static readonly ApiHealthEndpoint = Constants.ApiEndpoint + 'apiHealth';
  static readonly SwaggerEndpoint = Constants.BaseEndpoint + 'swagger';
  static readonly HostedBaseUrl =
    window.location.protocol + '//' + window.location.host;
  static readonly HostedSubDirectory =
    process.env.REACT_APP_HOST_SUBDIRECTORY == '/'
      ? ''
      : '/' + process.env.REACT_APP_HOST_SUBDIRECTORY;
  static readonly HostedUrl =
    Constants.HostedBaseUrl + Constants.HostedSubDirectory;
}

export class AuthClientRoutes {
  static readonly Login = '/login';
  static readonly Logout = '/logout';
  static readonly Register = '/register';
  static readonly ResetPassword = '/resetpassword';
  static readonly ConfirmRegistration = '/confirmregistration';
  static readonly ConfirmPasswordReset = '/confirmpasswordreset';
  static readonly ChangePassword = '/changepassword';
}

export class AuthApiRoutes {
  static readonly Login = 'auth/login';
  static readonly Register = 'auth/register';
  static readonly ResetPassword = 'auth/resetpassword';
  static readonly ConfirmRegistration = 'auth/confirmregistration';
  static readonly ConfirmPasswordReset = 'auth/confirmpasswordreset';
  static readonly ChangePassword = 'auth/changepassword';
}

export class ClientRoutes {
  static readonly Admins = '/admins';
  static readonly Events = '/events';
  static readonly EventStatus = '/eventstatus';
  static readonly EventStudents = '/eventstudents';
  static readonly EventTeachers = '/eventteachers';
  static readonly Families = '/families';
  static readonly Rates = '/rates';
  static readonly Spaces = '/spaces';
  static readonly SpaceFeatures = '/spacefeatures';
  static readonly SpaceSpaceFeatures = '/spacespacefeatures';
  static readonly Students = '/students';
  static readonly Studios = '/studios';
  static readonly Teachers = '/teachers';
  static readonly TeacherSkills = '/teacherskills';
  static readonly TeacherTeacherSkills = '/teacherteacherskills';
  static readonly Users = '/users';
}

export class ApiRoutes {
  static readonly Admins = 'admins';
  static readonly Events = 'events';
  static readonly EventStatus = 'eventstatus';
  static readonly EventStudents = 'eventstudents';
  static readonly EventTeachers = 'eventteachers';
  static readonly Families = 'families';
  static readonly Rates = 'rates';
  static readonly Spaces = 'spaces';
  static readonly SpaceFeatures = 'spacefeatures';
  static readonly SpaceSpaceFeatures = 'spacespacefeatures';
  static readonly Students = 'students';
  static readonly Studios = 'studios';
  static readonly Teachers = 'teachers';
  static readonly TeacherSkills = 'teacherskills';
  static readonly TeacherTeacherSkills = 'teacherteacherskills';
  static readonly Users = 'users';
}


/*<Codenesium>
    <Hash>d401bac691be2f97b88198518ff34cf4</Hash>
</Codenesium>*/