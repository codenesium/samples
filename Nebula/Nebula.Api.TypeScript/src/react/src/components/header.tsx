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

              <Menu.Item key="chain">
                <Icon type="pie-chart" />
                <span>Chains</span>
                <Link to={ClientRoutes.Chains} />
              </Menu.Item>

              <Menu.Item key="chainStatus">
                <Icon type="rise" />
                <span>Chain Status</span>
                <Link to={ClientRoutes.ChainStatuses} />
              </Menu.Item>

              <Menu.Item key="clasp">
                <Icon type="bars" />
                <span>Clasps</span>
                <Link to={ClientRoutes.Clasps} />
              </Menu.Item>

              <Menu.Item key="link">
                <Icon type="cloud" />
                <span>Links</span>
                <Link to={ClientRoutes.Links} />
              </Menu.Item>

              <Menu.Item key="linkLog">
                <Icon type="code" />
                <span>Link Log</span>
                <Link to={ClientRoutes.LinkLogs} />
              </Menu.Item>

              <Menu.Item key="linkStatus">
                <Icon type="smile" />
                <span>Link Status</span>
                <Link to={ClientRoutes.LinkStatuses} />
              </Menu.Item>

              <Menu.Item key="machine">
                <Icon type="laptop" />
                <span>Machines</span>
                <Link to={ClientRoutes.Machines} />
              </Menu.Item>

              <Menu.Item key="organization">
                <Icon type="mobile" />
                <span>Organizations</span>
                <Link to={ClientRoutes.Organizations} />
              </Menu.Item>

              <Menu.Item key="team">
                <Icon type="paper-clip" />
                <span>Teams</span>
                <Link to={ClientRoutes.Teams} />
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
    <Hash>a972d7fce2d9503b23e8602437978730</Hash>
</Codenesium>*/