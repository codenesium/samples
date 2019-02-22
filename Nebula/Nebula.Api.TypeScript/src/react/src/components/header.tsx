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

              <MenuItem key="chain">
                <Icon type="pie-chart" />
                <span>Chains</span>
                <Link to={ClientRoutes.Chains} />
              </MenuItem>

              <MenuItem key="chainStatus">
                <Icon type="rise" />
                <span>ChainStatuses</span>
                <Link to={ClientRoutes.ChainStatuses} />
              </MenuItem>

              <MenuItem key="clasp">
                <Icon type="bars" />
                <span>Clasps</span>
                <Link to={ClientRoutes.Clasps} />
              </MenuItem>

              <MenuItem key="link">
                <Icon type="cloud" />
                <span>Links</span>
                <Link to={ClientRoutes.Links} />
              </MenuItem>

              <MenuItem key="linkLog">
                <Icon type="code" />
                <span>LinkLogs</span>
                <Link to={ClientRoutes.LinkLogs} />
              </MenuItem>

              <MenuItem key="linkStatus">
                <Icon type="smile" />
                <span>LinkStatuses</span>
                <Link to={ClientRoutes.LinkStatuses} />
              </MenuItem>

              <MenuItem key="machine">
                <Icon type="laptop" />
                <span>Machines</span>
                <Link to={ClientRoutes.Machines} />
              </MenuItem>

              <MenuItem key="organization">
                <Icon type="mobile" />
                <span>Organizations</span>
                <Link to={ClientRoutes.Organizations} />
              </MenuItem>

              <MenuItem key="team">
                <Icon type="paper-clip" />
                <span>Teams</span>
                <Link to={ClientRoutes.Teams} />
              </MenuItem>
            </Menu>
          </Sider>
          <Layout>
            <Header style={{ background: '#fff', padding: 0 }} />
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
    <Hash>d175e98471cc015e30bd073bc446617b</Hash>
</Codenesium>*/