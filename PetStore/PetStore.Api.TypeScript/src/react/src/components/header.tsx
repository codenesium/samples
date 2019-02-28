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
                key="breed"
              >
			  <Icon type="pie-chart" />
              <span>Breeds</span>
              <Link to={ClientRoutes.Breeds}></Link>
              </MenuItem>

							   <MenuItem
                key="paymentType"
              >
			  <Icon type="rise" />
              <span>Payment Types</span>
              <Link to={ClientRoutes.PaymentTypes}></Link>
              </MenuItem>

							   <MenuItem
                key="pen"
              >
			  <Icon type="bars" />
              <span>Pens</span>
              <Link to={ClientRoutes.Pens}></Link>
              </MenuItem>

							   <MenuItem
                key="pet"
              >
			  <Icon type="cloud" />
              <span>Pets</span>
              <Link to={ClientRoutes.Pets}></Link>
              </MenuItem>

							   <MenuItem
                key="sale"
              >
			  <Icon type="code" />
              <span>Sales</span>
              <Link to={ClientRoutes.Sales}></Link>
              </MenuItem>

							   <MenuItem
                key="species"
              >
			  <Icon type="smile" />
              <span>Species</span>
              <Link to={ClientRoutes.Species}></Link>
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
    <Hash>437849847b23829972c9bd79296ba8c9</Hash>
</Codenesium>*/