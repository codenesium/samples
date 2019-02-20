import * as React from 'react';
import { Layout, Menu, Breadcrumb, Icon } from 'antd';
import MenuItem from '../../node_modules/antd/lib/menu/MenuItem';
import { Link, RouteComponentProps } from 'react-router-dom';
import { ClientRoutes, Constants } from '../constants';
const { Header, Content, Footer, Sider } = Layout;

const SubMenu = Menu.SubMenu;

interface WrapperHeaderProps {}

interface WrapperHeaderState {
  collapsed: boolean;
}
export const wrapperHeader = (
  Component: React.ComponentClass<any> | React.SFC<any>
) => {
  class WrapperHeaderComponent extends React.Component<
    WrapperHeaderProps & RouteComponentProps,
    WrapperHeaderState
  > {
    state = { collapsed: false };

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
              <MenuItem
                key="Dashboard"
                title={
                  <span>
                    <Icon type="user" />
                    <span>Dashboard</span>
                  </span>
                }
              >
                <Link to={'/'}>Dashboard</Link>
              </MenuItem>

              <MenuItem
                key="admin"
                title={
                  <span>
                    <Icon type="user" />
                    <span>Admin</span>
                  </span>
                }
              >
                <Link to={ClientRoutes.Admins}>Admins</Link>
              </MenuItem>

              <MenuItem
                key="event"
                title={
                  <span>
                    <Icon type="user" />
                    <span>Event</span>
                  </span>
                }
              >
                <Link to={ClientRoutes.Events}>Events</Link>
              </MenuItem>

              <MenuItem
                key="eventStatus"
                title={
                  <span>
                    <Icon type="user" />
                    <span>EventStatus</span>
                  </span>
                }
              >
                <Link to={ClientRoutes.EventStatus}>EventStatus</Link>
              </MenuItem>

              <MenuItem
                key="family"
                title={
                  <span>
                    <Icon type="user" />
                    <span>Family</span>
                  </span>
                }
              >
                <Link to={ClientRoutes.Families}>Families</Link>
              </MenuItem>

              <MenuItem
                key="rate"
                title={
                  <span>
                    <Icon type="user" />
                    <span>Rate</span>
                  </span>
                }
              >
                <Link to={ClientRoutes.Rates}>Rates</Link>
              </MenuItem>

              <MenuItem
                key="space"
                title={
                  <span>
                    <Icon type="user" />
                    <span>Space</span>
                  </span>
                }
              >
                <Link to={ClientRoutes.Spaces}>Spaces</Link>
              </MenuItem>

              <MenuItem
                key="spaceFeature"
                title={
                  <span>
                    <Icon type="user" />
                    <span>SpaceFeature</span>
                  </span>
                }
              >
                <Link to={ClientRoutes.SpaceFeatures}>SpaceFeatures</Link>
              </MenuItem>

              <MenuItem
                key="student"
                title={
                  <span>
                    <Icon type="user" />
                    <span>Student</span>
                  </span>
                }
              >
                <Link to={ClientRoutes.Students}>Students</Link>
              </MenuItem>

              <MenuItem
                key="studio"
                title={
                  <span>
                    <Icon type="user" />
                    <span>Studio</span>
                  </span>
                }
              >
                <Link to={ClientRoutes.Studios}>Studios</Link>
              </MenuItem>

              <MenuItem
                key="teacher"
                title={
                  <span>
                    <Icon type="user" />
                    <span>Teacher</span>
                  </span>
                }
              >
                <Link to={ClientRoutes.Teachers}>Teachers</Link>
              </MenuItem>

              <MenuItem
                key="teacherSkill"
                title={
                  <span>
                    <Icon type="user" />
                    <span>TeacherSkill</span>
                  </span>
                }
              >
                <Link to={ClientRoutes.TeacherSkills}>TeacherSkills</Link>
              </MenuItem>

              <MenuItem
                key="user"
                title={
                  <span>
                    <Icon type="user" />
                    <span>User</span>
                  </span>
                }
              >
                <Link to={ClientRoutes.Users}>Users</Link>
              </MenuItem>
            </Menu>
          </Sider>
          <Layout>
            <Header style={{ background: '#fff', padding: 0 }} />
            <Content style={{ margin: '0 16px' }}>
              <div style={{ padding: 24, background: '#fff', minHeight: 360 }}>
                <Component {...this.props} />
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
    <Hash>2f09ef3b3336b95e95fb43f8a469c89f</Hash>
</Codenesium>*/