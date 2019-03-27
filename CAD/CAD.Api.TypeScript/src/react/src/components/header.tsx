import * as React from 'react';
import { Layout, Menu, Breadcrumb, Icon } from 'antd';
import { Link, RouteComponentProps } from 'react-router-dom';
import { ClientRoutes, Constants, AuthClientRoutes } from '../constants';
import ErrorBoundary from './errorBoundary';
const { Header, Content, Footer, Sider } = Layout;

interface WrapperHeaderProps {}

interface WrapperHeaderState {
  collapsed: boolean;
}
export const wrapperHeader = (
  Component: React.ComponentClass<any> | React.SFC<any>,
  displayName: string
) => {
  class WrapperHeaderComponent extends React.Component<
    WrapperHeaderProps & RouteComponentProps,
    WrapperHeaderState
  > {
    state = { collapsed: true };

    onCollapse = () => {
      this.setState({ ...this.state, collapsed: !this.state.collapsed });
    };
    render() {
      return (
        <Layout style={{ minHeight: '100vh' }}>
          <Sider
            collapsible
            collapsed={this.state.collapsed}
            onCollapse={this.onCollapse}
          >
            <div className="logo" />
            <Menu theme="dark" defaultSelectedKeys={['1']} mode="inline">
              <Menu.Item
                key="Home"
                onClick={() => {
                  this.setState({ ...this.state, collapsed: true });
                }}
              >
                <Icon type="home" />
                <span>Home</span>
                <Link to={'/'} />
              </Menu.Item>

              <Menu.Item key="address">
                <Icon type="pie-chart" />
                <span>Address</span>
                <Link to={ClientRoutes.Addresses} />
              </Menu.Item>

              <Menu.Item key="call">
                <Icon type="rise" />
                <span>Call</span>
                <Link to={ClientRoutes.Calls} />
              </Menu.Item>

              <Menu.Item key="callAssignment">
                <Icon type="bars" />
                <span>Call Assignment</span>
                <Link to={ClientRoutes.CallAssignments} />
              </Menu.Item>

              <Menu.Item key="callDisposition">
                <Icon type="cloud" />
                <span>Call Disposition</span>
                <Link to={ClientRoutes.CallDispositions} />
              </Menu.Item>

              <Menu.Item key="callPerson">
                <Icon type="code" />
                <span>Call Person</span>
                <Link to={ClientRoutes.CallPersons} />
              </Menu.Item>

              <Menu.Item key="callStatus">
                <Icon type="smile" />
                <span>Call Status</span>
                <Link to={ClientRoutes.CallStatus} />
              </Menu.Item>

              <Menu.Item key="callType">
                <Icon type="laptop" />
                <span>Call Type</span>
                <Link to={ClientRoutes.CallTypes} />
              </Menu.Item>

              <Menu.Item key="note">
                <Icon type="mobile" />
                <span>Note</span>
                <Link to={ClientRoutes.Notes} />
              </Menu.Item>

              <Menu.Item key="offCapability">
                <Icon type="paper-clip" />
                <span>Off Capability</span>
                <Link to={ClientRoutes.OffCapabilities} />
              </Menu.Item>

              <Menu.Item key="officer">
                <Icon type="setting" />
                <span>Officer</span>
                <Link to={ClientRoutes.Officers} />
              </Menu.Item>

              <Menu.Item key="officerCapabilities">
                <Icon type="user" />
                <span>Officer Capabilities</span>
                <Link to={ClientRoutes.OfficerCapabilities} />
              </Menu.Item>

              <Menu.Item key="person">
                <Icon type="home" />
                <span>Person</span>
                <Link to={ClientRoutes.People} />
              </Menu.Item>

              <Menu.Item key="personType">
                <Icon type="camera" />
                <span>Person Type</span>
                <Link to={ClientRoutes.PersonTypes} />
              </Menu.Item>

              <Menu.Item key="unit">
                <Icon type="like" />
                <span>Unit</span>
                <Link to={ClientRoutes.Units} />
              </Menu.Item>

              <Menu.Item key="unitDisposition">
                <Icon type="bulb" />
                <span>Unit Disposition</span>
                <Link to={ClientRoutes.UnitDispositions} />
              </Menu.Item>

              <Menu.Item key="unitOfficer">
                <Icon type="tool" />
                <span>Unit Officer</span>
                <Link to={ClientRoutes.UnitOfficers} />
              </Menu.Item>

              <Menu.Item key="vehCapability">
                <Icon type="coffee" />
                <span>Veh Capability</span>
                <Link to={ClientRoutes.VehCapabilities} />
              </Menu.Item>

              <Menu.Item key="vehicle">
                <Icon type="experiment" />
                <span>Vehicle</span>
                <Link to={ClientRoutes.Vehicles} />
              </Menu.Item>

              <Menu.Item key="vehicleCapabilities">
                <Icon type="security-scan" />
                <span>Vehicle Capabilities</span>
                <Link to={ClientRoutes.VehicleCapabilities} />
              </Menu.Item>

              <Menu.Item key="vehicleOfficer">
                <Icon type="thunderbolt" />
                <span>Vehicle Officer</span>
                <Link to={ClientRoutes.VehicleOfficers} />
              </Menu.Item>

              <Menu.SubMenu
                title={
                  <span>
                    <Icon type="setting" />
                    <span>Settings</span>
                  </span>
                }
              >
                <Menu.Item key="lock">
                  <Icon type="lock" />
                  <span>Change Password</span>
                  <Link to={AuthClientRoutes.ChangePassword} />
                </Menu.Item>
                <Menu.Item key="mail">
                  <Icon type="mail" />
                  <span>Change Email</span>
                  <Link to={AuthClientRoutes.ChangeEmail} />
                </Menu.Item>
                <Menu.Item key="logout">
                  <Icon type="logout" />
                  <span>Logout</span>
                  <Link to={AuthClientRoutes.Logout} />
                </Menu.Item>
              </Menu.SubMenu>
            </Menu>
          </Sider>
          <Layout>
            <Content style={{ margin: '0 16px' }}>
              <h2>{displayName}</h2>
              <div
                style={{ padding: 24, background: '#fff', minHeight: '600px' }}
              >
                <ErrorBoundary>
                  <Component {...this.props} />
                </ErrorBoundary>
              </div>
            </Content>
            <Footer style={{ textAlign: 'center' }}>Footer</Footer>
          </Layout>
        </Layout>
      );
    }
  }
  return WrapperHeaderComponent;
};


/*<Codenesium>
    <Hash>6682eba8b7f385cfcabfbb888be08ceb</Hash>
</Codenesium>*/