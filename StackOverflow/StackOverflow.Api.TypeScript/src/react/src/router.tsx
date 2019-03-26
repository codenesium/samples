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
import { WrappedBadgesCreateComponent } from './components/badges/badgesCreateForm';
import { WrappedBadgesDetailComponent } from './components/badges/badgesDetailForm';
import { WrappedBadgesEditComponent } from './components/badges/badgesEditForm';
import { WrappedBadgesSearchComponent } from './components/badges/badgesSearchForm';
import { WrappedCommentsCreateComponent } from './components/comments/commentsCreateForm';
import { WrappedCommentsDetailComponent } from './components/comments/commentsDetailForm';
import { WrappedCommentsEditComponent } from './components/comments/commentsEditForm';
import { WrappedCommentsSearchComponent } from './components/comments/commentsSearchForm';
import { WrappedLinkTypesCreateComponent } from './components/linkTypes/linkTypesCreateForm';
import { WrappedLinkTypesDetailComponent } from './components/linkTypes/linkTypesDetailForm';
import { WrappedLinkTypesEditComponent } from './components/linkTypes/linkTypesEditForm';
import { WrappedLinkTypesSearchComponent } from './components/linkTypes/linkTypesSearchForm';
import { WrappedPostHistoryCreateComponent } from './components/postHistory/postHistoryCreateForm';
import { WrappedPostHistoryDetailComponent } from './components/postHistory/postHistoryDetailForm';
import { WrappedPostHistoryEditComponent } from './components/postHistory/postHistoryEditForm';
import { WrappedPostHistorySearchComponent } from './components/postHistory/postHistorySearchForm';
import { WrappedPostHistoryTypesCreateComponent } from './components/postHistoryTypes/postHistoryTypesCreateForm';
import { WrappedPostHistoryTypesDetailComponent } from './components/postHistoryTypes/postHistoryTypesDetailForm';
import { WrappedPostHistoryTypesEditComponent } from './components/postHistoryTypes/postHistoryTypesEditForm';
import { WrappedPostHistoryTypesSearchComponent } from './components/postHistoryTypes/postHistoryTypesSearchForm';
import { WrappedPostLinksCreateComponent } from './components/postLinks/postLinksCreateForm';
import { WrappedPostLinksDetailComponent } from './components/postLinks/postLinksDetailForm';
import { WrappedPostLinksEditComponent } from './components/postLinks/postLinksEditForm';
import { WrappedPostLinksSearchComponent } from './components/postLinks/postLinksSearchForm';
import { WrappedPostsCreateComponent } from './components/posts/postsCreateForm';
import { WrappedPostsDetailComponent } from './components/posts/postsDetailForm';
import { WrappedPostsEditComponent } from './components/posts/postsEditForm';
import { WrappedPostsSearchComponent } from './components/posts/postsSearchForm';
import { WrappedPostTypesCreateComponent } from './components/postTypes/postTypesCreateForm';
import { WrappedPostTypesDetailComponent } from './components/postTypes/postTypesDetailForm';
import { WrappedPostTypesEditComponent } from './components/postTypes/postTypesEditForm';
import { WrappedPostTypesSearchComponent } from './components/postTypes/postTypesSearchForm';
import { WrappedTagsCreateComponent } from './components/tags/tagsCreateForm';
import { WrappedTagsDetailComponent } from './components/tags/tagsDetailForm';
import { WrappedTagsEditComponent } from './components/tags/tagsEditForm';
import { WrappedTagsSearchComponent } from './components/tags/tagsSearchForm';
import { WrappedUsersCreateComponent } from './components/users/usersCreateForm';
import { WrappedUsersDetailComponent } from './components/users/usersDetailForm';
import { WrappedUsersEditComponent } from './components/users/usersEditForm';
import { WrappedUsersSearchComponent } from './components/users/usersSearchForm';
import { WrappedVotesCreateComponent } from './components/votes/votesCreateForm';
import { WrappedVotesDetailComponent } from './components/votes/votesDetailForm';
import { WrappedVotesEditComponent } from './components/votes/votesEditForm';
import { WrappedVotesSearchComponent } from './components/votes/votesSearchForm';
import { WrappedVoteTypesCreateComponent } from './components/voteTypes/voteTypesCreateForm';
import { WrappedVoteTypesDetailComponent } from './components/voteTypes/voteTypesDetailForm';
import { WrappedVoteTypesEditComponent } from './components/voteTypes/voteTypesEditForm';
import { WrappedVoteTypesSearchComponent } from './components/voteTypes/voteTypesSearchForm';

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
          path="/"
          component={wrapperHeader(Dashboard, 'Dashboard')}
        />
        <Route
          path={ClientRoutes.Badges + '/create'}
          component={wrapperHeader(
            WrappedBadgesCreateComponent,
            'Badges Create'
          )}
        />
        <Route
          path={ClientRoutes.Badges + '/edit/:id'}
          component={wrapperHeader(WrappedBadgesEditComponent, 'Badges Edit')}
        />
        <Route
          path={ClientRoutes.Badges + '/:id'}
          component={wrapperHeader(
            WrappedBadgesDetailComponent,
            'Badges Detail'
          )}
        />
        <Route
          path={ClientRoutes.Badges}
          component={wrapperHeader(
            WrappedBadgesSearchComponent,
            'Badges Search'
          )}
        />
        <Route
          path={ClientRoutes.Comments + '/create'}
          component={wrapperHeader(
            WrappedCommentsCreateComponent,
            'Comments Create'
          )}
        />
        <Route
          path={ClientRoutes.Comments + '/edit/:id'}
          component={wrapperHeader(
            WrappedCommentsEditComponent,
            'Comments Edit'
          )}
        />
        <Route
          path={ClientRoutes.Comments + '/:id'}
          component={wrapperHeader(
            WrappedCommentsDetailComponent,
            'Comments Detail'
          )}
        />
        <Route
          path={ClientRoutes.Comments}
          component={wrapperHeader(
            WrappedCommentsSearchComponent,
            'Comments Search'
          )}
        />
        <Route
          path={ClientRoutes.LinkTypes + '/create'}
          component={wrapperHeader(
            WrappedLinkTypesCreateComponent,
            'Link Types Create'
          )}
        />
        <Route
          path={ClientRoutes.LinkTypes + '/edit/:id'}
          component={wrapperHeader(
            WrappedLinkTypesEditComponent,
            'Link Types Edit'
          )}
        />
        <Route
          path={ClientRoutes.LinkTypes + '/:id'}
          component={wrapperHeader(
            WrappedLinkTypesDetailComponent,
            'Link Types Detail'
          )}
        />
        <Route
          path={ClientRoutes.LinkTypes}
          component={wrapperHeader(
            WrappedLinkTypesSearchComponent,
            'Link Types Search'
          )}
        />
        <Route
          path={ClientRoutes.PostHistory + '/create'}
          component={wrapperHeader(
            WrappedPostHistoryCreateComponent,
            'Post History Create'
          )}
        />
        <Route
          path={ClientRoutes.PostHistory + '/edit/:id'}
          component={wrapperHeader(
            WrappedPostHistoryEditComponent,
            'Post History Edit'
          )}
        />
        <Route
          path={ClientRoutes.PostHistory + '/:id'}
          component={wrapperHeader(
            WrappedPostHistoryDetailComponent,
            'Post History Detail'
          )}
        />
        <Route
          path={ClientRoutes.PostHistory}
          component={wrapperHeader(
            WrappedPostHistorySearchComponent,
            'Post History Search'
          )}
        />
        <Route
          path={ClientRoutes.PostHistoryTypes + '/create'}
          component={wrapperHeader(
            WrappedPostHistoryTypesCreateComponent,
            'Post History Types Create'
          )}
        />
        <Route
          path={ClientRoutes.PostHistoryTypes + '/edit/:id'}
          component={wrapperHeader(
            WrappedPostHistoryTypesEditComponent,
            'Post History Types Edit'
          )}
        />
        <Route
          path={ClientRoutes.PostHistoryTypes + '/:id'}
          component={wrapperHeader(
            WrappedPostHistoryTypesDetailComponent,
            'Post History Types Detail'
          )}
        />
        <Route
          path={ClientRoutes.PostHistoryTypes}
          component={wrapperHeader(
            WrappedPostHistoryTypesSearchComponent,
            'Post History Types Search'
          )}
        />
        <Route
          path={ClientRoutes.PostLinks + '/create'}
          component={wrapperHeader(
            WrappedPostLinksCreateComponent,
            'Post Links Create'
          )}
        />
        <Route
          path={ClientRoutes.PostLinks + '/edit/:id'}
          component={wrapperHeader(
            WrappedPostLinksEditComponent,
            'Post Links Edit'
          )}
        />
        <Route
          path={ClientRoutes.PostLinks + '/:id'}
          component={wrapperHeader(
            WrappedPostLinksDetailComponent,
            'Post Links Detail'
          )}
        />
        <Route
          path={ClientRoutes.PostLinks}
          component={wrapperHeader(
            WrappedPostLinksSearchComponent,
            'Post Links Search'
          )}
        />
        <Route
          path={ClientRoutes.Posts + '/create'}
          component={wrapperHeader(WrappedPostsCreateComponent, 'Posts Create')}
        />
        <Route
          path={ClientRoutes.Posts + '/edit/:id'}
          component={wrapperHeader(WrappedPostsEditComponent, 'Posts Edit')}
        />
        <Route
          path={ClientRoutes.Posts + '/:id'}
          component={wrapperHeader(WrappedPostsDetailComponent, 'Posts Detail')}
        />
        <Route
          path={ClientRoutes.Posts}
          component={wrapperHeader(WrappedPostsSearchComponent, 'Posts Search')}
        />
        <Route
          path={ClientRoutes.PostTypes + '/create'}
          component={wrapperHeader(
            WrappedPostTypesCreateComponent,
            'Post Types Create'
          )}
        />
        <Route
          path={ClientRoutes.PostTypes + '/edit/:id'}
          component={wrapperHeader(
            WrappedPostTypesEditComponent,
            'Post Types Edit'
          )}
        />
        <Route
          path={ClientRoutes.PostTypes + '/:id'}
          component={wrapperHeader(
            WrappedPostTypesDetailComponent,
            'Post Types Detail'
          )}
        />
        <Route
          path={ClientRoutes.PostTypes}
          component={wrapperHeader(
            WrappedPostTypesSearchComponent,
            'Post Types Search'
          )}
        />
        <Route
          path={ClientRoutes.Tags + '/create'}
          component={wrapperHeader(WrappedTagsCreateComponent, 'Tags Create')}
        />
        <Route
          path={ClientRoutes.Tags + '/edit/:id'}
          component={wrapperHeader(WrappedTagsEditComponent, 'Tags Edit')}
        />
        <Route
          path={ClientRoutes.Tags + '/:id'}
          component={wrapperHeader(WrappedTagsDetailComponent, 'Tags Detail')}
        />
        <Route
          path={ClientRoutes.Tags}
          component={wrapperHeader(WrappedTagsSearchComponent, 'Tags Search')}
        />
        <Route
          path={ClientRoutes.Users + '/create'}
          component={wrapperHeader(WrappedUsersCreateComponent, 'Users Create')}
        />
        <Route
          path={ClientRoutes.Users + '/edit/:id'}
          component={wrapperHeader(WrappedUsersEditComponent, 'Users Edit')}
        />
        <Route
          path={ClientRoutes.Users + '/:id'}
          component={wrapperHeader(WrappedUsersDetailComponent, 'Users Detail')}
        />
        <Route
          path={ClientRoutes.Users}
          component={wrapperHeader(WrappedUsersSearchComponent, 'Users Search')}
        />
        <Route
          path={ClientRoutes.Votes + '/create'}
          component={wrapperHeader(WrappedVotesCreateComponent, 'Votes Create')}
        />
        <Route
          path={ClientRoutes.Votes + '/edit/:id'}
          component={wrapperHeader(WrappedVotesEditComponent, 'Votes Edit')}
        />
        <Route
          path={ClientRoutes.Votes + '/:id'}
          component={wrapperHeader(WrappedVotesDetailComponent, 'Votes Detail')}
        />
        <Route
          path={ClientRoutes.Votes}
          component={wrapperHeader(WrappedVotesSearchComponent, 'Votes Search')}
        />
        <Route
          path={ClientRoutes.VoteTypes + '/create'}
          component={wrapperHeader(
            WrappedVoteTypesCreateComponent,
            'Vote Types Create'
          )}
        />
        <Route
          path={ClientRoutes.VoteTypes + '/edit/:id'}
          component={wrapperHeader(
            WrappedVoteTypesEditComponent,
            'Vote Types Edit'
          )}
        />
        <Route
          path={ClientRoutes.VoteTypes + '/:id'}
          component={wrapperHeader(
            WrappedVoteTypesDetailComponent,
            'Vote Types Detail'
          )}
        />
        <Route
          path={ClientRoutes.VoteTypes}
          component={wrapperHeader(
            WrappedVoteTypesSearchComponent,
            'Vote Types Search'
          )}
        />
      </Switch>
    </BrowserRouter>
  );
};


/*<Codenesium>
    <Hash>651f21ccb65f6bfe35bfeb430f40626e</Hash>
</Codenesium>*/