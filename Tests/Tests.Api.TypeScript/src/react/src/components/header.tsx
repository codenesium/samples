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

              <Menu.Item key="columnSameAsFKTable">
                <Icon type="pie-chart" />
                <span>ColumnSameAsFKTables</span>
                <Link to={ClientRoutes.ColumnSameAsFKTables} />
              </Menu.Item>

              <Menu.Item key="includedColumnTest">
                <Icon type="rise" />
                <span>IncludedColumnTests</span>
                <Link to={ClientRoutes.IncludedColumnTests} />
              </Menu.Item>

              <Menu.Item key="person">
                <Icon type="bars" />
                <span>People</span>
                <Link to={ClientRoutes.People} />
              </Menu.Item>

              <Menu.Item key="rowVersionCheck">
                <Icon type="cloud" />
                <span>RowVersionChecks</span>
                <Link to={ClientRoutes.RowVersionChecks} />
              </Menu.Item>

              <Menu.Item key="selfReference">
                <Icon type="code" />
                <span>SelfReferences</span>
                <Link to={ClientRoutes.SelfReferences} />
              </Menu.Item>

              <Menu.Item key="table">
                <Icon type="smile" />
                <span>Tables</span>
                <Link to={ClientRoutes.Tables} />
              </Menu.Item>

              <Menu.Item key="testAllFieldType">
                <Icon type="laptop" />
                <span>TestAllFieldTypes</span>
                <Link to={ClientRoutes.TestAllFieldTypes} />
              </Menu.Item>

              <Menu.Item key="testAllFieldTypesNullable">
                <Icon type="mobile" />
                <span>TestAllFieldTypesNullables</span>
                <Link to={ClientRoutes.TestAllFieldTypesNullables} />
              </Menu.Item>

              <Menu.Item key="timestampCheck">
                <Icon type="paper-clip" />
                <span>TimestampChecks</span>
                <Link to={ClientRoutes.TimestampChecks} />
              </Menu.Item>

              <Menu.Item key="vPerson">
                <Icon type="setting" />
                <span>VPersons</span>
                <Link to={ClientRoutes.VPersons} />
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
    <Hash>8a1ec11fee2719bafa0edac3bf483901</Hash>
</Codenesium>*/