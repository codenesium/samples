import * as React from 'react';
import { Route, Switch, match, BrowserRouter } from 'react-router-dom';
import Dashboard from './components/dashboard';
import { wrapperHeader } from './components/header';
import { ClientRoutes, Constants, AuthClientRoutes } from './constants'; 
import { WrappedDeviceCreateComponent } from './components/device/deviceCreateForm';
import { WrappedDeviceDetailComponent } from './components/device/deviceDetailForm';
import { WrappedDeviceEditComponent } from './components/device/deviceEditForm';
import { WrappedDeviceSearchComponent } from './components/device/deviceSearchForm';					
import { WrappedDeviceActionCreateComponent } from './components/deviceAction/deviceActionCreateForm';
import { WrappedDeviceActionDetailComponent } from './components/deviceAction/deviceActionDetailForm';
import { WrappedDeviceActionEditComponent } from './components/deviceAction/deviceActionEditForm';
import { WrappedDeviceActionSearchComponent } from './components/deviceAction/deviceActionSearchForm';

import { WrappedLoginComponent } from './components/auth/loginForm';
import { WrappedRegisterComponent } from './components/auth/registerForm';
import { WrappedResetPasswordComponent } from './components/auth/resetPasswordForm';


export const AppRouter: React.StatelessComponent<{}> = () => {

  return (
    <BrowserRouter basename={Constants.HostedSubDirectory}>   

        <Switch>
          <Route exact path="/" component={wrapperHeader(Dashboard, "Dashboard")} />
          <Route exact path={AuthClientRoutes.Login} component={wrapperHeader(WrappedLoginComponent, "Login")} />
          <Route exact path={AuthClientRoutes.Register} component={wrapperHeader(WrappedRegisterComponent, "Register")} />
          <Route exact path={AuthClientRoutes.ResetPassword} component={wrapperHeader(WrappedResetPasswordComponent, "Reset Password")} />
		  <Route path={ClientRoutes.Devices + "/create"} component={wrapperHeader(WrappedDeviceCreateComponent, "Device Create")} />
                      <Route path={ClientRoutes.Devices + "/edit/:id"} component={wrapperHeader(WrappedDeviceEditComponent, "Device Edit")} />
                      <Route path={ClientRoutes.Devices + "/:id"} component={wrapperHeader(WrappedDeviceDetailComponent , "Device Detail")} />
                      <Route path={ClientRoutes.Devices} component={wrapperHeader(WrappedDeviceSearchComponent, "Device Search")} />
					<Route path={ClientRoutes.DeviceActions + "/create"} component={wrapperHeader(WrappedDeviceActionCreateComponent, "Device Actions Create")} />
                      <Route path={ClientRoutes.DeviceActions + "/edit/:id"} component={wrapperHeader(WrappedDeviceActionEditComponent, "Device Actions Edit")} />
                      <Route path={ClientRoutes.DeviceActions + "/:id"} component={wrapperHeader(WrappedDeviceActionDetailComponent , "Device Actions Detail")} />
                      <Route path={ClientRoutes.DeviceActions} component={wrapperHeader(WrappedDeviceActionSearchComponent, "Device Actions Search")} />
					        </Switch>
    </BrowserRouter>
  );
}

/*<Codenesium>
    <Hash>192e11cd173a1dedbe6fb397ac3a5fb1</Hash>
</Codenesium>*/