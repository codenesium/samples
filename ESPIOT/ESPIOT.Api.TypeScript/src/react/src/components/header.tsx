import * as React from 'react';
import { Layout, Menu, Breadcrumb, Icon } from 'antd';
import MenuItem from 'antd/lib/menu/MenuItem';
import { Link, RouteComponentProps } from 'react-router-dom';
import { ClientRoutes, AuthClientRoutes } from '../constants';
const { Header, Content, Footer, Sider } = Layout;

const SubMenu = Menu.SubMenu;

interface WrapperHeaderProps {}

interface WrapperHeaderState {
  collapsed: boolean;
}
export const wrapperHeader = (Component: React.ComponentClass<any> | React.SFC<any>,
displayName:string) => {
  class WrapperHeaderComponent extends React.Component<WrapperHeaderProps & RouteComponentProps, WrapperHeaderState> {
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
				onClick={() =>  {this.setState({...this.state, collapsed:true})}}
              >
                <Icon type="home" />
                <span>Home</span>
                <Link to={'/'}></Link>
              </MenuItem>

			   			   <MenuItem
                key="device"
              >
			  <Icon type="edit" />
              <span>Device</span>
              <Link to={ClientRoutes.Devices}></Link>
              </MenuItem>

							   <MenuItem
                key="deviceAction"
              >
			  <Icon type="delete" />
              <span>Device Actions</span>
              <Link to={ClientRoutes.DeviceActions}></Link>
              </MenuItem>

        <MenuItem
                key="login"
              >
			  <Icon type="delete" />
              <span>Login</span>
              <Link to={AuthClientRoutes.Login}></Link>
              </MenuItem>

 <MenuItem
                key="register"
              >
			  <Icon type="delete" />
              <span>Register</span>
              <Link to={AuthClientRoutes.Register}></Link>
              </MenuItem>

 <MenuItem
                key="resetpassword"
              >
			  <Icon type="delete" />
              <span>Reset Password</span>
              <Link to={AuthClientRoutes.ResetPassword}></Link>
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
    <Hash>8e63bc852961e617c6b73e79cd49d44b</Hash>
</Codenesium>*/