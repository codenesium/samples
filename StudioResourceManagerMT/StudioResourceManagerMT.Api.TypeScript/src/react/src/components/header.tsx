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
              <MenuItem
                key="Home"
                onClick={() => {
                  this.setState({ ...this.state, collapsed: true });
                }}
              >
                <Icon type="home" />
                <span>Home</span>
                <Link to={'/'} />
              </MenuItem>

              <MenuItem key="admin">
                <Icon type="pie-chart" />
                <span>Admins</span>
                <Link to={ClientRoutes.Admins} />
              </MenuItem>

              <MenuItem key="event">
                <Icon type="rise" />
                <span>Events</span>
                <Link to={ClientRoutes.Events} />
              </MenuItem>

              <MenuItem key="eventStatu">
                <Icon type="bars" />
                <span>EventStatus</span>
                <Link to={ClientRoutes.EventStatus} />
              </MenuItem>

              <MenuItem key="family">
                <Icon type="cloud" />
                <span>Families</span>
                <Link to={ClientRoutes.Families} />
              </MenuItem>

              <MenuItem key="rate">
                <Icon type="code" />
                <span>Rates</span>
                <Link to={ClientRoutes.Rates} />
              </MenuItem>

              <MenuItem key="space">
                <Icon type="smile" />
                <span>Spaces</span>
                <Link to={ClientRoutes.Spaces} />
              </MenuItem>

              <MenuItem key="spaceFeature">
                <Icon type="laptop" />
                <span>SpaceFeatures</span>
                <Link to={ClientRoutes.SpaceFeatures} />
              </MenuItem>

              <MenuItem key="student">
                <Icon type="mobile" />
                <span>Students</span>
                <Link to={ClientRoutes.Students} />
              </MenuItem>

              <MenuItem key="studio">
                <Icon type="paper-clip" />
                <span>Studios</span>
                <Link to={ClientRoutes.Studios} />
              </MenuItem>

              <MenuItem key="teacher">
                <Icon type="setting" />
                <span>Teachers</span>
                <Link to={ClientRoutes.Teachers} />
              </MenuItem>

              <MenuItem key="teacherSkill">
                <Icon type="user" />
                <span>TeacherSkills</span>
                <Link to={ClientRoutes.TeacherSkills} />
              </MenuItem>

              <MenuItem key="user">
                <Icon type="home" />
                <span>Users</span>
                <Link to={ClientRoutes.Users} />
              </MenuItem>
            </Menu>
          </Sider>
          <Layout>
            <Content style={{ margin: '0 16px' }}>
              <h2>{displayName}</h2>
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
    <Hash>a61c0acb9623ac4a12413ad7266a2538</Hash>
</Codenesium>*/