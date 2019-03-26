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

              <Menu.Item key="admin">
                <Icon type="pie-chart" />
                <span>Admin</span>
                <Link to={ClientRoutes.Admins} />
              </Menu.Item>

              <Menu.Item key="event">
                <Icon type="rise" />
                <span>Event</span>
                <Link to={ClientRoutes.Events} />
              </Menu.Item>

              <Menu.Item key="eventStatu">
                <Icon type="bars" />
                <span>Event Status</span>
                <Link to={ClientRoutes.EventStatus} />
              </Menu.Item>

              <Menu.Item key="family">
                <Icon type="cloud" />
                <span>Family</span>
                <Link to={ClientRoutes.Families} />
              </Menu.Item>

              <Menu.Item key="rate">
                <Icon type="code" />
                <span>Rate</span>
                <Link to={ClientRoutes.Rates} />
              </Menu.Item>

              <Menu.Item key="space">
                <Icon type="smile" />
                <span>Space</span>
                <Link to={ClientRoutes.Spaces} />
              </Menu.Item>

              <Menu.Item key="spaceFeature">
                <Icon type="laptop" />
                <span>Space Feature</span>
                <Link to={ClientRoutes.SpaceFeatures} />
              </Menu.Item>

              <Menu.Item key="student">
                <Icon type="mobile" />
                <span>Student</span>
                <Link to={ClientRoutes.Students} />
              </Menu.Item>

              <Menu.Item key="studio">
                <Icon type="paper-clip" />
                <span>Studio</span>
                <Link to={ClientRoutes.Studios} />
              </Menu.Item>

              <Menu.Item key="teacher">
                <Icon type="setting" />
                <span>Teacher</span>
                <Link to={ClientRoutes.Teachers} />
              </Menu.Item>

              <Menu.Item key="teacherSkill">
                <Icon type="user" />
                <span>Teacher Skill</span>
                <Link to={ClientRoutes.TeacherSkills} />
              </Menu.Item>

              <Menu.Item key="user">
                <Icon type="home" />
                <span>User</span>
                <Link to={ClientRoutes.Users} />
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
    <Hash>5a1ac42fe77e3a7c3effedbad740411c</Hash>
</Codenesium>*/