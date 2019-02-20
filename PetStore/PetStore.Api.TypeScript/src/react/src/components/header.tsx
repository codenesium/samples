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
                key="breed"
                title={
                  <span>
                    <Icon type="user" />
                    <span>Breed</span>
                  </span>
                }
              >
                <Link to={ClientRoutes.Breeds}>Breeds</Link>
              </MenuItem>

              <MenuItem
                key="paymentType"
                title={
                  <span>
                    <Icon type="user" />
                    <span>PaymentType</span>
                  </span>
                }
              >
                <Link to={ClientRoutes.PaymentTypes}>PaymentTypes</Link>
              </MenuItem>

              <MenuItem
                key="pen"
                title={
                  <span>
                    <Icon type="user" />
                    <span>Pen</span>
                  </span>
                }
              >
                <Link to={ClientRoutes.Pens}>Pens</Link>
              </MenuItem>

              <MenuItem
                key="pet"
                title={
                  <span>
                    <Icon type="user" />
                    <span>Pet</span>
                  </span>
                }
              >
                <Link to={ClientRoutes.Pets}>Pets</Link>
              </MenuItem>

              <MenuItem
                key="sale"
                title={
                  <span>
                    <Icon type="user" />
                    <span>Sale</span>
                  </span>
                }
              >
                <Link to={ClientRoutes.Sales}>Sales</Link>
              </MenuItem>

              <MenuItem
                key="species"
                title={
                  <span>
                    <Icon type="user" />
                    <span>Species</span>
                  </span>
                }
              >
                <Link to={ClientRoutes.Species}>Species</Link>
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
    <Hash>090b493dc191fb9bd3b8fd940646b1d5</Hash>
</Codenesium>*/