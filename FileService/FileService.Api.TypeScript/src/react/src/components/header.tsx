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
                key="bucket"
                title={
                  <span>
                    <Icon type="user" />
                    <span>Bucket</span>
                  </span>
                }
              >
                <Link to={ClientRoutes.Buckets}>Buckets</Link>
              </MenuItem>

              <MenuItem
                key="file"
                title={
                  <span>
                    <Icon type="user" />
                    <span>File</span>
                  </span>
                }
              >
                <Link to={ClientRoutes.Files}>Files</Link>
              </MenuItem>

              <MenuItem
                key="fileType"
                title={
                  <span>
                    <Icon type="user" />
                    <span>FileType</span>
                  </span>
                }
              >
                <Link to={ClientRoutes.FileTypes}>FileTypes</Link>
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
    <Hash>e5d1f4779870ac95ba8ae67b4ada389b</Hash>
</Codenesium>*/